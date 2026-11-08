using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ChitayGorod.Models;

namespace ChitayGorod
{
    public partial class FormAddEditBook : Form
    {
        private readonly Book? _bookToEdit;
        private string? _selectedImageFileName;

        public FormAddEditBook(Book? book = null)
        {
            InitializeComponent();
            _bookToEdit = book;

            ApplyStyles();
            LoadDictionaries();

            if (_bookToEdit != null)
            {
                this.Text = "Редактирование книги";
                FillBookData(_bookToEdit);
            }
            else
            {
                this.Text = "Добавление книги";
                SetPlaceholderCover();
            }
        }

        private void ApplyStyles()
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            this.Font = new Font("Times New Roman", 11f);
            btnSave.BackColor = ColorTranslator.FromHtml("#4A6FA5");
            btnCancel.BackColor = ColorTranslator.FromHtml("#F0F8FF");
            btnSelectCover.BackColor = ColorTranslator.FromHtml("#F0F8FF");
        }

        private void LoadDictionaries()
        {
            using var db = new LibraryContext();

            var authors = db.Authors.OrderBy(a => a.AuthorName).ToList();
            cbAuthor.DataSource = authors;
            cbAuthor.DisplayMember = "AuthorName";
            cbAuthor.ValueMember = "AuthorId";

            var genres = db.Genres.OrderBy(g => g.GenreName).ToList();
            cbGenre.DataSource = genres;
            cbGenre.DisplayMember = "GenreName";
            cbGenre.ValueMember = "GenreId";

            var publishers = db.Publishers.OrderBy(p => p.PublisherName).ToList();
            cbPublisher.DataSource = publishers;
            cbPublisher.DisplayMember = "PublisherName";
            cbPublisher.ValueMember = "PublisherId";
        }

        private void FillBookData(Book book)
        {
            tbTitle.Text = book.Title;
            cbAuthor.SelectedValue = book.AuthorId;
            cbGenre.SelectedValue = book.GenreId;
            cbPublisher.SelectedValue = book.PublisherId;
            numYear.Value = book.PublicationYear;
            numPages.Value = book.Pages;
            numTotalCopies.Value = book.TotalCopies;
            tbAnnotation.Text = book.Annotation ?? "";

            _selectedImageFileName = book.CoverImage;
            DisplayCoverImage(_selectedImageFileName);
        }

        private void DisplayCoverImage(string? fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string fullPath = Path.Combine(Application.StartupPath, "Images", fileName);
                if (File.Exists(fullPath))
                {
                    using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                    pbCover.Image = Image.FromStream(stream);
                    return;
                }
            }
            SetPlaceholderCover();
        }

        private void SetPlaceholderCover()
        {
            string placeholderPath = Path.Combine(Application.StartupPath, "Images", "book_placeholder.jpeg");
            if (File.Exists(placeholderPath))
            {
                using var stream = new FileStream(placeholderPath, FileMode.Open, FileAccess.Read);
                pbCover.Image = Image.FromStream(stream);
            }
            else
            {
                pbCover.Image = null;
            }
        }

        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Выберите обложку книги"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(imagesFolder);

                string extension = Path.GetExtension(ofd.FileName);
                string newFileName = $"cover_{Guid.NewGuid()}{extension}";
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                File.Copy(ofd.FileName, destinationPath, true);

                _selectedImageFileName = newFileName;
                DisplayCoverImage(_selectedImageFileName);
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            _selectedImageFileName = null;
            SetPlaceholderCover();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Введите название книги.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTitle.Focus();
                return;
            }

            if (cbAuthor.SelectedValue == null || cbGenre.SelectedValue == null || cbPublisher.SelectedValue == null)
            {
                MessageBox.Show("Выберите автора, жанр и издательство.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new LibraryContext();

                if (_bookToEdit == null)
                {
                    var newBook = new Book
                    {
                        Title = tbTitle.Text.Trim(),
                        AuthorId = (int)cbAuthor.SelectedValue,
                        GenreId = (int)cbGenre.SelectedValue,
                        PublisherId = (int)cbPublisher.SelectedValue,
                        PublicationYear = (short)numYear.Value,
                        Pages = (short)numPages.Value,
                        TotalCopies = (int)numTotalCopies.Value,
                        AvailableCopies = (int)numTotalCopies.Value,
                        Annotation = string.IsNullOrWhiteSpace(tbAnnotation.Text) ? null : tbAnnotation.Text.Trim(),
                        CoverImage = _selectedImageFileName
                    };

                    db.Books.Add(newBook);
                }
                else
                {
                    var book = db.Books.FirstOrDefault(b => b.BookId == _bookToEdit.BookId);
                    if (book != null)
                    {
                        book.Title = tbTitle.Text.Trim();
                        book.AuthorId = (int)cbAuthor.SelectedValue;
                        book.GenreId = (int)cbGenre.SelectedValue;
                        book.PublisherId = (int)cbPublisher.SelectedValue;
                        book.PublicationYear = (short)numYear.Value;
                        book.Pages = (short)numPages.Value;

                        int issuedCount = book.TotalCopies - book.AvailableCopies;
                        book.TotalCopies = (int)numTotalCopies.Value;
                        book.AvailableCopies = Math.Max(0, book.TotalCopies - issuedCount);

                        book.Annotation = string.IsNullOrWhiteSpace(tbAnnotation.Text) ? null : tbAnnotation.Text.Trim();
                        book.CoverImage = _selectedImageFileName;
                    }
                }

                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
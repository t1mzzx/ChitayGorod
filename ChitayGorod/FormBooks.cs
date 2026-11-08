using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ChitayGorod.Models;
using Microsoft.EntityFrameworkCore;

namespace ChitayGorod
{
    public partial class FormBooks : Form
    {
        private int _totalBooksCount = 0;

        public FormBooks()
        {
            InitializeComponent();
            ApplyStyleGuide();
            ConfigureBooksGrid();
            InitFilterControls();
            LoadBooksList();

            this.Shown += (s, e) =>
            {
                dgvBooks.ClearSelection();
                dgvBooks.CurrentCell = null;
            };
        }

        private void ApplyStyleGuide()
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            panelHeader.BackColor = ColorTranslator.FromHtml("#F0F8FF");
            panelFilter.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void ConfigureBooksGrid()
        {
            dgvBooks.Columns.Clear();
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.ColumnHeadersVisible = false;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvBooks.BackgroundColor = ColorTranslator.FromHtml("#F0F8FF");
            dgvBooks.DefaultCellStyle.Font = new Font("Times New Roman", 11);
            dgvBooks.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#4A6FA5");
            dgvBooks.DefaultCellStyle.SelectionForeColor = Color.White;

            DataGridViewImageColumn colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 140;
            colPhoto.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPhoto.DefaultCellStyle.Padding = new Padding(6);

            DataGridViewTextBoxColumn colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInfo.FillWeight = 75;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfo.DefaultCellStyle.Padding = new Padding(10, 8, 10, 8);

            DataGridViewTextBoxColumn colCopies = new DataGridViewTextBoxColumn();
            colCopies.Name = "colCopies";
            colCopies.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCopies.FillWeight = 25;
            colCopies.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCopies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colCopies.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);

            dgvBooks.Columns.Add(colPhoto);
            dgvBooks.Columns.Add(colInfo);
            dgvBooks.Columns.Add(colCopies);
        }

        private void InitFilterControls()
        {
            cbSort.Items.Clear();
            cbSort.Items.Add("Без сортировки");
            cbSort.Items.Add("По названию (А-Я)");
            cbSort.Items.Add("По названию (Я-А)");
            cbSort.Items.Add("По остатку (по возрастанию)");
            cbSort.Items.Add("По остатку (по убыванию)");
            cbSort.SelectedIndex = 0;

            cbGenreFilter.Items.Clear();
            cbGenreFilter.Items.Add("Все жанры");
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    var genres = db.Genres.OrderBy(g => g.GenreName).Select(g => g.GenreName).ToList();
                    cbGenreFilter.Items.AddRange(genres.ToArray());
                }
            }
            catch { }
            cbGenreFilter.SelectedIndex = 0;

            tbSearch.TextChanged += (s, e) => LoadBooksList();
            cbGenreFilter.SelectedIndexChanged += (s, e) => LoadBooksList();
            cbSort.SelectedIndexChanged += (s, e) => LoadBooksList();
        }

        private void LoadBooksList()
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    _totalBooksCount = db.Books.Count();

                    var query = db.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Include(b => b.Publisher)
                        .Include(b => b.BookLoans)
                        .AsQueryable();

                    string searchText = tbSearch.Text.Trim().ToLower();
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query = query.Where(b =>
                            b.Title.ToLower().Contains(searchText) ||
                            b.Author.AuthorName.ToLower().Contains(searchText));
                    }

                    if (cbGenreFilter.SelectedIndex > 0)
                    {
                        string selectedGenre = cbGenreFilter.SelectedItem?.ToString() ?? "";
                        query = query.Where(b => b.Genre.GenreName == selectedGenre);
                    }

                    switch (cbSort.SelectedIndex)
                    {
                        case 1:
                            query = query.OrderBy(b => b.Title);
                            break;
                        case 2:
                            query = query.OrderByDescending(b => b.Title);
                            break;
                        case 3:
                            query = query.OrderBy(b => b.AvailableCopies);
                            break;
                        case 4:
                            query = query.OrderByDescending(b => b.AvailableCopies);
                            break;
                        default:
                            query = query.OrderBy(b => b.BookId);
                            break;
                    }

                    var booksList = query.ToList();

                    dgvBooks.Rows.Clear();
                    DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                    foreach (Book book in booksList)
                    {
                        Image coverImage = LoadBookCover(book.CoverImage);

                        string annotationText = string.IsNullOrWhiteSpace(book.Annotation)
                            ? "Отсутствует"
                            : book.Annotation;

                        string bookDetails =
                            $"Название книги: {book.Title}\n" +
                            $"Автор: {book.Author.AuthorName}\n" +
                            $"ISBN: {book.Isbn} | Жанр: {book.Genre.GenreName}\n" +
                            $"Издательство: {book.Publisher.PublisherName} | Год издания: {book.PublicationYear} | Страниц: {book.Pages}\n" +
                            $"Аннотация: {annotationText}";

                        string copiesInfo =
                            $"Всего экземпляров: {book.TotalCopies}\n" +
                            $"Доступно: {book.AvailableCopies}";

                        int rowIndex = dgvBooks.Rows.Add(coverImage, bookDetails, copiesInfo);
                        DataGridViewRow currentRow = dgvBooks.Rows[rowIndex];
                        currentRow.MinimumHeight = 140;

                        bool isOverdueMoreThan30Days = book.BookLoans.Any(loan =>
                            loan.ReturnDate == null &&
                            (currentDate.DayNumber - loan.LoanDate.DayNumber) > 30);

                        if (book.AvailableCopies == 0)
                        {
                            currentRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
                        }
                        else if (isOverdueMoreThan30Days)
                        {
                            currentRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                        }
                        else if (book.AvailableCopies >= 1 && book.AvailableCopies <= 2)
                        {
                            currentRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        }
                        else
                        {
                            currentRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        }
                    }

                    lblCount.Text = $"Отображено: {booksList.Count} из {_totalBooksCount}";
                    dgvBooks.ClearSelection();
                    dgvBooks.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки каталога: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadBookCover(string? imagePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    string fullPath = Path.Combine(Application.StartupPath, "Images", imagePath);
                    if (File.Exists(fullPath)) return Image.FromFile(fullPath);
                }

                string placeholder = Path.Combine(Application.StartupPath, "Images", "book_placeholder.jpeg");
                if (File.Exists(placeholder)) return Image.FromFile(placeholder);
            }
            catch { }

            Bitmap fallback = new Bitmap(110, 140);
            using (Graphics g = Graphics.FromImage(fallback))
            {
                g.Clear(ColorTranslator.FromHtml("#F0F8FF"));
                g.DrawRectangle(Pens.Gray, 0, 0, 109, 139);
                g.DrawString("book_placeholder", new Font("Times New Roman", 9), Brushes.DimGray, 8, 60);
            }
            return fallback;
        }
    }
}
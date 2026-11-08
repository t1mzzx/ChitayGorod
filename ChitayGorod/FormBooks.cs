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
        public FormBooks()
        {
            InitializeComponent();
            ApplyCustomStyles();
            BindEvents();
            LoadGenresFilter();
            SetupSorting();
            LoadBooksList();
        }

        private void BindEvents()
        {
            tbSearch.TextChanged -= tbSearch_TextChanged;
            tbSearch.TextChanged += tbSearch_TextChanged;

            cbGenreFilter.SelectedIndexChanged -= cbGenreFilter_SelectedIndexChanged;
            cbGenreFilter.SelectedIndexChanged += cbGenreFilter_SelectedIndexChanged;

            cbSort.SelectedIndexChanged -= cbSort_SelectedIndexChanged;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
        }

        private void ApplyCustomStyles()
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            this.Font = new Font("Times New Roman", 10.5f);

            panelHeader.BackColor = ColorTranslator.FromHtml("#F0F8FF");

            btnAddBook.BackColor = ColorTranslator.FromHtml("#4A6FA5");
            btnAddBook.ForeColor = Color.White;
            btnAddBook.FlatStyle = FlatStyle.Flat;

            btnIssueBook.BackColor = ColorTranslator.FromHtml("#4A6FA5");
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.FlatStyle = FlatStyle.Flat;

            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.FixedSingle;
            dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBooks.GridColor = Color.LightGray;
            dgvBooks.ColumnHeadersVisible = false;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.RowTemplate.Height = 145;
        }

        private void LoadGenresFilter()
        {
            using var db = new LibraryContext();
            var genres = db.Genres.OrderBy(g => g.GenreName).ToList();

            genres.Insert(0, new Genre { GenreId = 0, GenreName = "Все жанры" });

            cbGenreFilter.DisplayMember = "GenreName";
            cbGenreFilter.ValueMember = "GenreId";
            cbGenreFilter.DataSource = genres;
            cbGenreFilter.SelectedIndex = 0;
        }

        private void SetupSorting()
        {
            cbSort.Items.Clear();
            cbSort.Items.Add("Без сортировки");
            cbSort.Items.Add("По возрастанию остатка");
            cbSort.Items.Add("По убыванию остатка");
            cbSort.SelectedIndex = 0;
        }

        private void LoadBooksList()
        {
            if (dgvBooks.Columns.Count == 0)
            {
                var colCover = new DataGridViewImageColumn
                {
                    Name = "colCover",
                    Width = 120,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };

                var colInfo = new DataGridViewTextBoxColumn
                {
                    Name = "colInfo",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                var colCopies = new DataGridViewTextBoxColumn
                {
                    Name = "colCopies",
                    Width = 200
                };
                colCopies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                colCopies.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBooks.Columns.AddRange(colCover, colInfo, colCopies);
            }

            dgvBooks.Rows.Clear();

            using var db = new LibraryContext();

            var query = db.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.BookLoans)
                .AsQueryable();

            int totalCount = query.Count();

            if (cbGenreFilter.SelectedItem is Genre selectedGenre && selectedGenre.GenreId > 0)
            {
                query = query.Where(b => b.GenreId == selectedGenre.GenreId);
            }

            string search = tbSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => b.Title.ToLower().Contains(search) ||
                                         (b.Author != null && b.Author.AuthorName.ToLower().Contains(search)));
            }

            if (cbSort.SelectedIndex == 1)
            {
                query = query.OrderBy(b => b.AvailableCopies);
            }
            else if (cbSort.SelectedIndex == 2)
            {
                query = query.OrderByDescending(b => b.AvailableCopies);
            }
            else
            {
                query = query.OrderBy(b => b.BookId);
            }

            var books = query.ToList();
            DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);

            foreach (var book in books)
            {
                Image coverImg = GetBookCover(book.CoverImage);

                string authorName = book.Author?.AuthorName ?? "Не указан";
                string genreName = book.Genre?.GenreName ?? "Не указан";
                string publisherName = book.Publisher?.PublisherName ?? "Не указано";
                string isbn = string.IsNullOrWhiteSpace(book.Isbn) ? "Не указан" : book.Isbn;

                string bookInfo = $"Название книги: {book.Title}\n" +
                                  $"Автор: {authorName}\n" +
                                  $"Жанр: {genreName}\n" +
                                  $"Издательство: {publisherName} | Год издания: {book.PublicationYear} | Страниц: {book.Pages}\n" +
                                  $"ISBN: {isbn}\n" +
                                  $"Аннотация: {book.Annotation ?? "Отсутствует"}";

                string copiesInfo = $"Всего экземпляров: {book.TotalCopies}\n" +
                                    $"Доступно: {book.AvailableCopies}";

                int rowIndex = dgvBooks.Rows.Add(coverImg, bookInfo, copiesInfo);
                dgvBooks.Rows[rowIndex].Tag = book;

                // Проверка: есть ли невозвращенная выдача более 30 дней назад
                bool hasOverdueLoan = book.BookLoans != null && book.BookLoans.Any(l =>
                    l.ReturnDate == null && l.LoanDate <= DateOnly.FromDateTime(thirtyDaysAgo));

                if (hasOverdueLoan)
                {
                    // Долгосрочная выдача (>30 дней): светло-зеленый
                    dgvBooks.Rows[rowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                }
                else if (book.AvailableCopies <= 0)
                {
                    // Нет в наличии (0 экз.): светло-красный
                    dgvBooks.Rows[rowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
                }
                else if (book.AvailableCopies <= 2)
                {
                    // Мало экземпляров (1-2 экз.): светло-желтый
                    dgvBooks.Rows[rowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                }
                else
                {
                    // Обычные строки
                    dgvBooks.Rows[rowIndex].DefaultCellStyle.BackColor = (rowIndex % 2 == 0)
                        ? Color.White
                        : ColorTranslator.FromHtml("#FFF8F0");
                }
            }

            lblCount.Text = $"Отображено: {books.Count} из {totalCount}";
        }

        private Image GetBookCover(string? fileName)
        {
            string placeholderPng = Path.Combine(Application.StartupPath, "Images", "book_placeholder.png");
            string placeholderJpeg = Path.Combine(Application.StartupPath, "Images", "book_placeholder.jpeg");

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string fullPath = Path.Combine(Application.StartupPath, "Images", fileName);
                if (File.Exists(fullPath))
                {
                    using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                    return Image.FromStream(stream);
                }
            }

            string validPlaceholder = File.Exists(placeholderPng) ? placeholderPng : placeholderJpeg;
            if (File.Exists(validPlaceholder))
            {
                using var stream = new FileStream(validPlaceholder, FileMode.Open, FileAccess.Read);
                return Image.FromStream(stream);
            }

            return new Bitmap(100, 140);
        }

        private void tbSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadBooksList();
        }

        private void cbGenreFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadBooksList();
        }

        private void cbSort_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadBooksList();
        }

        private void btnAddBook_Click(object? sender, EventArgs e)
        {
            using (var form = new FormAddEditBook())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooksList();
                }
            }
        }

        private void btnIssueBook_Click(object? sender, EventArgs e)
        {
            using (var form = new FormIssueBook())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooksList();
                }
            }
        }

        private void dgvBooks_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBooks.Rows[e.RowIndex].Tag is Book selectedBook)
            {
                using (var form = new FormAddEditBook(selectedBook))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadBooksList();
                    }
                }
            }
        }
    }
}
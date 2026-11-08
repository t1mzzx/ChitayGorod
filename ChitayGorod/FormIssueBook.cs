using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ChitayGorod.Models;

namespace ChitayGorod
{
    public partial class FormIssueBook : Form
    {
        public FormIssueBook()
        {
            InitializeComponent();
            ApplyStyles();
            LoadData();
        }

        private void ApplyStyles()
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            this.Font = new Font("Times New Roman", 11f);
            btnIssue.BackColor = ColorTranslator.FromHtml("#4A6FA5");
            btnCancel.BackColor = ColorTranslator.FromHtml("#F0F8FF");

            dtpIssueDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(14); // Стандартный абонемент на 2 недели
        }

        private void LoadData()
        {
            using var db = new LibraryContext();

            var users = db.LibraryUsers
                .OrderBy(u => u.LastName)
                .Select(u => new
                {
                    u.UserId,
                    DisplayText = $"{u.LastName} {u.FirstName} {u.Patronymic} (Билет: {u.LibraryCardNumber})"
                })
                .ToList();

            cbUser.DataSource = users;
            cbUser.DisplayMember = "DisplayText";
            cbUser.ValueMember = "UserId";

            var availableBooks = db.Books
                .Where(b => b.AvailableCopies > 0)
                .OrderBy(b => b.Title)
                .Select(b => new { b.BookId, b.Title, b.AvailableCopies })
                .ToList();

            cbBook.DataSource = availableBooks;
            cbBook.DisplayMember = "Title";
            cbBook.ValueMember = "BookId";

            UpdateAvailableLabel();
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAvailableLabel();
        }

        private void UpdateAvailableLabel()
        {
            if (cbBook.SelectedItem != null)
            {
                dynamic selected = cbBook.SelectedItem;
                lblAvailableCopies.Text = $"Доступно экземпляров: {selected.AvailableCopies}";
                lblAvailableCopies.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblAvailableCopies.Text = "Нет доступных книг для выдачи";
                lblAvailableCopies.ForeColor = Color.Red;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (cbUser.SelectedValue == null || cbBook.SelectedValue == null)
            {
                MessageBox.Show("Выберите читателя и книгу из списка.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserId = (int)cbUser.SelectedValue;
            int selectedBookId = (int)cbBook.SelectedValue;

            try
            {
                using var db = new LibraryContext();

                var book = db.Books.FirstOrDefault(b => b.BookId == selectedBookId);
                if (book == null || book.AvailableCopies <= 0)
                {
                    MessageBox.Show("Данной книги нет в наличии.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
                    return;
                }

                book.AvailableCopies--;

                var loan = new BookLoan
                {
                    UserId = selectedUserId,
                    BookId = selectedBookId,
                    LoanDate = DateOnly.FromDateTime(dtpIssueDate.Value),
                    DueDate = DateOnly.FromDateTime(dtpDueDate.Value),
                    ReturnDate = null,
                    LoanStatusId = 1
                };

                db.BookLoans.Add(loan);
                db.SaveChanges();

                MessageBox.Show("Книга успешно выдана читателю!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления выдачи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
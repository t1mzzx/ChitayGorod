namespace ChitayGorod
{
    partial class FormBooks
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnIssueBook = new Button();
            btnAddBook = new Button();
            pbLogo = new PictureBox();
            dgvBooks = new DataGridView();
            panelFilter = new Panel();
            tbSearch = new TextBox();
            cbGenreFilter = new ComboBox();
            cbSort = new ComboBox();
            label1 = new Label();
            lblCount = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.AliceBlue;
            panelHeader.Controls.Add(btnIssueBook);
            panelHeader.Controls.Add(btnAddBook);
            panelHeader.Controls.Add(pbLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1084, 85);
            panelHeader.TabIndex = 0;
            // 
            // btnIssueBook
            // 
            btnIssueBook.BackColor = Color.FromArgb(74, 111, 165);
            btnIssueBook.FlatStyle = FlatStyle.Flat;
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.Location = new Point(290, 25);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(160, 35);
            btnIssueBook.TabIndex = 2;
            btnIssueBook.Text = "Выдать книгу";
            btnIssueBook.UseVisualStyleBackColor = false;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.FromArgb(74, 111, 165);
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(110, 25);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(160, 35);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = false;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.Читай_город;
            pbLogo.Location = new Point(10, 8);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(70, 70);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = Color.AliceBlue;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(0, 85);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.Size = new Size(1084, 576);
            dgvBooks.TabIndex = 1;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(lblCount);
            panelFilter.Controls.Add(label1);
            panelFilter.Controls.Add(cbSort);
            panelFilter.Controls.Add(cbGenreFilter);
            panelFilter.Controls.Add(tbSearch);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 85);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1084, 50);
            panelFilter.TabIndex = 2;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(15, 12);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Поиск по названию или автору...";
            tbSearch.Size = new Size(240, 25);
            tbSearch.TabIndex = 0;
            // 
            // cbGenreFilter
            // 
            cbGenreFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenreFilter.FormattingEnabled = true;
            cbGenreFilter.Location = new Point(270, 12);
            cbGenreFilter.Name = "cbGenreFilter";
            cbGenreFilter.Size = new Size(180, 25);
            cbGenreFilter.TabIndex = 1;
            // 
            // cbSort
            // 
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(465, 12);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(220, 25);
            cbSort.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(473, 20);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.FromArgb(74, 111, 165);
            lblCount.Location = new Point(710, 16);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(142, 17);
            lblCount.TabIndex = 4;
            lblCount.Text = "Отображено: 0 из 0";
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 661);
            Controls.Add(panelFilter);
            Controls.Add(dgvBooks);
            Controls.Add(panelHeader);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог книг — Читай-город";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pbLogo;
        private Button btnIssueBook;
        private Button btnAddBook;
        private DataGridView dgvBooks;
        private Panel panelFilter;
        private TextBox tbSearch;
        private Label lblCount;
        private Label label1;
        private ComboBox cbSort;
        private ComboBox cbGenreFilter;
    }
}

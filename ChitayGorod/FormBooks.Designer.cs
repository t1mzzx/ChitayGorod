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
            pbLogo = new PictureBox();
            btnAddBook = new Button();
            btnIssueBook = new Button();
            dgvBooks = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
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
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 661);
            Controls.Add(dgvBooks);
            Controls.Add(panelHeader);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог книг — Читай-город";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pbLogo;
        private Button btnIssueBook;
        private Button btnAddBook;
        private DataGridView dgvBooks;
    }
}

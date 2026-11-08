namespace ChitayGorod
{
    partial class FormAddEditBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditBook));
            label1 = new Label();
            tbTitle = new TextBox();
            label2 = new Label();
            cbAuthor = new ComboBox();
            label3 = new Label();
            cbGenre = new ComboBox();
            label4 = new Label();
            cbPublisher = new ComboBox();
            label5 = new Label();
            numYear = new NumericUpDown();
            label6 = new Label();
            numPages = new NumericUpDown();
            label7 = new Label();
            numTotalCopies = new NumericUpDown();
            lblAnnotation = new Label();
            tbAnnotation = new TextBox();
            pbCover = new PictureBox();
            btnSelectCover = new Button();
            btnClearCover = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCover).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(20, 45);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(350, 25);
            tbTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 2;
            label2.Text = "Автор:";
            // 
            // cbAuthor
            // 
            cbAuthor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(20, 105);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(350, 25);
            cbAuthor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 140);
            label3.Name = "label3";
            label3.Size = new Size(45, 17);
            label3.TabIndex = 4;
            label3.Text = "Жанр:";
            // 
            // cbGenre
            // 
            cbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(20, 165);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(350, 25);
            cbGenre.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 200);
            label4.Name = "label4";
            label4.Size = new Size(99, 17);
            label4.TabIndex = 6;
            label4.Text = "Издательство:";
            // 
            // cbPublisher
            // 
            cbPublisher.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPublisher.FormattingEnabled = true;
            cbPublisher.Location = new Point(20, 225);
            cbPublisher.Name = "cbPublisher";
            cbPublisher.Size = new Size(350, 25);
            cbPublisher.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 260);
            label5.Name = "label5";
            label5.Size = new Size(34, 17);
            label5.TabIndex = 8;
            label5.Text = "Год:";
            // 
            // numYear
            // 
            numYear.Location = new Point(20, 285);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(100, 25);
            numYear.TabIndex = 9;
            numYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(145, 260);
            label6.Name = "label6";
            label6.Size = new Size(63, 17);
            label6.TabIndex = 10;
            label6.Text = "Страниц:";
            // 
            // numPages
            // 
            numPages.Location = new Point(145, 285);
            numPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPages.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPages.Name = "numPages";
            numPages.Size = new Size(100, 25);
            numPages.TabIndex = 11;
            numPages.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(270, 260);
            label7.Name = "label7";
            label7.Size = new Size(84, 17);
            label7.TabIndex = 12;
            label7.Text = "Количество:";
            // 
            // numTotalCopies
            // 
            numTotalCopies.Location = new Point(270, 285);
            numTotalCopies.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numTotalCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTotalCopies.Name = "numTotalCopies";
            numTotalCopies.Size = new Size(100, 25);
            numTotalCopies.TabIndex = 13;
            numTotalCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblAnnotation
            // 
            lblAnnotation.AutoSize = true;
            lblAnnotation.Location = new Point(20, 325);
            lblAnnotation.Name = "lblAnnotation";
            lblAnnotation.Size = new Size(78, 17);
            lblAnnotation.TabIndex = 14;
            lblAnnotation.Text = "Аннотация:";
            // 
            // tbAnnotation
            // 
            tbAnnotation.Location = new Point(20, 350);
            tbAnnotation.Multiline = true;
            tbAnnotation.Name = "tbAnnotation";
            tbAnnotation.ScrollBars = ScrollBars.Vertical;
            tbAnnotation.Size = new Size(350, 180);
            tbAnnotation.TabIndex = 15;
            // 
            // pbCover
            // 
            pbCover.BorderStyle = BorderStyle.FixedSingle;
            pbCover.Location = new Point(420, 45);
            pbCover.Name = "pbCover";
            pbCover.Size = new Size(240, 300);
            pbCover.SizeMode = PictureBoxSizeMode.Zoom;
            pbCover.TabIndex = 16;
            pbCover.TabStop = false;
            // 
            // btnSelectCover
            // 
            btnSelectCover.BackColor = Color.AliceBlue;
            btnSelectCover.Location = new Point(420, 360);
            btnSelectCover.Name = "btnSelectCover";
            btnSelectCover.Size = new Size(240, 35);
            btnSelectCover.TabIndex = 17;
            btnSelectCover.Text = "Выбрать обложку";
            btnSelectCover.UseVisualStyleBackColor = false;
            btnSelectCover.Click += btnSelectCover_Click;
            // 
            // btnClearCover
            // 
            btnClearCover.Location = new Point(420, 405);
            btnClearCover.Name = "btnClearCover";
            btnClearCover.Size = new Size(240, 35);
            btnClearCover.TabIndex = 18;
            btnClearCover.Text = "Удалить обложку";
            btnClearCover.UseVisualStyleBackColor = true;
            btnClearCover.Click += btnClearCover_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(74, 111, 165);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(380, 545);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 19;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.AliceBlue;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(535, 545);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 40);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormAddEditBook
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(704, 601);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClearCover);
            Controls.Add(btnSelectCover);
            Controls.Add(pbCover);
            Controls.Add(tbAnnotation);
            Controls.Add(lblAnnotation);
            Controls.Add(numTotalCopies);
            Controls.Add(label7);
            Controls.Add(numPages);
            Controls.Add(label6);
            Controls.Add(numYear);
            Controls.Add(label5);
            Controls.Add(cbPublisher);
            Controls.Add(label4);
            Controls.Add(cbGenre);
            Controls.Add(label3);
            Controls.Add(cbAuthor);
            Controls.Add(label2);
            Controls.Add(tbTitle);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAddEditBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление книги";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbTitle;
        private Label label2;
        private ComboBox cbAuthor;
        private Label label3;
        private ComboBox cbGenre;
        private Label label4;
        private ComboBox cbPublisher;
        private Label label5;
        private NumericUpDown numYear;
        private Label label6;
        private NumericUpDown numPages;
        private Label label7;
        private NumericUpDown numTotalCopies;
        private Label lblAnnotation;
        private TextBox tbAnnotation;
        private PictureBox pbCover;
        private Button btnSelectCover;
        private Button btnClearCover;
        private Button btnSave;
        private Button btnCancel;
    }
}
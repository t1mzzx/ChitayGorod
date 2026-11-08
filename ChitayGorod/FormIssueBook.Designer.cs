namespace ChitayGorod
{
    partial class FormIssueBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIssueBook));
            label1 = new Label();
            cbUser = new ComboBox();
            label2 = new Label();
            cbBook = new ComboBox();
            lblAvailableCopies = new Label();
            label3 = new Label();
            dtpIssueDate = new DateTimePicker();
            label4 = new Label();
            dtpDueDate = new DateTimePicker();
            btnIssue = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 0;
            label1.Text = "Читатель:";
            // 
            // cbUser
            // 
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(25, 45);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(450, 25);
            cbUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 85);
            label2.Name = "label2";
            label2.Size = new Size(124, 17);
            label2.TabIndex = 2;
            label2.Text = "Книга для выдачи:";
            // 
            // cbBook
            // 
            cbBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBook.FormattingEnabled = true;
            cbBook.Location = new Point(25, 110);
            cbBook.Name = "cbBook";
            cbBook.Size = new Size(450, 25);
            cbBook.TabIndex = 3;
            // 
            // lblAvailableCopies
            // 
            lblAvailableCopies.AutoSize = true;
            lblAvailableCopies.ForeColor = Color.Gray;
            lblAvailableCopies.Location = new Point(25, 145);
            lblAvailableCopies.Name = "lblAvailableCopies";
            lblAvailableCopies.Size = new Size(171, 17);
            lblAvailableCopies.TabIndex = 4;
            lblAvailableCopies.Text = "Доступно экземпляров: —";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 180);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 5;
            label3.Text = "Дата выдачи:";
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(25, 205);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(210, 25);
            dtpIssueDate.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 180);
            label4.Name = "label4";
            label4.Size = new Size(165, 17);
            label4.TabIndex = 7;
            label4.Text = "Плановый срок возврата:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(265, 205);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(210, 25);
            dtpDueDate.TabIndex = 8;
            // 
            // btnIssue
            // 
            btnIssue.BackColor = Color.FromArgb(74, 111, 165);
            btnIssue.FlatStyle = FlatStyle.Flat;
            btnIssue.ForeColor = Color.White;
            btnIssue.Location = new Point(180, 370);
            btnIssue.Name = "btnIssue";
            btnIssue.Size = new Size(160, 40);
            btnIssue.TabIndex = 9;
            btnIssue.Text = "Оформить выдачу";
            btnIssue.UseVisualStyleBackColor = false;
            btnIssue.Click += btnIssue_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.AliceBlue;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(355, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormIssueBook
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(504, 441);
            Controls.Add(btnCancel);
            Controls.Add(btnIssue);
            Controls.Add(dtpDueDate);
            Controls.Add(label4);
            Controls.Add(dtpIssueDate);
            Controls.Add(label3);
            Controls.Add(lblAvailableCopies);
            Controls.Add(cbBook);
            Controls.Add(label2);
            Controls.Add(cbUser);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormIssueBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Выдача книги читателю";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbUser;
        private Label label2;
        private ComboBox cbBook;
        private Label lblAvailableCopies;
        private Label label3;
        private DateTimePicker dtpIssueDate;
        private Label label4;
        private DateTimePicker dtpDueDate;
        private Button btnIssue;
        private Button btnCancel;
    }
}
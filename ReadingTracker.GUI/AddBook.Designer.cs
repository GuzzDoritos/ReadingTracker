namespace ReadingTracker.GUI
{
    partial class AddBook
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
            txtName = new TextBox();
            saveBookBtn = new Button();
            lblBookName = new Label();
            txtAuthor = new TextBox();
            lblAuthorName = new Label();
            txtTotalChars = new TextBox();
            lblTotalChars = new Label();
            lblGenre = new Label();
            comboBoxGenre = new ComboBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // saveBookBtn
            // 
            saveBookBtn.Location = new Point(103, 161);
            saveBookBtn.Name = "saveBookBtn";
            saveBookBtn.Size = new Size(75, 23);
            saveBookBtn.TabIndex = 4;
            saveBookBtn.Text = "OK";
            saveBookBtn.UseVisualStyleBackColor = true;
            saveBookBtn.Click += saveBookBtn_Click;
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.Location = new Point(90, 34);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(37, 15);
            lblBookName.TabIndex = 2;
            lblBookName.Text = "Título";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(140, 60);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(100, 23);
            txtAuthor.TabIndex = 1;
            // 
            // lblAuthorName
            // 
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(90, 63);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(37, 15);
            lblAuthorName.TabIndex = 2;
            lblAuthorName.Text = "Autor";
            // 
            // txtTotalChars
            // 
            txtTotalChars.Location = new Point(140, 89);
            txtTotalChars.Name = "txtTotalChars";
            txtTotalChars.Size = new Size(100, 23);
            txtTotalChars.TabIndex = 2;
            // 
            // lblTotalChars
            // 
            lblTotalChars.AutoSize = true;
            lblTotalChars.Location = new Point(37, 92);
            lblTotalChars.Name = "lblTotalChars";
            lblTotalChars.Size = new Size(90, 15);
            lblTotalChars.TabIndex = 2;
            lblTotalChars.Text = "Total Caracteres";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(82, 126);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(45, 15);
            lblGenre.TabIndex = 2;
            lblGenre.Text = "Gênero";
            // 
            // comboBoxGenre
            // 
            comboBoxGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGenre.FormattingEnabled = true;
            comboBoxGenre.Location = new Point(140, 118);
            comboBoxGenre.Name = "comboBoxGenre";
            comboBoxGenre.Size = new Size(100, 23);
            comboBoxGenre.TabIndex = 3;
            // 
            // AddBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 217);
            Controls.Add(lblGenre);
            Controls.Add(lblTotalChars);
            Controls.Add(lblAuthorName);
            Controls.Add(lblBookName);
            Controls.Add(txtName);
            Controls.Add(txtAuthor);
            Controls.Add(txtTotalChars);
            Controls.Add(comboBoxGenre);
            Controls.Add(saveBookBtn);
            Name = "AddBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Livro";
            Load += AddBook_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button saveBookBtn;
        private Label lblBookName;
        private TextBox txtAuthor;
        private Label lblAuthorName;
        private TextBox txtTotalChars;
        private Label lblTotalChars;
        private Label lblGenre;
        private ComboBox comboBoxGenre;
    }
}
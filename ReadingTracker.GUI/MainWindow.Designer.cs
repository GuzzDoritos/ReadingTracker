namespace ReadingTracker.GUI
{
    partial class MainWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            bookBindingSource = new BindingSource(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvBooks = new DataGridView();
            bookIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            authorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookGenreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalCharsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCompletedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            tabPage2 = new TabPage();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Core.Data.Book);
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(865, 542);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvBooks);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(857, 514);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { bookIDDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, authorDataGridViewTextBoxColumn, bookGenreDataGridViewTextBoxColumn, totalCharsDataGridViewTextBoxColumn, isCompletedDataGridViewCheckBoxColumn });
            dgvBooks.DataSource = bookBindingSource;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.Size = new Size(851, 508);
            dgvBooks.TabIndex = 0;
            // 
            // bookIDDataGridViewTextBoxColumn
            // 
            bookIDDataGridViewTextBoxColumn.DataPropertyName = "BookID";
            bookIDDataGridViewTextBoxColumn.HeaderText = "BookID";
            bookIDDataGridViewTextBoxColumn.Name = "bookIDDataGridViewTextBoxColumn";
            bookIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            authorDataGridViewTextBoxColumn.HeaderText = "Author";
            authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            authorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookGenreDataGridViewTextBoxColumn
            // 
            bookGenreDataGridViewTextBoxColumn.DataPropertyName = "BookGenre";
            bookGenreDataGridViewTextBoxColumn.HeaderText = "BookGenre";
            bookGenreDataGridViewTextBoxColumn.Name = "bookGenreDataGridViewTextBoxColumn";
            bookGenreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalCharsDataGridViewTextBoxColumn
            // 
            totalCharsDataGridViewTextBoxColumn.DataPropertyName = "TotalChars";
            totalCharsDataGridViewTextBoxColumn.HeaderText = "TotalChars";
            totalCharsDataGridViewTextBoxColumn.Name = "totalCharsDataGridViewTextBoxColumn";
            totalCharsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCompletedDataGridViewCheckBoxColumn
            // 
            isCompletedDataGridViewCheckBoxColumn.DataPropertyName = "IsCompleted";
            isCompletedDataGridViewCheckBoxColumn.HeaderText = "IsCompleted";
            isCompletedDataGridViewCheckBoxColumn.Name = "isCompletedDataGridViewCheckBoxColumn";
            isCompletedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(857, 514);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(979, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 585);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(979, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 607);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(tabControl1);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Names";
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private BindingSource bookBindingSource;
        private DataGridView dgvBooks;
        private DataGridViewTextBoxColumn bookIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookGenreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalCharsDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCompletedDataGridViewCheckBoxColumn;
        private ToolStripButton toolStripButton1;
    }
}
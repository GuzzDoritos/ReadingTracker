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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            bookBindingSource = new BindingSource(components);
            tabMainTabs = new TabControl();
            Livros = new TabPage();
            gboxBookInfo = new GroupBox();
            lblNome = new Label();
            lblSelectedBook = new Label();
            gboxDias = new GroupBox();
            dgvMiniDays = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            CharsLido = new DataGridViewTextBoxColumn();
            Minutos = new DataGridViewTextBoxColumn();
            miniDaysBindingSource = new BindingSource(components);
            dgvBooks = new DataGridView();
            bookIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            authorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookGenreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalCharsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCompletedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            btnDeleteBook = new Button();
            Dias = new TabPage();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            tabMainTabs.SuspendLayout();
            Livros.SuspendLayout();
            gboxBookInfo.SuspendLayout();
            gboxDias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMiniDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)miniDaysBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            Dias.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Core.Data.Book);
            // 
            // tabMainTabs
            // 
            tabMainTabs.Controls.Add(Livros);
            tabMainTabs.Controls.Add(Dias);
            tabMainTabs.Location = new Point(12, 27);
            tabMainTabs.Name = "tabMainTabs";
            tabMainTabs.SelectedIndex = 0;
            tabMainTabs.Size = new Size(955, 542);
            tabMainTabs.TabIndex = 1;
            // 
            // Livros
            // 
            Livros.Controls.Add(gboxBookInfo);
            Livros.Controls.Add(gboxDias);
            Livros.Controls.Add(dgvBooks);
            Livros.Controls.Add(btnDeleteBook);
            Livros.Location = new Point(4, 24);
            Livros.Name = "Livros";
            Livros.Padding = new Padding(3);
            Livros.Size = new Size(947, 514);
            Livros.TabIndex = 0;
            Livros.Text = "Livros";
            Livros.UseVisualStyleBackColor = true;
            // 
            // gboxBookInfo
            // 
            gboxBookInfo.Controls.Add(lblNome);
            gboxBookInfo.Controls.Add(lblSelectedBook);
            gboxBookInfo.Location = new Point(724, 6);
            gboxBookInfo.Name = "gboxBookInfo";
            gboxBookInfo.Size = new Size(217, 143);
            gboxBookInfo.TabIndex = 9;
            gboxBookInfo.TabStop = false;
            gboxBookInfo.Text = "Informações do Livro";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(6, 19);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 8;
            lblNome.Text = "Nome:";
            // 
            // lblSelectedBook
            // 
            lblSelectedBook.Location = new Point(55, 19);
            lblSelectedBook.Name = "lblSelectedBook";
            lblSelectedBook.Size = new Size(156, 53);
            lblSelectedBook.TabIndex = 4;
            lblSelectedBook.Text = "Nenhum livro selecionado";
            // 
            // gboxDias
            // 
            gboxDias.Controls.Add(dgvMiniDays);
            gboxDias.Location = new Point(724, 155);
            gboxDias.Name = "gboxDias";
            gboxDias.Size = new Size(217, 182);
            gboxDias.TabIndex = 7;
            gboxDias.TabStop = false;
            gboxDias.Text = "Dias";
            // 
            // dgvMiniDays
            // 
            dgvMiniDays.AllowUserToAddRows = false;
            dgvMiniDays.AllowUserToDeleteRows = false;
            dgvMiniDays.AutoGenerateColumns = false;
            dgvMiniDays.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMiniDays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMiniDays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMiniDays.Columns.AddRange(new DataGridViewColumn[] { Date, CharsLido, Minutos });
            dgvMiniDays.DataSource = miniDaysBindingSource;
            dgvMiniDays.Location = new Point(6, 22);
            dgvMiniDays.Name = "dgvMiniDays";
            dgvMiniDays.ReadOnly = true;
            dgvMiniDays.RowHeadersVisible = false;
            dgvMiniDays.RowHeadersWidth = 30;
            dgvMiniDays.RowTemplate.Height = 20;
            dgvMiniDays.Size = new Size(202, 150);
            dgvMiniDays.TabIndex = 5;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Data";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // CharsLido
            // 
            CharsLido.DataPropertyName = "CharsRead";
            CharsLido.HeaderText = "C. Lidos";
            CharsLido.Name = "CharsLido";
            CharsLido.ReadOnly = true;
            // 
            // Minutos
            // 
            Minutos.DataPropertyName = "MinutesRead";
            Minutos.HeaderText = "Minutos";
            Minutos.Name = "Minutos";
            Minutos.ReadOnly = true;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { bookIDDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, authorDataGridViewTextBoxColumn, bookGenreDataGridViewTextBoxColumn, totalCharsDataGridViewTextBoxColumn, isCompletedDataGridViewCheckBoxColumn });
            dgvBooks.DataSource = bookBindingSource;
            dgvBooks.Dock = DockStyle.Left;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.ScrollBars = ScrollBars.None;
            dgvBooks.Size = new Size(715, 508);
            dgvBooks.TabIndex = 0;
            dgvBooks.CellMouseClick += dgvBooks_CellMouseClick;
            // 
            // bookIDDataGridViewTextBoxColumn
            // 
            bookIDDataGridViewTextBoxColumn.DataPropertyName = "BookID";
            bookIDDataGridViewTextBoxColumn.HeaderText = "ID";
            bookIDDataGridViewTextBoxColumn.Name = "bookIDDataGridViewTextBoxColumn";
            bookIDDataGridViewTextBoxColumn.ReadOnly = true;
            bookIDDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            bookIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Título";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 240;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            authorDataGridViewTextBoxColumn.HeaderText = "Autor";
            authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            authorDataGridViewTextBoxColumn.ReadOnly = true;
            authorDataGridViewTextBoxColumn.Width = 106;
            // 
            // bookGenreDataGridViewTextBoxColumn
            // 
            bookGenreDataGridViewTextBoxColumn.DataPropertyName = "BookGenre";
            bookGenreDataGridViewTextBoxColumn.HeaderText = "Gênero";
            bookGenreDataGridViewTextBoxColumn.Name = "bookGenreDataGridViewTextBoxColumn";
            bookGenreDataGridViewTextBoxColumn.ReadOnly = true;
            bookGenreDataGridViewTextBoxColumn.Width = 105;
            // 
            // totalCharsDataGridViewTextBoxColumn
            // 
            totalCharsDataGridViewTextBoxColumn.DataPropertyName = "TotalChars";
            totalCharsDataGridViewTextBoxColumn.HeaderText = "Caracteres";
            totalCharsDataGridViewTextBoxColumn.Name = "totalCharsDataGridViewTextBoxColumn";
            totalCharsDataGridViewTextBoxColumn.ReadOnly = true;
            totalCharsDataGridViewTextBoxColumn.Width = 106;
            // 
            // isCompletedDataGridViewCheckBoxColumn
            // 
            isCompletedDataGridViewCheckBoxColumn.DataPropertyName = "IsCompleted";
            isCompletedDataGridViewCheckBoxColumn.HeaderText = "Finalizado";
            isCompletedDataGridViewCheckBoxColumn.Name = "isCompletedDataGridViewCheckBoxColumn";
            isCompletedDataGridViewCheckBoxColumn.ReadOnly = true;
            isCompletedDataGridViewCheckBoxColumn.Width = 106;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(730, 343);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(205, 23);
            btnDeleteBook.TabIndex = 6;
            btnDeleteBook.Text = "Deletar";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // Dias
            // 
            Dias.Controls.Add(label1);
            Dias.Controls.Add(dateTimePicker1);
            Dias.Location = new Point(4, 24);
            Dias.Name = "Dias";
            Dias.Padding = new Padding(3);
            Dias.Size = new Size(947, 514);
            Dias.TabIndex = 1;
            Dias.Text = "Dias";
            Dias.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.Font = new Font("MS Mincho", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(398, 259);
            label1.Name = "label1";
            label1.Size = new Size(164, 48);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(420, 6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(100, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
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
            Controls.Add(tabMainTabs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Names";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            tabMainTabs.ResumeLayout(false);
            Livros.ResumeLayout(false);
            gboxBookInfo.ResumeLayout(false);
            gboxBookInfo.PerformLayout();
            gboxDias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMiniDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)miniDaysBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            Dias.ResumeLayout(false);
            Dias.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabMainTabs;
        private TabPage Livros;
        private TabPage Dias;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private BindingSource bookBindingSource;
        private DataGridView dgvBooks;
        private ToolStripButton toolStripButton1;
        private Label lblSelectedBook;
        private DataGridView dgvMiniDays;
        private BindingSource miniDaysBindingSource;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn CharsLido;
        private DataGridViewTextBoxColumn Minutos;
        private Button btnDeleteBook;
        private GroupBox gboxDias;
        private Label lblNome;
        private GroupBox gboxBookInfo;
        private DataGridViewTextBoxColumn bookIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookGenreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalCharsDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCompletedDataGridViewCheckBoxColumn;
        private Label label1;
        private DateTimePicker dateTimePicker1;
    }
}
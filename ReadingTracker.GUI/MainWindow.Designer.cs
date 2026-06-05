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
            lblNoBookSelected = new Label();
            lblIsFinishedInfo = new Label();
            lblAuthorInfo = new Label();
            lblCharsInfo = new Label();
            lblGenreInfo = new Label();
            lblChars = new Label();
            lbIsFinished = new Label();
            lblAuthor = new Label();
            lblGenre = new Label();
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
            dgvTrackedDays = new DataGridView();
            TrackedDate = new DataGridViewTextBoxColumn();
            groupedDaysBindingSource = new BindingSource(components);
            dateDayFilter = new DateTimePicker();
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
            ((System.ComponentModel.ISupportInitialize)dgvTrackedDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupedDaysBindingSource).BeginInit();
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
            gboxBookInfo.Controls.Add(lblNoBookSelected);
            gboxBookInfo.Controls.Add(lblIsFinishedInfo);
            gboxBookInfo.Controls.Add(lblAuthorInfo);
            gboxBookInfo.Controls.Add(lblCharsInfo);
            gboxBookInfo.Controls.Add(lblGenreInfo);
            gboxBookInfo.Controls.Add(lblChars);
            gboxBookInfo.Controls.Add(lbIsFinished);
            gboxBookInfo.Controls.Add(lblAuthor);
            gboxBookInfo.Controls.Add(lblGenre);
            gboxBookInfo.Controls.Add(lblNome);
            gboxBookInfo.Controls.Add(lblSelectedBook);
            gboxBookInfo.Location = new Point(724, 6);
            gboxBookInfo.Name = "gboxBookInfo";
            gboxBookInfo.Size = new Size(217, 143);
            gboxBookInfo.TabIndex = 9;
            gboxBookInfo.TabStop = false;
            gboxBookInfo.Text = "Informações do Livro";
            // 
            // lblNoBookSelected
            // 
            lblNoBookSelected.Location = new Point(30, 33);
            lblNoBookSelected.Name = "lblNoBookSelected";
            lblNoBookSelected.Size = new Size(156, 15);
            lblNoBookSelected.TabIndex = 13;
            lblNoBookSelected.Text = "Nenhum livro selecionado.";
            // 
            // lblIsFinishedInfo
            // 
            lblIsFinishedInfo.Location = new Point(75, 107);
            lblIsFinishedInfo.Name = "lblIsFinishedInfo";
            lblIsFinishedInfo.Size = new Size(133, 15);
            lblIsFinishedInfo.TabIndex = 12;
            // 
            // lblAuthorInfo
            // 
            lblAuthorInfo.Location = new Point(52, 62);
            lblAuthorInfo.Name = "lblAuthorInfo";
            lblAuthorInfo.Size = new Size(156, 15);
            lblAuthorInfo.TabIndex = 11;
            // 
            // lblCharsInfo
            // 
            lblCharsInfo.Location = new Point(75, 92);
            lblCharsInfo.Name = "lblCharsInfo";
            lblCharsInfo.Size = new Size(133, 15);
            lblCharsInfo.TabIndex = 11;
            // 
            // lblGenreInfo
            // 
            lblGenreInfo.Location = new Point(55, 77);
            lblGenreInfo.Name = "lblGenreInfo";
            lblGenreInfo.Size = new Size(156, 15);
            lblGenreInfo.TabIndex = 11;
            // 
            // lblChars
            // 
            lblChars.AutoSize = true;
            lblChars.Location = new Point(6, 92);
            lblChars.Name = "lblChars";
            lblChars.Size = new Size(65, 15);
            lblChars.TabIndex = 10;
            lblChars.Text = "Caracteres:";
            // 
            // lbIsFinished
            // 
            lbIsFinished.AutoSize = true;
            lbIsFinished.Location = new Point(6, 107);
            lbIsFinished.Name = "lbIsFinished";
            lbIsFinished.Size = new Size(63, 15);
            lbIsFinished.TabIndex = 10;
            lbIsFinished.Text = "Finalizado:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(6, 62);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(40, 15);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Autor:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(6, 77);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(48, 15);
            lblGenre.TabIndex = 9;
            lblGenre.Text = "Gênero:";
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
            lblSelectedBook.Size = new Size(153, 44);
            lblSelectedBook.TabIndex = 14;
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
            dgvMiniDays.AllowUserToResizeColumns = false;
            dgvMiniDays.AllowUserToResizeRows = false;
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
            dgvMiniDays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AllowUserToResizeRows = false;
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.BackgroundColor = SystemColors.Control;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { bookIDDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, authorDataGridViewTextBoxColumn, bookGenreDataGridViewTextBoxColumn, totalCharsDataGridViewTextBoxColumn, isCompletedDataGridViewCheckBoxColumn });
            dgvBooks.DataSource = bookBindingSource;
            dgvBooks.Dock = DockStyle.Left;
            dgvBooks.GridColor = SystemColors.Control;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowTemplate.Height = 20;
            dgvBooks.RowTemplate.ReadOnly = true;
            dgvBooks.ScrollBars = ScrollBars.None;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(715, 508);
            dgvBooks.TabIndex = 0;
            dgvBooks.VirtualMode = true;
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
            Dias.Controls.Add(dgvTrackedDays);
            Dias.Controls.Add(dateDayFilter);
            Dias.Location = new Point(4, 24);
            Dias.Name = "Dias";
            Dias.Padding = new Padding(3);
            Dias.Size = new Size(947, 514);
            Dias.TabIndex = 1;
            Dias.Text = "Dias";
            Dias.UseVisualStyleBackColor = true;
            // 
            // dgvTrackedDays
            // 
            dgvTrackedDays.AutoGenerateColumns = false;
            dgvTrackedDays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrackedDays.Columns.AddRange(new DataGridViewColumn[] { TrackedDate });
            dgvTrackedDays.DataSource = groupedDaysBindingSource;
            dgvTrackedDays.Location = new Point(6, 44);
            dgvTrackedDays.Name = "dgvTrackedDays";
            dgvTrackedDays.Size = new Size(603, 455);
            dgvTrackedDays.TabIndex = 1;
            // 
            // TrackedDate
            // 
            TrackedDate.DataPropertyName = "Date";
            TrackedDate.HeaderText = "Data";
            TrackedDate.Name = "TrackedDate";
            TrackedDate.ReadOnly = true;
            // 
            // dateDayFilter
            // 
            dateDayFilter.CustomFormat = "";
            dateDayFilter.Format = DateTimePickerFormat.Short;
            dateDayFilter.Location = new Point(251, 15);
            dateDayFilter.Name = "dateDayFilter";
            dateDayFilter.Size = new Size(100, 23);
            dateDayFilter.TabIndex = 0;
            dateDayFilter.ValueChanged += dateTimePicker1_ValueChanged;
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
            ((System.ComponentModel.ISupportInitialize)dgvTrackedDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupedDaysBindingSource).EndInit();
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
        private Label lblGenreInfo;
        private DateTimePicker dateDayFilter;
        private DataGridView dgvTrackedDays;
        private BindingSource groupedDaysBindingSource;
        private DataGridViewTextBoxColumn TrackedDate;
        private Label lblChars;
        private Label lbIsFinished;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblIsFinishedInfo;
        private Label lblAuthorInfo;
        private Label lblCharsInfo;
        private Label lblNoBookSelected;
        private Label lblSelectedBook;
    }
}
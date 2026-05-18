using ReadingTracker.Core.Repositories;
using ReadingTracker.Core.Services;
using ReadingTracker.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadingTracker.GUI
{
    public partial class MainWindow : Form

    {
        private ReadingService _service;
        public MainWindow(ReadingService readingService)
        {
            InitializeComponent();
            _service = readingService;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (AddBook popup = new AddBook())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    if (popup.NewBook != null)
                    {
                        _service.AddBook(popup.NewBook);

                        RefreshGrid();
                    }
                }
            }
        }

        private void RefreshGrid()
        {
            bookBindingSource.DataSource = null; // Clear the old cache
            bookBindingSource.DataSource = _service.GetBooks(); // Load the fresh list
        }

        private void dgvBooks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            lblSelectedBook.Text = dgvBooks.Rows[index: e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value?.ToString() ?? "what";
            if (!int.TryParse(dgvBooks.Rows[e.RowIndex].Cells["bookIDDataGridViewTextBoxColumn"].Value?.ToString(), out int bookId))
                return;
            dgvMiniDays.Visible = true;
            miniDaysBindingSource.DataSource = _service.GetDaysFromBookId(bookId);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = _service.GetBooks();
            dgvMiniDays.Visible = false;

        }
    }
}

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
            List<Book> books = _service.GetBooks();
            bookBindingSource.DataSource = books;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            dgvBooks.DataSource = null; // Clear the old cache
            dgvBooks.DataSource = _service.GetBooks(); // Load the fresh list
        }
    }
}

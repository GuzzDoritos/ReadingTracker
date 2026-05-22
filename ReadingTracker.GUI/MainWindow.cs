using ReadingTracker.Core.Data;
using ReadingTracker.Core.Repositories;
using ReadingTracker.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ReadingTracker.GUI
{
    public partial class MainWindow : Form

    {
        private ReadingService _service;
        private int _selectedBookId;
        public MainWindow(ReadingService readingService)
        {
            InitializeComponent();
            _service = readingService;
            _selectedBookId = -1;
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

            btnDeleteBook.Visible = true;
            dgvMiniDays.Visible = true;

            _selectedBookId = bookId;

            miniDaysBindingSource.DataSource = _service.GetDaysFromBookId(bookId);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = _service.GetBooks();
            dgvMiniDays.Visible = false;
            btnDeleteBook.Visible = false;

        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (_selectedBookId != -1)
            {
                var confirmResult = MessageBox.Show("Certeza que deseja deletar este livro?",
                                     "Confirmar deletação",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    _service.RemoveBook(_selectedBookId);
                    lblSelectedBook.Text = "Nenhum livro selecionado.";


                    _selectedBookId = -1;

                    btnDeleteBook.Visible = false;
                    dgvMiniDays.Visible = false;
                    RefreshGrid();
                }
                else
                {
                    return;
                }


            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var result = from day in _service.GetDays()
                         group day by day.Date into groupData
                         select new
                         {
                             Category = groupData.Key,
                             TotalChars = groupData.Sum(x => x.CharsRead),
                             TotalMins = groupData.Sum(x => x.MinutesRead)
                         };

            groupedDaysBindingSource.DataSource = result;
        }
    }
}

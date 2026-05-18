using ReadingTracker.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReadingTracker.GUI
{
    public partial class AddBook : Form
    {
        public Book? NewBook { get; private set; }
        public AddBook()
        {
            InitializeComponent();
        }

        private void saveBookBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string author = txtAuthor.Text;
            int totalChars;
            try
            {
                totalChars = int.Parse(txtTotalChars.Text);
            }
            catch (FormatException)
            {

                MessageBox.Show($"Valor total de caracteres não é um número.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } catch (ArgumentNullException)
            {
                MessageBox.Show($"Valor total de caracteres está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            Genre selectedGenre = (Genre)comboBoxGenre.SelectedItem;

            NewBook = new Book(name, author, selectedGenre, totalChars);

            this.DialogResult = DialogResult.OK;
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            comboBoxGenre.DataSource = Enum.GetValues<Genre>();

        }
    }
}

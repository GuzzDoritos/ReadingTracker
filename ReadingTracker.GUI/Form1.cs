using ReadingTracker.Core.Services;

namespace ReadingTracker.GUI
{
    public partial class Form1 : Form
    {
        private readonly ReadingService _readingService;

        public Form1(ReadingService readingService)
        {
            InitializeComponent();
            _readingService = readingService;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            RefreshBookList();
        }

        private void RefreshBookList()
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            lstBooks.DataSource = null;
            lstBooks.DataSource = _readingService.GetBooks();

            lstBooks.DisplayMember = "Name";

            daysLst.DataSource = null;
            daysLst.DataSource = _readingService.GetDays();

            daysLst.DisplayMember = "Date";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void daysLst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

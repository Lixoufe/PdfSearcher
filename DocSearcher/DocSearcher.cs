using System;
using System.IO;
using System.Windows.Forms;

namespace DocSearcher
{
    public partial class PdfSearcher : Form
    {
        private string folderPath;
        public PdfSearcher()
        {
            InitializeComponent();
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            textBox2.Text = folderPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int temp = Searcher.Search(folderPath, textBox1.Text);
                MessageBox.Show($"Found: {temp}", "Result");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderPath = folderDialog.SelectedPath;
                textBox2.Text = folderPath;
                //Use folder path
            }
        }

        private void inputTextBox_Leave(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox2.Text)) folderPath = textBox2.Text;
        }
    }
}

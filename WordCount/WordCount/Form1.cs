using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCount
{
    public partial class Form1 : Form
    {
        public Form1ViewModel Form1ViewModel { get; set; }
        public Form1()
        {
            InitializeComponent();
            Form1ViewModel = new Form1ViewModel();
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void btnCountWords_Click(object sender, EventArgs e)
        {
            Form1ViewModel.CountWords(textBox1.Text);
            bindingSource1.DataSource = Form1ViewModel.Words;
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}

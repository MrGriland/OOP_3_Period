using Lab2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class SearchForm : Form
    {
        public Form1 searchForm;
        public SearchForm(Form1 form)
        {
            InitializeComponent();
            searchForm = form;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "" && searchTextBox.Text != " ")
            {
                searchForm.textFromInputInSearch = searchTextBox.Text;
                searchForm.controlFlag = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Глупо искать записи по пустой строке/пробелу, попробуй ещё!", "Поиск завершился неудачей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

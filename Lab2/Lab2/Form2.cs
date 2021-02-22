using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool cFlag = false;
                if (
                        textBox1.Text.Length > 0 && comboBox1.Text.Length > 0
                        && textBox2.Text.Length > 0 && textBox3.Text.Length > 0
                    ) cFlag = true;
                if (cFlag)
                {
                    Address address = new Address();
                    address.country = comboBox1.Text;
                    address.city = textBox1.Text;
                    address.district = textBox2.Text;
                    address.street = textBox3.Text;
                    address.buildingNumber = Convert.ToInt32(numericUpDown1.Value);
                    address.housing = trackBar1.Value;
                    address.flatNumber = Convert.ToInt32(numericUpDown2.Value);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Вы не заполнили все необходимые поля!",
                        "Сообщение об ошибке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in textBox1.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        textBox1.Text = "";
                    }
                }
                
            }
            catch
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in textBox2.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        textBox2.Text = "";
                    }
                }

            }
            catch
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in textBox3.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        textBox3.Text = "";
                    }
                }

            }
            catch
            {
                textBox3.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in comboBox1.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        comboBox1.Text = "";
                    }
                }

            }
            catch
            {
                comboBox1.Text = "";
            }
        }
    }
}

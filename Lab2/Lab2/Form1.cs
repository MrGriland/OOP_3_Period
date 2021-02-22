using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public bool completenessFlag = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int metersValidate = Convert.ToInt32(textBox1.Text);
                if (metersValidate > 250 || metersValidate < 1)
                    throw new Exception();
            }
            catch
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                    MessageBox.Show(
                        "Введите площадь!",
                        "Сообщение об ошибке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                if (Convert.ToInt32(textBox1.Text) < 30)
                {
                    MessageBox.Show(
                        "Слишком малая площадь!",
                        "Сообщение об ошибке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                string price;
                price = (Convert.ToInt32(textBox1.Text) * ((trackBar1.Value * 5) + (Convert.ToInt32(numericUpDown1.Value) * 13) * ((checkedListBox1.CheckedItems.Count + 1) * 0.01))).ToString();
                textBox2.Text = price;
            }
            catch
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    MessageBox.Show(
                        "Введите данные!",
                        "Сообщение об ошибке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                if (Convert.ToInt32(textBox1.Text) < 30)
                {
                    MessageBox.Show(
                        "Слишком малая площадь!",
                        "Сообщение об ошибке",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                if (
                    textBox1.Text.Length > 0 && comboBox1.Text.Length > 0 &&
                    (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked) &&
                    textBox3.Text.Length > 0 && comboBox2.Text.Length > 0
                        && textBox4.Text.Length > 0 && textBox5.Text.Length > 0
                ) completenessFlag = true;
                
                if (completenessFlag)
                {
                    richTextBox1.Text = "";
                    Address address = new Address();
                    address.country = comboBox2.Text;
                    address.city = textBox5.Text;
                    address.district = textBox4.Text;
                    address.street = textBox3.Text;
                    address.buildingNumber = Convert.ToInt32(numericUpDown3.Value);
                    address.housing = trackBar2.Value;
                    address.flatNumber = Convert.ToInt32(numericUpDown2.Value);
                    Flat flat = new Flat();
                    flat.meters = Convert.ToDouble(textBox1.Text);
                    flat.roomsCount = trackBar1.Value;
                    flat.year = Convert.ToInt32(numericUpDown1.Value);
                    flat.floor = Convert.ToInt32(comboBox1.Text);
                    CheckedListBox.CheckedItemCollection items = checkedListBox1.CheckedItems;
                    string option = "";
                    foreach (string name in items)
                    {
                        option += " ";
                        option += name;
                    }
                    flat.options = option;
                    foreach (RadioButton rb in groupBox1.Controls)
                    {
                        if (rb.Checked) flat.material = rb.Text;
                    }
                    richTextBox1.Text = "Метраж: " + flat.meters + " \nКоличество комнат: " + flat.roomsCount + " \nГод постройки: " + flat.year + " \nЭтаж: " + flat.floor + " \nОпции: " + option + " \nМатериал: " + flat.material + " \nСтрана: " + address.country + " \nГород: " + address.city + " \nРайон: " + address.district + " \nУлица: " + address.street + " \nДом: " + address.buildingNumber + " \nКорпус: " + address.housing + " \nКвартира: " + address.flatNumber;
                    string str = richTextBox1.Text;
                    XmlSerializer formatter = new XmlSerializer(typeof(string));
                    using (FileStream fs = new FileStream("infa.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, str);
                    }
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
            catch { }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in textBox5.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        textBox5.Text = "";
                    }
                }

            }
            catch
            {
                textBox5.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in textBox4.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        textBox4.Text = "";
                    }
                }

            }
            catch
            {
                textBox4.Text = "";
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

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (char t in comboBox2.Text)
                {
                    if (t == '1' || t == '2' || t == '3' || t == '4' || t == '5' || t == '6' || t == '7' || t == '8' || t == '9' || t == '0')
                    {
                        comboBox2.Text = "";
                    }
                }

            }
            catch
            {
                comboBox2.Text = "";
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

    }
    public class Address
    {
        public string country;
        public string city;
        public string district;
        public string street;
        public int buildingNumber;
        public int housing;
        public int flatNumber;
    }
    //class Room
    //{
    //    double square;
    //    int windowNumber;
    //    string side;
    //}
    class Flat
    {
        public double meters;
        public int roomsCount;
        public int year;
        public string material;
        public int floor;
        public string options;
        Address address;
        
    }
}

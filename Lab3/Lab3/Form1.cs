using Lab3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public List<HouseForSerialize> tempHouses = new List<HouseForSerialize>();
        public bool completenessFlag = false;
        public bool controlFlag = false;
        public string textFromInputInSearch;
        Timer timer; 
        public Form1()
        {
            InitializeComponent();

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
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
                LastActionLabel.Text = "Рассчитать";
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
                    LastActionLabel.Text = "Сохранить";
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
                    Serialize(flat, address);
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
        public List<HouseForSerialize> Deserialize()
        {
            List<HouseForSerialize> housesForSerialize = new List<HouseForSerialize>();

            XmlSerializer xmlf = new XmlSerializer(housesForSerialize.GetType());

            using (FileStream fs = new FileStream("infa.xml", FileMode.OpenOrCreate))
            {
                housesForSerialize = (List<HouseForSerialize>)xmlf.Deserialize(fs);
            }

            return housesForSerialize;
        }
        public void Serialize(Flat flat, Address address)
        {
            HouseForSerialize serializeMe = new HouseForSerialize(flat, address);
            List<HouseForSerialize> housesForSerialize;
            if (File.Exists("infa.xml")) housesForSerialize = Deserialize();
            else housesForSerialize = new List<HouseForSerialize>();
            housesForSerialize.Add(serializeMe);
            XmlSerializer xmlf = new XmlSerializer(housesForSerialize.GetType());

            using (FileStream fs = new FileStream("infa.xml", FileMode.OpenOrCreate))
            {
                xmlf.Serialize(fs, housesForSerialize);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tempHouses = Deserialize();
            richTextBox1.Text = "";
            LastActionLabel.Text = "Загрузить";
            foreach (HouseForSerialize house in tempHouses)
            {
                richTextBox1.Text += $"" +
                $"Метраж: {house.Flat.meters} \r\n" +
                $"Количество комнат : {house.Flat.roomsCount} \r\n" +
                $"Год постройки: {house.Flat.year} \r\n" +
                $"Этаж: {house.Flat.floor} \r\n" +
                $"Опции: {house.Flat.options} \r\n" +
                $"Материал: {house.Flat.material} \r\n" +
                $"Адрес: \r\n" +
                $"Страна: {house.Address.country} \r\n" +
                $"Город: {house.Address.city} \r\n" +
                $"Район: {house.Address.district} \r\n" +
                $"Улица: {house.Address.street} \r\n" +
                $"Номер дома: {house.Address.buildingNumber} \r\n" +
                $"Корпус: {house.Address.housing} \r\n" +
                $"Номер квартиры: {house.Address.flatNumber} \r\n \r\n \r\n";
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToLongDateString();
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
            ObjectsCountLabel.Text = tempHouses.Count.ToString();
        }
        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastActionLabel.Text = "О программе";
            MessageBox.Show(
                "Version 1.0 ©Булгак Григорий Владимирович",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void searchCountRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HouseForSerialize> outputList = new List<HouseForSerialize>();
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LastActionLabel.Text = "Поиск по количеству комнат";
                SearchForm inputInSearch = new SearchForm(this);
                inputInSearch.ShowDialog();
                Regex regex = new Regex($@"{textFromInputInSearch}(\w*)", RegexOptions.IgnoreCase);
                foreach (HouseForSerialize house in tempHouses)
                {
                    MatchCollection matches = regex.Matches(house.Flat.roomsCount.ToString());
                    if (matches.Count > 0) outputList.Add(house);
                }
                if (outputList.Count == 0)
                {
                    MessageBox.Show("Мы не нашли подобных записей :c", "Поиск завершился неудачей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(controlFlag)
                {
                    richTextBox2.Text = "";
                    foreach (HouseForSerialize house in outputList)
                    {
                        richTextBox2.Text += $"" +
                        $"Метраж: {house.Flat.meters} \r\n" +
                        $"Количество комнат : {house.Flat.roomsCount} \r\n" +
                        $"Год постройки: {house.Flat.year} \r\n" +
                        $"Этаж: {house.Flat.floor} \r\n" +
                        $"Опции: {house.Flat.options} \r\n" +
                        $"Материал: {house.Flat.material} \r\n" +
                        $"Адрес: \r\n" +
                        $"Страна: {house.Address.country} \r\n" +
                        $"Город: {house.Address.city} \r\n" +
                        $"Район: {house.Address.district} \r\n" +
                        $"Улица: {house.Address.street} \r\n" +
                        $"Номер дома: {house.Address.buildingNumber} \r\n" +
                        $"Корпус: {house.Address.housing} \r\n" +
                        $"Номер квартиры: {house.Address.flatNumber} \r\n \r\n \r\n";
                    }
                }
            }

        }

        private void searchYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HouseForSerialize> outputList = new List<HouseForSerialize>();
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LastActionLabel.Text = "Поиск по году";
                SearchForm inputInSearch = new SearchForm(this);
                inputInSearch.ShowDialog();
                Regex regex = new Regex($@"{textFromInputInSearch}(\w*)", RegexOptions.IgnoreCase);
                foreach (HouseForSerialize house in tempHouses)
                {
                    MatchCollection matches = regex.Matches(house.Flat.year.ToString());
                    if (matches.Count > 0) outputList.Add(house);
                }
                if (outputList.Count == 0)
                {
                    MessageBox.Show("Мы не нашли подобных записей :c", "Поиск завершился неудачей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (controlFlag)
                {
                    richTextBox2.Text = "";
                    foreach (HouseForSerialize house in outputList)
                    {
                        richTextBox2.Text += $"" +
                        $"Метраж: {house.Flat.meters} \r\n" +
                        $"Количество комнат : {house.Flat.roomsCount} \r\n" +
                        $"Год постройки: {house.Flat.year} \r\n" +
                        $"Этаж: {house.Flat.floor} \r\n" +
                        $"Опции: {house.Flat.options} \r\n" +
                        $"Материал: {house.Flat.material} \r\n" +
                        $"Адрес: \r\n" +
                        $"Страна: {house.Address.country} \r\n" +
                        $"Город: {house.Address.city} \r\n" +
                        $"Район: {house.Address.district} \r\n" +
                        $"Улица: {house.Address.street} \r\n" +
                        $"Номер дома: {house.Address.buildingNumber} \r\n" +
                        $"Корпус: {house.Address.housing} \r\n" +
                        $"Номер квартиры: {house.Address.flatNumber} \r\n \r\n \r\n";
                    }
                }
            }
        }

        private void searchDistrictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HouseForSerialize> outputList = new List<HouseForSerialize>();
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LastActionLabel.Text = "Поиск по району";
                SearchForm inputInSearch = new SearchForm(this);
                inputInSearch.ShowDialog();
                Regex regex = new Regex($@"{textFromInputInSearch}(\w*)", RegexOptions.IgnoreCase);
                foreach (HouseForSerialize house in tempHouses)
                {
                    MatchCollection matches = regex.Matches(house.Address.district);
                    if (matches.Count > 0) outputList.Add(house);
                }
                if (outputList.Count == 0)
                {
                    MessageBox.Show("Мы не нашли подобных записей :c", "Поиск завершился неудачей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (controlFlag)
                {
                    richTextBox2.Text = "";
                    foreach (HouseForSerialize house in outputList)
                    {
                        richTextBox2.Text += $"" +
                        $"Метраж: {house.Flat.meters} \r\n" +
                        $"Количество комнат : {house.Flat.roomsCount} \r\n" +
                        $"Год постройки: {house.Flat.year} \r\n" +
                        $"Этаж: {house.Flat.floor} \r\n" +
                        $"Опции: {house.Flat.options} \r\n" +
                        $"Материал: {house.Flat.material} \r\n" +
                        $"Адрес: \r\n" +
                        $"Страна: {house.Address.country} \r\n" +
                        $"Город: {house.Address.city} \r\n" +
                        $"Район: {house.Address.district} \r\n" +
                        $"Улица: {house.Address.street} \r\n" +
                        $"Номер дома: {house.Address.buildingNumber} \r\n" +
                        $"Корпус: {house.Address.housing} \r\n" +
                        $"Номер квартиры: {house.Address.flatNumber} \r\n \r\n \r\n";
                    }
                }
            }
        }

        private void searchCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HouseForSerialize> outputList = new List<HouseForSerialize>();
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                LastActionLabel.Text = "Поиск по городу";
                SearchForm inputInSearch = new SearchForm(this);
                inputInSearch.ShowDialog();
                Regex regex = new Regex($@"{textFromInputInSearch}(\w*)", RegexOptions.IgnoreCase);
                foreach (HouseForSerialize house in tempHouses)
                {
                    MatchCollection matches = regex.Matches(house.Address.city);
                    if (matches.Count > 0) outputList.Add(house);
                }
                if (outputList.Count == 0)
                {
                    MessageBox.Show("Мы не нашли подобных записей :c", "Поиск завершился неудачей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (controlFlag)
                {
                    richTextBox2.Text = "";
                    foreach (HouseForSerialize house in outputList)
                    {
                        richTextBox2.Text += $"" +
                        $"Метраж: {house.Flat.meters} \r\n" +
                        $"Количество комнат : {house.Flat.roomsCount} \r\n" +
                        $"Год постройки: {house.Flat.year} \r\n" +
                        $"Этаж: {house.Flat.floor} \r\n" +
                        $"Опции: {house.Flat.options} \r\n" +
                        $"Материал: {house.Flat.material} \r\n" +
                        $"Адрес: \r\n" +
                        $"Страна: {house.Address.country} \r\n" +
                        $"Город: {house.Address.city} \r\n" +
                        $"Район: {house.Address.district} \r\n" +
                        $"Улица: {house.Address.street} \r\n" +
                        $"Номер дома: {house.Address.buildingNumber} \r\n" +
                        $"Корпус: {house.Address.housing} \r\n" +
                        $"Номер квартиры: {house.Address.flatNumber} \r\n \r\n \r\n";
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LastActionLabel.Text = "Сохранить результаты";
        }

        private void sortSquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LastActionLabel.Text = "Сортировка по площади";
        }

        private void sortRoomCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LastActionLabel.Text = "Сортировка по количеству комнат";
        }

        private void sortCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") MessageBox.Show("В памяти не хранятся дисциплины, загрузите данные из XML файла!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LastActionLabel.Text = "Сортировка по стоимости";
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
    [Serializable]
    public class Flat
    {
        public double meters;
        public int roomsCount;
        public int year;
        public string material;
        public int floor;
        public string options;        
    }
    [Serializable]
    public class HouseForSerialize
    {
        public Flat Flat { get; set; }
        public Address Address { get; set; }

        public HouseForSerialize()
        {

        }

        public HouseForSerialize(Flat flat, Address address)
        {
            Flat = flat;
            Address = address;
        }

    }
}

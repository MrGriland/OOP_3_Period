using Lab6_7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : UserControl
    {
        MainWindow mainForm;
        public AddPage(MainWindow mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void CreateAdButton_Click(object sender, RoutedEventArgs e)
        {
            Ad ad = new Ad();
            ad.ID = ad.GetID();
            ad.FullName = AdFullNameTextBox.Text;
            ad.Raiting = Double.Parse(AdRaitingTextBox.Text);
            ad.Cost = Convert.ToDecimal(AdCostTextBox.Text);
            ad.Category = AdCategoryTextBox.Text;
            ad.Amount = Convert.ToInt32(AdAmountTextBox.Text);
            Serialization.Serialize(ad);
            MessageBox.Show(
                "Объявление было успешно добавлено!",
                "Успех!",
                MessageBoxButton.OK,
                MessageBoxImage.None
            );
        }
    }
}

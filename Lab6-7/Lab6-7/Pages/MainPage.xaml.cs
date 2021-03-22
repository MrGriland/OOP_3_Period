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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        MainWindow mainForm;
        public List<AdInGrid> ResultCollection { get; set; }
        public MainPage(MainWindow mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Ad> adList = Serialization.Deserialize();
            ResultCollection = new List<AdInGrid>();
            foreach (var el in adList)
            {
                ResultCollection.Add(new AdInGrid { FullName = el.FullName, ShortName = el.ShortName, Category = el.Category, Raiting = el.Raiting, Cost = el.Cost, Amount = el.Amount, ID = el.ID });
            }
            MainGrid.ItemsSource = ResultCollection;
        }
    }
}

using Lab6_7.Pages;
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

namespace Lab6_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new MainPage(this));
            
        }

        private void CreateAdButton_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new AddPage(this));
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Версия 1.0 ©MrGriland", "О программе", MessageBoxButton.OK);
        }

        private void ButtonPopUpClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

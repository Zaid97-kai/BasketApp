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

namespace BasketApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для VisitorMenu.xaml
    /// </summary>
    public partial class VisitorMenu : Page
    {
        static public MainWindow mainWindow;
        public VisitorMenu()
        {
            InitializeComponent();
            mainWindow.SecondFooterLabelInfo.Content = 2;
        }
        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }

        private void MatchupsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }

        private void PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }

        private void PhotosButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }
    }
}

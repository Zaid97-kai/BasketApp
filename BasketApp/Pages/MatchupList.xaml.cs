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
    /// Логика взаимодействия для MatchupList.xaml
    /// </summary>
    public partial class MatchupList : Page
    {
        public MatchupList()
        {
            InitializeComponent();

            NBAShort_08Entities context = new NBAShort_08Entities();
            ListMatchups.ItemsSource = context.Matchup.ToList();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

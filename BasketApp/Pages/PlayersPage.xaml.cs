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
    /// Логика взаимодействия для PlayersPage.xaml
    /// </summary>
    public partial class PlayersPage : Page
    {
        List<PlayerInTeam> players = new List<PlayerInTeam>();
        /// <summary>
        /// Метод-конструктор класса PlayersPage
        /// </summary>
        public PlayersPage()
        {
            InitializeComponent();
            /*

            NBAShort_08Entities context = new NBAShort_08Entities(); //Создание экземпляра контекста данных NBAShort_08Entities
            
            for (int i = 0; i < 5; i++)
            {
                players.Add(context.Player.ToList()[i]);
            }
            //GridPlayers.ItemsSource = context.Player.ToList(); //Загрузка в GridPlayers данных, хранимых в коллекции Player
            GridPlayers.ItemsSource = players;
            */

            NBAShort_08Entities context = new NBAShort_08Entities();
            GridPlayers.ItemsSource = context.PlayerInTeam.ToList();

            SeasonNames.ItemsSource = context.Season.ToList();
            TeamNames.ItemsSource = context.Team.ToList();
        }
    }
}

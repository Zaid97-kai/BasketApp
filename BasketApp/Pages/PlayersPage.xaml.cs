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
        private List<PlayerInTeam> players = new List<PlayerInTeam>();
        private NBAShort_08Entities context;
        /// <summary>
        /// Метод-конструктор класса PlayersPage
        /// </summary>
        public PlayersPage()
        {
            InitializeComponent();

            //NBAShort_08Entities context = new NBAShort_08Entities(); //Создание экземпляра контекста данных NBAShort_08Entities

            //for (int i = 0; i < 5; i++)
            //{
            //    players.Add(context.Player.ToList()[i]);
            //}
            ////GridPlayers.ItemsSource = context.Player.ToList(); //Загрузка в GridPlayers данных, хранимых в коллекции Player
            //GridPlayers.ItemsSource = players;

            context = new NBAShort_08Entities();
            this.players = context.PlayerInTeam.ToList();

            GridPlayers.ItemsSource = context.PlayerInTeam.ToList();

            SeasonNames.ItemsSource = context.Season.ToList();
            TeamNames.ItemsSource = context.Team.ToList();
            SeasonNames.SelectedIndex = 0;
            TeamNames.SelectedIndex = 0;

            RefreshPlayers();
        }

        private void SeasonNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPlayers();
        }

        private void RefreshPlayers()
        {
            Team selectedTeam = TeamNames.SelectedItem as Team;
            Season selectedSeason = SeasonNames.SelectedItem as Season;
            string searchText = TxtPlayerName.Text;

            this.players = context.PlayerInTeam.ToList();
            players = players.Where(x => x.Season == selectedSeason).ToList();
            players = players.Where(x => x.Team == selectedTeam).ToList();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                players = players.Where(x => x.Player.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }

            //GridPlayers.ItemsSource = null;
            GridPlayers.ItemsSource = players;
        }

        private void TeamNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPlayers();
        }

        private void TxtPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshPlayers();
        }
    }
}

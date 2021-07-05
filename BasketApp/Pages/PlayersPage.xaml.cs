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
        private List<PlayerInTeam> _players = new List<PlayerInTeam>();
        private NBAShort_08Entities _context;

        private int _currentPage = 1;
        private int _countPlayers = 5;
        private int _maxPages;
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

            _context = new NBAShort_08Entities();
            this._players = _context.PlayerInTeam.ToList();

            GridPlayers.ItemsSource = _context.PlayerInTeam.ToList();

            SeasonNames.ItemsSource = _context.Season.OrderByDescending(season => season.Name).ToList();
            TeamNames.ItemsSource = _context.Team.OrderBy(team => team.TeamName).ToList();
            SeasonNames.SelectedIndex = 0;
            TeamNames.SelectedIndex = 0;

            RefreshPlayers();
        }

        private void SeasonNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPlayers();
        }
        /// <summary>
        /// Обновление списка пользователей
        /// </summary>
        private void RefreshPlayers()
        {
            Team selectedTeam = TeamNames.SelectedItem as Team;
            Season selectedSeason = SeasonNames.SelectedItem as Season;
            string searchText = TxtPlayerName.Text;

            this._players = _context.PlayerInTeam.ToList();
            _players = _players.Where(x => x.Season == selectedSeason).ToList(); //фильтрация по сезонам
            _players = _players.Where(x => x.Team == selectedTeam).ToList(); //фильтрация по командам
            if (!string.IsNullOrWhiteSpace(searchText)) //проверка на отсутствие пробелов
            {
                _players = _players.Where(x => x.Player.Name.ToLower().Contains(searchText.ToLower())).ToList(); //фильтрация по имени игрока
            }

            //GridPlayers.ItemsSource = null;
            _players = _players.OrderBy(players => players.ShirtNumber).ToList(); //сортировка игроков по номеру футболки

            _maxPages = Convert.ToInt32(Math.Ceiling(_players.Count * 1.0 / _countPlayers)); //определение максимального количества страниц
            var listPlayersInPage = _players.Skip((_currentPage - 1) * _countPlayers).Take(_countPlayers).ToList(); //создание списка игроков для размещения в одной таблице
            //players = players.GetRange((_currentPage - 1) * _countPlayers, _countPlayers);

            TxtCurrentPageNumber.Text = _currentPage.ToString();
            LblTotalPages.Content = "of " + _maxPages;
            LblPlayersInfo.Content = $"Total {_players.Count} records, {_countPlayers} records in one page";

            GridPlayers.ItemsSource = listPlayersInPage;
        }

        private void TeamNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPlayers();
        }

        private void TxtPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshPlayers();
        }
        /// <summary>
        /// Переход на последнюю страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPages;
            RefreshPlayers();
        }
        /// <summary>
        /// Переход на следующую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage + 1 > _maxPages)
            {
                return;
            }
            _currentPage++;
            RefreshPlayers();
        }
        /// <summary>
        /// Переход на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
            {
                return;
            }
            _currentPage--;
            RefreshPlayers();
        }
        /// <summary>
        /// Переход на первую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoFirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshPlayers();
        }
    }
}

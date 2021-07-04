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
    public class TempPlayer
    {
        public byte[] Img { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Position { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Country { get; set; }
        public System.DateTime JoinYear { get; set; }
    }
    public partial class PlayersPage : Page
    {
        public PlayersPage()
        {
            InitializeComponent();

            NBAShort_08Entities context = new NBAShort_08Entities();
            //GridPlayers.ItemsSource = context.Player.ToList();
            List<TempPlayer> tempPlayers = new List<TempPlayer>();
            foreach (Player item in context.Player)
            {
                tempPlayers.Add(new TempPlayer
                {
                    Img = item.Img,
                    PlayerId = item.PlayerId,
                    Name = item.Name,
                    Position = item.Position.Name,
                    Weight = item.Weight,
                    Height = item.Height,
                    JoinYear = item.JoinYear,
                    Country = item.Country.CountryName,
                    CountryCode = item.CountryCode
                });
            }
            GridPlayers.ItemsSource = tempPlayers;
        }
    }
}

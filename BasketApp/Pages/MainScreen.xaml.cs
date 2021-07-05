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
    /// Логика взаимодействия для PlayerMain.xaml
    /// </summary>
    public partial class PlayerMain : Page
    {
        static public MainWindow mainWindow;
        private NBAShort_08Entities _context = new NBAShort_08Entities();
        private List<Pictures> _pictures = new List<Pictures>();
        private int _currentPage = 1;
        /// <summary>
        /// Метод-конструктор класса
        /// </summary>
        public PlayerMain()
        {
            InitializeComponent();
            mainWindow.SecondFooterLabelInfo.Content = 1;
            _pictures = _context.Pictures.ToList();

            List<Pictures> pictures = _context.Pictures.ToList();//new List<Pictures>();
            //pictures = _pictures.Skip((_currentPage - 1) * 3).Take(3).ToList();
            //MessageBox.Show(pictures.Count.ToString());

            ListPictures.ItemsSource = pictures;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку для перехода к странице VisitorMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorMenu.mainWindow = mainWindow;
            NavigationService.Navigate(new Pages.VisitorMenu());
        }
        
        /// <summary>
        /// Метод-заглушка при нажатия кнопки Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }
    }
}

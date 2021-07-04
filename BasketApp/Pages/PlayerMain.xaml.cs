﻿using System;
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
        public PlayerMain()
        {
            InitializeComponent();
            //mainWindow.LabelHeader.Content = "NBA Managment Studio";
            //mainWindow.LabelNBAMS.Content = "";
            mainWindow.SecondFooterLabelInfo.Content = 1;
        }

        private void ButtonVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorMenu.mainWindow = mainWindow;
            NavigationService.Navigate(new Pages.VisitorMenu());
        }
        
        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция будет реализована позднее!");
        }
    }
}

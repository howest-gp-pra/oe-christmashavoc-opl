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
using Pra.Christmastree.Core.Services;
namespace Pra.Christmastree.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ChristmasService christmasService;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartSituation();
        }
        private void StartSituation()
        {
            btnStartChristmas.IsEnabled = true;
            btnReleaseHavoc.IsEnabled = false;
        }
        private void ChristmasSituation()
        {
            btnReleaseHavoc.IsEnabled = true;
            btnStartChristmas.IsEnabled = false;

        }
        private void btnStartChristmas_Click(object sender, RoutedEventArgs e)
        {
            christmasService = new ChristmasService();
            lstChristmasDecorations.ItemsSource = null;
            lstChristmasDecorations.ItemsSource = christmasService.ChristmasDecorations;
            tblReport.Text = christmasService.GetReport();
            ChristmasSituation();
        }

        private void btnReleaseHavoc_Click(object sender, RoutedEventArgs e)
        {
            christmasService.ReleaseHavoc();
            lstChristmasDecorations.ItemsSource = null;
            if(rdbAll.IsChecked==true)
                lstChristmasDecorations.ItemsSource = christmasService.ChristmasDecorations;
            else if(rdbBaubles.IsChecked == true)
                lstChristmasDecorations.ItemsSource = christmasService.GetChristmasBaubles();
            else if (rdbCookies.IsChecked == true)
                lstChristmasDecorations.ItemsSource = christmasService.GetChristmasCookies();
            else
                lstChristmasDecorations.ItemsSource = christmasService.GetChristmasLights();

            tblReport.Text = christmasService.GetReport();
            if(christmasService.IsChristmasDone)
            {
                StartSituation();
            }
        }

        private void rdbAll_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            lstChristmasDecorations.ItemsSource = null;
            lstChristmasDecorations.ItemsSource = christmasService.ChristmasDecorations;
        }

        private void rdbBaubles_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            lstChristmasDecorations.ItemsSource = null;
            lstChristmasDecorations.ItemsSource = christmasService.GetChristmasBaubles();
        }

        private void rdbCookies_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            lstChristmasDecorations.ItemsSource = null;
            lstChristmasDecorations.ItemsSource = christmasService.GetChristmasCookies();
        }

        private void rdbLights_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            lstChristmasDecorations.ItemsSource = null;
            lstChristmasDecorations.ItemsSource = christmasService.GetChristmasLights();
        }


    }
}

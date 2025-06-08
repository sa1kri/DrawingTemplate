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
using CountryNew.Clasess;
using CountryNew.Models;

namespace CountryNew.Pagess
{
    /// <summary>
    /// Логика взаимодействия для PageOne.xaml
    /// </summary>
    public partial class PageOne : Page
    {
        public PageOne()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Spisok.ItemsSource= AppData.db.Country.ToList();
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ты уверне что ты ненатурал?", "Проверка на натурала",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
                { 
            var cunntry = Spisok.SelectedItem as Country;
            AppData.db.Country.Remove(cunntry);
            AppData.db.SaveChanges();
            Spisok.ItemsSource = AppData.db.Country.ToList();
            MessageBox.Show("Обернись");
        }
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAdd());
        }
    }
}

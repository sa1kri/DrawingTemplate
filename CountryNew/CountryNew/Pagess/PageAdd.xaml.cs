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
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        public PageAdd()
        {
            InitializeComponent();
            CmbGroup.ItemsSource = AppData.db.CodTable.ToList();
        }

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(NameCountryTxt.Text))
            {
                MessageBox.Show("Введите имя странны");
                return;
            }
            if (string.IsNullOrWhiteSpace(NameCountryENTxt.Text))
            {
                MessageBox.Show("Введите имя странны");
                return;
            }


            var CodeTable = CmbGroup.SelectedItem as CodTable;
            if (CodeTable == null)
            {
                MessageBox.Show("Выбирете группу");
                return;
            }

            if (DatePick.SelectedDate == null)
            {
                MessageBox.Show("Выбирете дату");
                return;
            }

            Country country = new Country
            {
                NameCunrtry = NameCountryTxt.Text,
                NameCunrtryEN = NameCountryENTxt.Text,
                Cod = CodeTable.id,
                Date = DatePick.SelectedDate.Value
            };
            AppData.db.Country.Add(country);
            AppData.db.SaveChanges();
            MessageBox.Show("Сохранено");
            NavigationService.GoBack();
        }
    }
}

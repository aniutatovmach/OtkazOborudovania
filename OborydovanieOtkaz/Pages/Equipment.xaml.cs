using OborydovanieOtkaz.Database;
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
using System.Windows.Shapes;

namespace OborydovanieOtkaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        public static AccountingEquipmentEntities _context = new AccountingEquipmentEntities();
        public Equipment()
        {
            InitializeComponent();

            DataGridEquipment.ItemsSource = _context.Equipment.ToList();
        }

        private void BtnEditEquipment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OborydovanieOtkaz
{
    /// <summary>
    /// Логика взаимодействия для EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public static AccountingEquipmentEntities _context = new AccountingEquipmentEntities();

        public EquipmentPage()
        {
            InitializeComponent();
            DataGridEquipment.ItemsSource = _context.Equipment.ToList();
        }

        private void BtnEditEquipment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

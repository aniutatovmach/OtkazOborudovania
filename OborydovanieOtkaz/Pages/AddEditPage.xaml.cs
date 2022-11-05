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
using OborydovanieOtkaz.Database;

namespace OborydovanieOtkaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private TechnicalInspection _currentTechnic = new TechnicalInspection();

        public AddEditPage(TechnicalInspection selectedTechnic)
        {
            InitializeComponent();

            if (selectedTechnic != null)
                _currentTechnic = selectedTechnic;


            DataContext = _currentTechnic;
            ComboDivisionName.ItemsSource = AccountingEquipmentEntities.GetContext().Equipment.ToList();
            List<Worker> listEmployees = AccountingEquipmentEntities.GetContext().Worker.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (Convert.ToString(_currentTechnic.Date) == null)
                errors.AppendLine("Укажите дату.");
            if (Convert.ToString(_currentTechnic.ProductionSiteId) == null)
                errors.AppendLine("Укажите участок.");
            
            if (_currentTechnic.WorkerId == null)
                errors.AppendLine("Укажите подразделение.");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            

            try
            {
                AccountingEquipmentEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

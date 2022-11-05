using OborydovanieOtkaz.Database;
using OborydovanieOtkaz.Pages;
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

namespace OborydovanieOtkaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для TechnicInspectionPage.xaml
    /// </summary>
    public partial class TechnicInspectionPage : Page
    {
        public static AccountingEquipmentEntities _context = new AccountingEquipmentEntities();
        public TechnicInspectionPage()
        {
            InitializeComponent();
            DGridTechnic.ItemsSource = _context.TechnicalInspection.ToList();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AccountingEquipmentEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridTechnic.ItemsSource = AccountingEquipmentEntities.GetContext().TechnicalInspection.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as TechnicalInspection));

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var petsForRemoving = DGridTechnic.SelectedItems.Cast<TechnicalInspection>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {petsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEquipmentEntities.GetContext().TechnicalInspection.RemoveRange(petsForRemoving);
                    AccountingEquipmentEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridTechnic.ItemsSource = AccountingEquipmentEntities.GetContext().TechnicalInspection.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

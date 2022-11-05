using OborydovanieOtkaz.Database;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;





namespace OborydovanieOtkaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public static AccountingEquipmentEntities _context = new AccountingEquipmentEntities();

        public WorkersPage()
        {
            InitializeComponent();
            DGridEmployees.ItemsSource = _context.Worker.ToList();
        }
       
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Worker> allEmployees = AccountingEquipmentEntities.GetContext().Worker.ToList();
                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table employeessTable = document.Tables.Add(tableRange, allEmployees.Count + 1, 8);
                employeessTable.Borders.InsideLineStyle = employeessTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                employeessTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = employeessTable.Cell(1, 1).Range;
                cellRange.Text = "Номер работника";
                cellRange = employeessTable.Cell(1, 2).Range;
                cellRange.Text = "Табельный номер";
                cellRange = employeessTable.Cell(1, 3).Range;
                cellRange.Text = "Фамилия";
                cellRange = employeessTable.Cell(1, 4).Range;
                cellRange.Text = "Имя";
                cellRange = employeessTable.Cell(1, 5).Range;
                cellRange.Text = "Отчество";
                cellRange = employeessTable.Cell(1, 6).Range;
                cellRange.Text = "Должность";
                employeessTable.Rows[1].Range.Bold = 1;
                employeessTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int i = 1;
                foreach (var currentEmployee in allEmployees)
                {
                    cellRange = employeessTable.Cell(i + 1, 1).Range;
                    cellRange.Text = currentEmployee.Id.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 2).Range;
                    cellRange.Text = currentEmployee.ServiceNumber.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = employeessTable.Cell(i + 1, 3).Range;
                    cellRange.Text = currentEmployee.LastName.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 4).Range;
                    cellRange.Text = currentEmployee.FirstName;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = employeessTable.Cell(i + 1, 5).Range;
                    cellRange.Text = currentEmployee.MiddleName;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;


                    cellRange = employeessTable.Cell(i + 1, 6).Range;
                    cellRange.Text = currentEmployee.Post.ToString();
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                app.Visible = true;
                document.SaveAs2(@"C:\Users\Анна\Desktop\практика Поля\outputFilePdf.pdf", Word.WdExportFormat.wdExportFormatPDF);
            }
            catch
            {
                MessageBox.Show("Шо-то не так");
            }
        }
    }
}

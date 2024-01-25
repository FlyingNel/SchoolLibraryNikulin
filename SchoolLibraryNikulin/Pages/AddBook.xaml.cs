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

namespace SchoolLibraryNikulin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            Books bookObj = new Books()
            {
                Name = Txb_Ttile.Text,
                Author = Txb_Author.Text,
                Date = Txb_Date.Text
            };
            DbConnect.prObj.Books.Add(bookObj);
            DbConnect.prObj.SaveChanges();
            
            MessageBox.Show("Книга добавлена!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}

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
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        private List<Books> allbooks;
        public menu()
            
        {
            InitializeComponent();
            allbooks = DbConnect.prObj.Books.ToList();
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddBook());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ActiveRequest());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new menu());
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<Books> sortMaterials = allbooks.OrderBy(x => x.Name).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Books> sortMaterials = allbooks.OrderByDescending(x => x.Author).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 2)
            {
                List<Books> sortMaterials = allbooks.OrderByDescending(x => x.Date).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
        }
    }
}

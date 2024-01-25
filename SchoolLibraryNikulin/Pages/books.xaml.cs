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
    /// Логика взаимодействия для books.xaml
    /// </summary>
    public partial class books : Page
    {
        private List<Books> allbooks;
        public books()
        {
            InitializeComponent();
            allbooks = DbConnect.prObj.Books.ToList();
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddRequest());
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
                List<Books> sortMaterials = allbooks.OrderBy(x => x.Date).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaterialList.ItemsSource = DbConnect.prObj.Books.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

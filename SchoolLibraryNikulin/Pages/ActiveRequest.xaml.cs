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
    /// Логика взаимодействия для ActiveRequest.xaml
    /// </summary>
    public partial class ActiveRequest : Page
    {
        private List<Request> allrequest;
        public ActiveRequest()
        {
            InitializeComponent();
            allrequest = DbConnect.prObj.Request.ToList();
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
                List<Request> sortMaterials = allrequest.OrderBy(x => x.UserName).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Request> sortMaterials = allrequest.OrderByDescending(x => x.BookName).ToList();
                MaterialList.ItemsSource = sortMaterials;
            }
        }

        private void request_delete(object sender, RoutedEventArgs e)
        {
                var Request = MaterialList.SelectedItem as Request;
                DbConnect.prObj.Request.Remove(Request);
                DbConnect.prObj.SaveChanges();

                MessageBox.Show("Заказ завершен!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
        }
    }
}

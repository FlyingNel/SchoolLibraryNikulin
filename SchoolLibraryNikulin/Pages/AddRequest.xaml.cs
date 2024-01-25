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
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Page
    {
        public AddRequest()
        {
            InitializeComponent();
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            Request ReqObj = new Request()
            {
                UserName = Txb_UserName.Text,
                BookName = Txb_BookName.Text
            };
            DbConnect.prObj.Request.Add(ReqObj);
            DbConnect.prObj.SaveChanges();
        }
    }
}

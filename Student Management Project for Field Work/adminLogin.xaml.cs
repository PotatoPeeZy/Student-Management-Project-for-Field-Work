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

namespace Student_Management_Project_for_Field_Work
{
    /// <summary>
    /// Interaction logic for adminLogin.xaml
    /// </summary>
    public partial class adminLogin : Window
    {
        public adminLogin()
        {
            InitializeComponent();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (adminTxtBox.Text == "admin" && passTxtBox.Password == "admin")
            {
                this.Close();
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect!!");
            }
        }
    }
}

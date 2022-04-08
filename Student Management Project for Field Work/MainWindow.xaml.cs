using System;
using System.Windows;
using System.Data.SqlClient;
namespace Student_Management_Project_for_Field_Work
{
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+@"C:\Users\nazmu\Desktop\Machine Learning Potato_PeeZy\C# Projects\Student Management Project for Field Work\Student Management Project for Field Work\Data\LocalDb.mdf"+";Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var id = idScreen.Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentInformationTable WHERE ID=" + id + " ", con);
            Student st = new Student();
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                st.id = reader.GetInt32(0);
                st.name = reader.GetString(1);
                st.section = reader.GetString(2);
                st.department = reader.GetString(3);
                st.age = reader.GetInt32(4);
                st.address = reader.GetString(5);
                con.Close();
                studentInformationWindow stwindow = new studentInformationWindow(st);
                stwindow.Owner = this;
                stwindow.Show();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void adminPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            adminLogin adminLogin = new adminLogin();
            adminLogin.Owner = this;
            adminLogin.Show();
        }
    }
}

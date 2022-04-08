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
using System.Data.SqlClient;
using System.Data;
namespace Student_Management_Project_for_Field_Work
{

    public partial class AdminPanel : Window
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"C:\Users\nazmu\Desktop\Machine Learning Potato_PeeZy\C# Projects\Student Management Project for Field Work\Student Management Project for Field Work\Data\LocalDb.mdf" + ";Integrated Security=True");
        public void loadData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentInformationTable", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();
                allStudentDataGrid.ItemsSource = dt.DefaultView;
                crudDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public AdminPanel()
        {
            InitializeComponent();
            loadData();
        }
        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void departmentSelectorBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentInformationTable WHERE Department = @dept", con);
            cmd.Parameters.AddWithValue("dept", departmentSelectTxtBox.Text);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();
                departmentWiseDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentInformationTable (ID, Name, Section, Department, Age, Address) VALUES (@id, @name, @section, @dept, @age, @address)",con);
            cmd.Parameters.AddWithValue("id", idTxtBox.Text);
            cmd.Parameters.AddWithValue("name", nameTxtBox.Text);
            cmd.Parameters.AddWithValue("section", secTxtBox.Text);
            cmd.Parameters.AddWithValue("dept", deptTxtBox.Text);
            cmd.Parameters.AddWithValue("age", ageTxtBox.Text);
            cmd.Parameters.AddWithValue("address", addressTxtBox.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            loadData();
            idTxtBox.Clear();
            nameTxtBox.Clear();
            secTxtBox.Clear();
            deptTxtBox.Clear();
            ageTxtBox.Clear();
            addressTxtBox.Clear();
        }

        private void delStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM StudentInformationTable WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("id",idTxtBox.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            loadData();
        }
    }
}

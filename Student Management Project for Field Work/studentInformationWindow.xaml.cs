using System.Windows;

namespace Student_Management_Project_for_Field_Work
{
    /// <summary>
    /// Interaction logic for studentInformationWindow.xaml
    /// </summary>
    public partial class studentInformationWindow : Window
    {
        public studentInformationWindow(object student)
        {
            InitializeComponent();
            this.DataContext = student;
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

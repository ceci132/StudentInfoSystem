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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for UserLoginWindow.xaml
    /// </summary>
    public partial class UserLoginWindow : Window
    {
        public UserLoginWindow()
        {
            InitializeComponent();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            UserLogin.User user = UserLogin.UserData.IsUserPassCorrect(usernameTextBox.Text, passwordTextBox.Text);
            if (user == null)
            {
                MessageBox.Show("Wrong input");
            } else
            {
                if (user.role == (int)UserLogin.UserRoles.STUDENT)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.SetFormForStudent(StudentData.getStudentByFacultyNumber(user.facultyNumber));
                    mainWindow.showTestDataButton.Visibility = Visibility.Collapsed;
                    mainWindow.setPersonalInfoGridVisible();
                    mainWindow.setPersonalInfoGridNotEnabled();
                    mainWindow.setStudentInfoGridVisible();
                    mainWindow.setStudentInfoGridNotEnabled();
                    mainWindow.Show();
                }
                else if (user.role == (int)UserLogin.UserRoles.INSPECTOR)
                {
                    InspectorLoginWindow inspectorWindow = new InspectorLoginWindow();
                    inspectorWindow.DataContext = StudentData.TestStudents;
                    inspectorWindow.Show();
                }
                else
                {

                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }*/
    }
}

using StudentInfoSystem.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    internal class Presenter : ObservableObject
    {
        private string _userName;
        private string _passWord;

        public string username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChangedEvent("username");
            }
        }

        public string password
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                RaisePropertyChangedEvent("password");
            }
        }

        public ICommand openInspectorLoginWindow
        {
            get { return new DelegateCommand(showInspectorLoginWindow); }
        }

        public ICommand openMainWindow
        {
            get { return new DelegateCommand(showMainWindow); }
        }

        public void showInspectorLoginWindow()
        {

            UserLogin.User user = UserLogin.UserData.IsUserPassCorrect(username, password);
            if (user == null)
            {
                MessageBox.Show("Wrong input");
            }
            else
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
                    Application.Current.MainWindow.Close();
                }
                else if (user.role == (int)UserLogin.UserRoles.INSPECTOR)
                {
                    InspectorLoginWindow inspectorWindow = new InspectorLoginWindow();
                    inspectorWindow.DataContext = StudentData.TestStudents;
                    inspectorWindow.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {

                }
            }

        }

        private void showMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}

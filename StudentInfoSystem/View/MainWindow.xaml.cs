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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setStudentInfoGridNotVisible();
            setPersonalInfoGridNotVisible();
        }

        public void deleteAllContentFromAllForms()
        {
            facultyTextBox.Text = "";
            specialtyTextBox.Text = "";
            degreeTextBox.Text = "";
            statusTextBox.Text = "";
            facNumTextBox.Text = "";
            courseTextBox.Text = "";
            streamTextBox.Text = "";
            groupTextBox.Text = "";
        }

        public bool getStudentForm()
        {
            Student student = StudentData.getStudentByName(nameTextBox.Text, surnameTextBox.Text, lastNameTextBox.Text);
            if (student != null)
            {
                SetFormForStudent(student);
                return true;
            }

            return false;
        }

        public void SetFormForStudent(Student student)
        {
            nameTextBox.Text = student.name;
            surnameTextBox.Text = student.surname;
            lastNameTextBox.Text = student.lastName;
            facultyTextBox.Text = student.faculty;
            specialtyTextBox.Text = student.specialty;
            degreeTextBox.Text = student.degree;
            statusTextBox.Text = student.status;
            facNumTextBox.Text = student.facultyNumber;
            courseTextBox.Text = student.courseYear.ToString();
            streamTextBox.Text = student.stream.ToString();
            groupTextBox.Text = student.group.ToString();
        }
        public bool setStudentInfoGridNotVisible()
        {
            studentInfoGrid.Visibility = Visibility.Hidden;
            return true;
        }

        public void setPersonalInfoGridNotVisible()
        {
            nameTextBox.Visibility = Visibility.Hidden;
            surnameTextBox.Visibility = Visibility.Hidden;
            lastNameTextBox.Visibility = Visibility.Hidden;
        }

        public bool setStudentInfoGridEnabled()
        {
            studentInfoGrid.IsEnabled = true;
            return true;
        }

        public bool setStudentInfoGridNotEnabled()
        {
            studentInfoGrid.IsEnabled = false;
            return true;
        }

        public void setStudentInfoGridVisible()
        {
            studentInfoGrid.Visibility = Visibility.Visible;
        }

        public void setPersonalInfoGridVisible()
        {
            nameTextBox.Visibility = Visibility.Visible;
            surnameTextBox.Visibility = Visibility.Visible;
            lastNameTextBox.Visibility = Visibility.Visible;
        }

        public bool setPersonaltInfoGridEnabled()
        {
            personalInfoGrid.IsEnabled = true;
            return true;
        }

        public bool setPersonalInfoGridNotEnabled()
        {
            personalInfoGrid.IsEnabled = false;
            return true;
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            deleteAllContentFromAllForms();
            bool result = getStudentForm() ? setStudentInfoGridEnabled() : setStudentInfoGridNotVisible();
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            deleteAllContentFromAllForms();
            bool result = getStudentForm() ? setStudentInfoGridEnabled() : setStudentInfoGridNotVisible();
        }

        private void lastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            deleteAllContentFromAllForms();
            bool result = getStudentForm() ? setStudentInfoGridEnabled() : setStudentInfoGridNotVisible();
        }

        private void showTestDataButton_Click(object sender, RoutedEventArgs e)
        {
            setPersonalInfoGridVisible();
            loadTestUser();
            showTestDataButton.Content = "Покажи още инфо";
            showTestDataButton.Click += ShowTestDataButton_Click;
        }

        private void ShowTestDataButton_Click(object sender, RoutedEventArgs e)
        {
            setStudentInfoGridVisible();
        }

        private void loadTestUser()
        {
            Student defaultStudent = StudentData.getDefaultStudent();
            SetFormForStudent(defaultStudent);
        }
    }
}

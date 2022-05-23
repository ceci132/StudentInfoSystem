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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {
        // Custom constructor to pass expense report data
        public ExpenseReport(object data)
         : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
        public ExpenseReport()
        {
            InitializeComponent();
            this.DataContext = new Person();
        }

        private void createEvent_Click(object sender, RoutedEventArgs e)
        {
            EventCalendar eventCalendar = new EventCalendar(this.DataContext);
            eventCalendar.Width = Width;
            eventCalendar.Height = Height;
            eventCalendar.ShowDialog();
        }
    }
}

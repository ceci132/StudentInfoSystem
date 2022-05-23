﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public ObservableCollection<String> PersonsChecked{ get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked 
        {
            get { return lastChecked; }
            set 
            {
                lastChecked = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }

            }
        }
        public List<Person> ExpenseDataSource { get; set; }
        public string MainCaptionText { get; set; }
        public ExpenseItHome()
        {
            InitializeComponent();
            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            MainCaptionText = "View Expense Report :";
            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department = "Legal",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Lunch", ExpenseAmount = 50},
                        new Expense() { ExpenseType="Transportation", ExpenseAmount = 50},
                    }
                },
                new Person()
                {
                    Name = "Lisa",
                    Department = "Marketing",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount = 50},
                        new Expense() { ExpenseType="Gift", ExpenseAmount = 125},
                    }
                },
                new Person()
                {
                    Name = "John",
                    Department = "Engineering",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount = 50},
                        new Expense() { ExpenseType="New Machine", ExpenseAmount = 600},
                        new Expense() { ExpenseType="Software", ExpenseAmount = 500},
                    }
                },
                new Person()
                {
                    Name = "Mary",
                    Department = "Finance",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount = 100},
                    }
                },
                new Person()
                {
                    Name = "Theo",
                    Department = "Marketing",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount = 100},
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Sport",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Shoes", ExpenseAmount = 150},
                        new Expense() { ExpenseType="Ball", ExpenseAmount = 25},
                    }
                },
                new Person()
                {
                    Name = "David",
                    Department = "IT",
                    EventList = new EventList(),
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Computer", ExpenseAmount = 1500},
                        new Expense() { ExpenseType="Gift", ExpenseAmount = 25},
                    }
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report 
            ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
            expenseReport.Width = Width;
            expenseReport.Height = Height;
            expenseReport.ShowDialog();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            Person person = peopleListBox.SelectedItem as Person;
            //PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
            PersonsChecked.Add(person.Name);
        }
    }

}

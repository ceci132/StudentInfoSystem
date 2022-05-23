using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExpenseIt
{
    public class EventList : ObservableCollection<string>, INotifyPropertyChanged
    {
        string _eventDate = "";
        string _eventDescription = "";
        string _selectedEvent;

        public string EventDate
        {
            get { return _eventDate; }
            set
            {
                if (_eventDate != value)
                {
                    _eventDate = value;
                    OnPropertyChanged("EventDate");

                }
            }
        }
        public string EventDescription
        {
            get { return _eventDescription; }
            set
            {
                if (_eventDescription != value)
                {
                    _eventDescription = value;
                    OnPropertyChanged("EventDescription");
                }
            }
        }
        public string SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                if (_selectedEvent != value)
                {
                    _selectedEvent = value;
                    OnPropertyChanged("SelectedEvent");
                    _removeEventCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        AddCommand _addEventCommand = new AddCommand();
        public AddCommand AddEventCommand
        {
            get { return _addEventCommand; }

        }

        RemoveCommand _removeEventCommand = new RemoveCommand();
        public RemoveCommand RemoveEventCommand
        {
            get { return _removeEventCommand; }
        }

        /* public void ppppp()
         {
             if(_eventDate != null && _eventDescription != null)
             {

             }
         }*/
    }
}

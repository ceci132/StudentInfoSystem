using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpenseIt
{
    public class AddCommand : ICommand
    {
        public void Execute(object parameter)
        {
            var person = parameter as Person;
            var newEvent = string.Format("{0} {1}", person.EventList.EventDate, person.EventList.EventDescription );
            person.EventList.Add(newEvent);

            person.EventList.EventDate = person.EventList.EventDescription = "";
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpenseIt
{
    public class RemoveCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var targetPerson = parameter as Person;
            return targetPerson != null && targetPerson.EventList.SelectedEvent != null;
        }
        public void Execute(object parameter)
        {
            var targetPerson = parameter as Person;
            var oldEvent = targetPerson.EventList.SelectedEvent;
            targetPerson.EventList.Remove(oldEvent);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}

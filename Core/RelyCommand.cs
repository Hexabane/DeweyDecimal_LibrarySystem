//ST10116273
//Kunal Goyal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeweySystem.Core
{

    //This Class is for creating Variable type Relaycomand that acts a event holder
    ////**(Bunny, 2021) Reference in ReferenceList.
    
    class RelyCommand : ICommand
    {//start of RelyCommand Class

        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelyCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);

        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }


    }//end of RelayCommand Class.
}

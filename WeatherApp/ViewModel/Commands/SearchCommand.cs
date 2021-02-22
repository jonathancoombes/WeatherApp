using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
      public WeatherVM VM { get; set; }

        public SearchCommand(WeatherVM vm)
        {
           VM = vm;
        }

        // Add / remove here together with "UpdateSourceTrigger=PropertyChanged" on xaml is required for instant change/type checking

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        public bool CanExecute(object parameter)
        {
           string query = parameter as string;

           if (string.IsNullOrEmpty(query)) 
               return false;
           return true;
        }

        public void Execute(object parameter)
        {

            VM.MakeQuery();
        }
    }
}

//ST10116273
//Kunal Goyal
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.Core
{

    //THIS CLASS IS CREATED FOR DATA BINDING FUNTIONAILTY IN MAINWINDOW.XAML
    //**(Bunny, 2021) Reference in ReferenceList.

    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

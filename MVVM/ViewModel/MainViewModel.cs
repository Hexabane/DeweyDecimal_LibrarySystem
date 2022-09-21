//ST10116273
//Kunal Goyal
using DeweySystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {//start of Class MainViewModel

        public RelyCommand WelcomePageCommand { get; set; }

        public RelyCommand ReplaceBookViewCommand { get; set; }

        public RelyCommand IdentifyAreaViewCommand { get; set; }

        public RelyCommand FindingCallNumberCommand { get; set; }

        public RelyCommand HomeViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public viewModelWelcomePage WelcomePageVM { get; set; }

        public viewModelReplaceBook ReplaceBookVM { get; set; }

        public viewModelIdentifyArea IdentifyAreaVM { get; set; }

        public viewModelFindingCallNumbers FindingCallNumbersVM { get; set; }


        private object _currentView;


        //Setting the currentView to a value and calling the onPropertyChanged method
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            //Instaniating the 5 viewModels
            HomeVM = new HomeViewModel();
            WelcomePageVM = new viewModelWelcomePage();
            ReplaceBookVM = new viewModelReplaceBook();
            IdentifyAreaVM = new viewModelIdentifyArea();
            FindingCallNumbersVM = new viewModelFindingCallNumbers();

            CurrentView = HomeVM;

            HomeViewCommand = new RelyCommand(o =>
            {
                CurrentView = HomeVM;
            });

            WelcomePageCommand = new RelyCommand(o =>
            {
                CurrentView = WelcomePageVM;
            });

            ReplaceBookViewCommand = new RelyCommand(o =>
            {
                CurrentView = ReplaceBookVM;
            });

            IdentifyAreaViewCommand = new RelyCommand(o =>
            {
                CurrentView = IdentifyAreaVM;
            });

            FindingCallNumberCommand = new RelyCommand(o =>
            {
                CurrentView = FindingCallNumbersVM;
            });

        }

    }//end of Class MainViewModel
}

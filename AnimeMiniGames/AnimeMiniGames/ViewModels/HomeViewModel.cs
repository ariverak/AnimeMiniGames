using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeMiniGames.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand SequenceGameCommand { get; set; }

        INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SequenceGameCommand = new DelegateCommand(SequenceGameCommandExecute);
        }

        private void SequenceGameCommandExecute()
        {
            _navigationService.NavigateAsync("SequenceGame");
        }
    }
}

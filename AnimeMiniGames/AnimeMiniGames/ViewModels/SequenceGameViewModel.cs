using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeMiniGames.ViewModels
{
    public class SequenceGameViewModel : BindableBase
    {
        #region Commands
        public DelegateCommand<object> SequenceGameCommand { get; private set; }
        #endregion

        #region Photos
        private string _photo1;

        public string Photo1
        {
            get { return _photo1; }
            set { SetProperty(ref _photo1, value); }
        }
        private string _photo2;

        public string Photo2
        {
            get { return _photo2; }
            set { SetProperty(ref _photo2, value); }
        }
        private string _photo3;

        public string Photo3
        {
            get { return _photo3; }
            set { SetProperty(ref _photo3, value); }
        }
        private string _photo4;

        public string Photo4
        {
            get { return _photo4; }
            set { SetProperty(ref _photo4, value); }
        }
        private string _photo5;

        public string Photo5
        {
            get { return _photo5; }
            set { SetProperty(ref _photo5, value); }
        }
        private string _photo6;

        public string Photo6
        {
            get { return _photo6; }
            set { SetProperty(ref _photo6, value); }
        }
        private string _photo7;

        public string Photo7
        {
            get { return _photo7; }
            set { SetProperty(ref _photo7, value); }
        }
        private string _photo8;

        public string Photo8
        {
            get { return _photo8; }
            set { SetProperty(ref _photo8, value); }
        }
        private string _photo9;

        public string Photo9
        {
            get { return _photo9; }
            set { SetProperty(ref _photo9, value); }
        }
        #endregion

        private List<string> _secuenciaPlayer = new List<string>();
        private List<string> _secuenciaCpu = new List<string>();

        private string _intrucciones;

        public string Intrucciones
        {
            get { return _intrucciones; }
            set { SetProperty(ref _intrucciones, value); }
        }

        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        private string _sequencePhoto;

        public string SequencePhoto
        {
            get { return _sequencePhoto; }
            set { SetProperty(ref _sequencePhoto, value); }
        }


        private int _round;

        public DelegateCommand<object> PhotoTapCommand { get; set; }

        INavigationService _navigationService;
        public SequenceGameViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ChangeImageAsync();
            _round = 1;
            PhotoTapCommand = new DelegateCommand<object>(async e => await PhotoTapCommandExecute(e));
        }

        private int _tapCount = 0;
        private async Task PhotoTapCommandExecute(object obj)
        {
            var characterClick = obj.ToString().Substring(6);

            if (_secuenciaCpu[_tapCount] != characterClick)
            {
                await App.Current.MainPage.DisplayAlert("Game Over", "Usted a perdido :(", "Aceptar");
                _tapCount = 0;
                Enabled = false;
                await _navigationService.GoBackAsync();
            }
            _tapCount++;
            _secuenciaPlayer.Add(characterClick);
            Intrucciones = "";
            if (_tapCount == _secuenciaCpu.Count - 1)
            {
                Intrucciones = "¡" + GetNameForRound(_round) + " Ronda Ganada!";
                await Task.Delay(1500);
                await ResetRound();
            }
        }


        private async void ChangeImageAsync()
        {
            string[] photos = new string[] { "luffy", "sanji", "zoro", "nami", "brook", "franky", "chooper", "robin", "usopp" };
            var speed = GetSpeedForRound(_round);
            var rnd = new Random();
            var randomNumbers = Enumerable.Range(0, 9).OrderBy(x => rnd.Next()).Take(9).ToList();
            await Task.Delay(50);
            Photo1 = photos[randomNumbers[0]];
            await Task.Delay(50);
            Photo2 = photos[randomNumbers[1]];
            await Task.Delay(50);
            Photo3 = photos[randomNumbers[2]];
            await Task.Delay(50);
            Photo4 = photos[randomNumbers[3]];
            await Task.Delay(50);
            Photo5 = photos[randomNumbers[4]];
            await Task.Delay(50);
            Photo6 = photos[randomNumbers[5]];
            await Task.Delay(50);
            Photo7 = photos[randomNumbers[6]];
            await Task.Delay(50);
            Photo8 = photos[randomNumbers[7]];
            await Task.Delay(50);
            Photo9 = photos[randomNumbers[8]];
            await Task.Delay(500);
            if (_round == 1)
            {
                Intrucciones = "SIGUE LA SECUENCIA";
                await Task.Delay(3000);
                Intrucciones = "RONDA " + _round;
                await Task.Delay(2000);
            }
            else
            {
                Intrucciones = "RONDA " + _round;
                await Task.Delay(3000);
            }
            Intrucciones = "¿PREPARADO?";
            await Task.Delay(1000);
            Intrucciones = "3";
            await Task.Delay(1000);
            Intrucciones = "2";
            await Task.Delay(1000);
            Intrucciones = "1";
            await Task.Delay(1000);
            Intrucciones = "YA!";
            await Task.Delay(350);
            Intrucciones = "";
            rnd = new Random();
            var randomSelects = Enumerable.Range(0, 9).OrderBy(x => rnd.Next()).Take(9).ToList();
            await Task.Delay(200);
            for (int i = 0; i < GetNumCharactersForRound(_round) + 1; i++)
            {
                await Task.Delay(GetSpeedForRound(_round));
                SequencePhoto = photos[randomSelects[i]];
                _secuenciaCpu.Add(photos[randomSelects[i]]);
            }
            Intrucciones = "";
            SequencePhoto = "";
            Enabled = true;
        }

        private async Task ResetRound()
        {
            _tapCount = 0;
            _round++;
            Enabled = false;
            _secuenciaPlayer.Clear();
            _secuenciaCpu.Clear();
            CleanPhotos();
            await Task.Delay(500);
            ChangeImageAsync();
        }

        private int GetNumCharactersForRound(int round)
        {
            switch (round)
            {
                case 1:
                    return 3;
                case 2:
                    return 4;
                case 3:
                    return 4;
                case 4:
                    return 5;
                case 5:
                    return 5;
                case 6:
                    return 6;
                default:
                    return 7;
            }
        }
        private string GetNameForRound(int round)
        {
            switch (round)
            {
                case 1:
                    return "Primera";
                case 2:
                    return "Segunda";
                case 3:
                    return "Tercera";
                case 4:
                    return "Cuarta";
                case 5:
                    return "Quinta";
                case 6:
                    return "Sexta";
                default:
                    return "";
            }
        }
        private int GetSpeedForRound(int round)
        {
            switch (round)
            {
                case 1:
                    return 2000;
                case 2:
                    return 1500;
                case 3:
                    return 1000;
                case 4:
                    return 800;
                case 5:
                    return 650;
                case 6:
                    return 500;
                default:
                    {

                    }
                    return 2000;
            }
        }

        private void CleanPhotos()
        {
            Photo1 = "";
            Photo2 = "";
            Photo3 = "";
            Photo4 = "";
            Photo5 = "";
            Photo6 = "";
            Photo7 = "";
            Photo8 = "";
            Photo9 = "";
        }

    }
}

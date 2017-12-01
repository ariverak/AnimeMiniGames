using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimeMiniGames.Views
{
    public partial class SequenceGame : ContentPage
    {
        public SequenceGame()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.WhenAll(
                 Box1.FadeTo(1, 500, Easing.SinIn),
                 Box2.FadeTo(1, 500, Easing.SinIn),
                 Box3.FadeTo(1, 500, Easing.SinIn),
                 Box4.FadeTo(1, 500, Easing.SinIn),
                 Box5.FadeTo(1, 500, Easing.SinIn),
                 Box6.FadeTo(1, 500, Easing.SinIn),
                 Box7.FadeTo(1, 500, Easing.SinIn),
                 Box8.FadeTo(1, 500, Easing.SinIn),
                 Box9.FadeTo(1, 500, Easing.SinIn));
        }
    }
}


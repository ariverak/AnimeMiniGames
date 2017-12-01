using Prism.Navigation;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AnimeMiniGames
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null):base(initializer)
        {

        }
        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}

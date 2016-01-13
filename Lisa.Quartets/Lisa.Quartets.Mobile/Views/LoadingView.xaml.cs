using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
    public partial class LoadingView : ContentPage
    {
        public LoadingView(Type goToType, params object[] args)
        {
            InitializeComponent();

            _goToType = goToType;
            _args = args;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ContentPage goToPage = (ContentPage) Activator.CreateInstance(_goToType, _args);

            await Navigation.PushAsync(goToPage);
            Navigation.RemovePage(this);
        }

        private Type _goToType;
        private object[] _args;
    }
}

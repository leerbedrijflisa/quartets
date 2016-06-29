using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public partial class MainMenuView : ContentPage
    {
        public MainMenuView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            BackgroundImage = "main-background.png";
        }

        private void StartButtonClicked(object sender, EventArgs args)
        {
            Navigation.InsertPageBefore(new SelectHandView(), this);
            Navigation.PopAsync();
        }

        private void OptionsButtonClicked(object sender, EventArgs args)
        {
//            Navigation.InsertPageBefore(new , this);
//            Navigation.PopAsync();
            DisplayAlert("melding","opties","oké");
        }

        private void InstructionsButtonClicked(object sender, EventArgs args)
        {
//            Navigation.InsertPageBefore(new , this);
//            Navigation.PopAsync();
            DisplayAlert("melding","instructies","oké");
        }

        private void CreditsButtonClicked(object sender, EventArgs args)
        {
//            Navigation.InsertPageBefore(new , this);
//            Navigation.PopAsync();
            DisplayAlert("melding","credits","oké");
        }
    }
}


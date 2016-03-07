using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public partial class EmptyHandView : ContentPage
    {
        public EmptyHandView()
        {
            InitializeComponent();
        }

        public void SliderUnlocked(object sender, EventArgs args)
        {
            _database.ResetCards();   
            Navigation.PopToRootAsync();
        }

        private CardDatabase _database = new CardDatabase();
    }
}
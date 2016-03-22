using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class IdleView : ContentPage
	{
		public IdleView()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

        protected override void OnAppearing()
        {
            _sliderUnlocked = false;
            base.OnAppearing();
        }

        public void RequestCardUnlocked(object sender, EventArgs args)
		{
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.InsertPageBefore(new RequestView(), this);
                Navigation.PopAsync();
            }           
		}

        public void HandOverCardUnlocked(object sender, EventArgs args)
        {
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.PushAsync(new HandOverView());
            }
        }

        public void EditHandUnlocked(object sender, EventArgs args)
        {
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.PushAsync(new HandEditorView(typeof(IdleView)));
            }
        }

        private bool _sliderUnlocked = false;
	}
}
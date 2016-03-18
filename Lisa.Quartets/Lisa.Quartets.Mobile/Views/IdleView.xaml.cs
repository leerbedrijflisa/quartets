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

			// REVIEW: Should we hide the navigation bar in other views as well?
			NavigationPage.SetHasNavigationBar(this, false);
		}

        public void RequestCardUnlocked(object sender, EventArgs args)
		{
            Navigation.InsertPageBefore(new RequestView(), this);
            Navigation.PopAsync();
		}

        public void HandOverCardUnlocked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new HandOverView());
        }

        public void EditHandUnlocked(object sender, EventArgs args)
        {
            Navigation.InsertPageBefore(new HandEditorView(typeof(IdleView)), this);
            Navigation.PopAsync();
        }
	}
}
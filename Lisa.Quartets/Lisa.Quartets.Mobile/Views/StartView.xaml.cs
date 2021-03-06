﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public partial class StartView : ContentPage
	{
		public StartView()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private void StartClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new IdleView(), this);
            Navigation.PopAsync();
        }
	}
}
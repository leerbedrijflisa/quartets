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
		}

		private void SelectCardsClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CardView());
		}

		private void EndOfTurnClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new YesNoView());
		}
			
		private void SelectCardsCheckmarkClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CheckmarkCardView());
		}
	}
}
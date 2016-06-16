using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class EndScreenView : ContentPage
	{
		public EndScreenView ()
		{
			InitializeComponent ();
			Tapped ();
		}

		private void OnTap (object sender, EventArgs args)
		{
			Debug.WriteLine ("hello");
		}
		public void Tapped ()
		{
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += OnTap;
			TappedStackLayout.GestureRecognizers.Add (tapGestureRecognizer);
		}
	}
}


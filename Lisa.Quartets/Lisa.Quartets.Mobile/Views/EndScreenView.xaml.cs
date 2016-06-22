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
			//Debug.WriteLine ("hello");
			List<Card> quartet = _database.RetrieveNonQuartetCardsInHand ();
			card1.Source = quartet [0].FileName;
			card2.Source = quartet [1].FileName;
			card3.Source = quartet [2].FileName;
			TappedLayout.Children.Add (card1);
			TappedLayout.Children.Add (card2);
			TappedLayout.Children.Add (card3);
			//Debug.WriteLine (card1);
			/*int x = 0;
				for (int i = 0; i < 20; i++) {
					card1.Scale = card1.Scale + 0.01;
					card1.Rotation = card1.Rotation + 16;
					x++;
					if (x == 30)
					{
						Debug.WriteLine ("Stop");
					}
				}*/
			card1.Scale = 0.8;
			card2.Scale = 1.0;
			card3.Scale = 1.5;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();
			/*var rotation = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation,
										  end: card1.Rotation + 480,
										  easing: Easing.SinOut);*/

			var exitRight = new Animation (callback: d => card1.TranslationY = d,
										   start: 0,
										   end: -height,
										   easing: Easing.SinIn);

			var enterLeft = new Animation (callback: d => card1.TranslationY = d,
										   start: height,
										   end: 0,
										   easing: Easing.SinOut);

			//storyboard.Add (0, 1, rotation);
			storyboard.Add (0, 0.5, exitRight);
			storyboard.Add (0.5, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 1400);

			var storyboard2 = new Animation ();
			/*var rotation2 = new Animation (callback: e => card2.Rotation = e,
										  start: card2.Rotation,
										  end: card2.Rotation + 370,
										  easing: Easing.BounceOut);*/

			var exitRight2 = new Animation (callback: e => card2.TranslationX = e,
										   start: 0,
										   end: Width,
										   easing: Easing.SpringIn);

			var enterLeft2 = new Animation (callback: e => card2.TranslationX = e,
										   start: -Width,
										   end: 0,
										   easing: Easing.SpringOut);

			//storyboard2.Add (0,1,rotation2);
			storyboard2.Add (0, 0.5, exitRight2);
			storyboard2.Add (0.5, 1, enterLeft2);

			storyboard2.Commit (card2, "Loop", length: 1400 );

			var storyboard3 = new Animation ();

			var rotation3 = new Animation (callback: f => card3.Rotation = f,
										  start: card3.Rotation,
										  end: card3.Rotation + 980,
			                               easing: Easing.CubicOut);

			storyboard3.Add (0, 1, rotation3);


			storyboard3.Commit (card3, "Loop", length: 1400);
		}

		public void Tapped ()
		{
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += OnTap;
			TappedLayout.GestureRecognizers.Add (tapGestureRecognizer);
		}
		private CardDatabase _database = new CardDatabase ();
	}
}


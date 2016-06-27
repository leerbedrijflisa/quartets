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
			var cardListForAnimations = _database.RetrieveNonQuartetCardsInHand ();

			var rndCard = new Random ();

			int r = rndCard.Next (cardListForAnimations.Count);

			card1.Source = cardListForAnimations [r].FileName;
		}

		private void OnTap (object sender, EventArgs args) 
		{
			int AnimationCount = 3;
			var rndAnimation = new Random ((int) DateTime.UtcNow.Ticks);
			int r = rndAnimation.Next (AnimationCount);
			var RandomAnimationNumber = r;

			switch (RandomAnimationNumber) 
			{
				case 1:
					FirstAnimation ();
					Debug.WriteLine ("First Animation is being displayed");
					break;
				case 2:
					SecondAnimation ();
					Debug.WriteLine ("Second Animation is being displayed");
					break;
				case 3: 
					ThirdAnimation ();
					Debug.WriteLine ("Third Animation is being displayed");
					break;
				default:
					Debug.WriteLine ("No animation will be displayed");
					break;
			}

		}
		private void FirstAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 0.8;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard1 = new Animation ();
			var rotation = new Animation (callback: d => card1.Rotation = d,
										  start: 0,
										  end: card1.Rotation + 735,
										  easing: Easing.CubicOut);

			storyboard1.Add (0, 1, rotation);
			/*storyboard1.Add (0, 0.5, exitRight);
			storyboard1.Add (0.5, 1, enterLeft);*/

			storyboard1.Commit (card1, "Loop", length: 3000);
		}

		private void SecondAnimation ()
		{
			TappedLayout.Children.Add (card2);
	
			card1.Scale = 0.9;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard2 = new Animation ();
			/*var rotation2 = new Animation (callback: e => card2.Rotation = e,
										  start: card2.Rotation,
										  end: card2.Rotation + 370,
										  easing: Easing.BounceOut);*/

			var exitRight2 = new Animation (callback: e => card1.TranslationX = e,
										   start: 0,
										   end: -width,
										   easing: Easing.SpringIn);

			var enterLeft2 = new Animation (callback: e => card1.TranslationX = e,
										   start: width,
										   end: 0,
										   easing: Easing.SpringOut);

			//storyboard2.Add (0,1,rotation2);
			storyboard2.Add (0, 0.5, exitRight2);
			storyboard2.Add (0.5, 1, enterLeft2);

			storyboard2.Commit (card1, "Loop", length: 1400);
		}
		private void ThirdAnimation () 
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.5;
			card1.VerticalOptions = LayoutOptions.Start;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard3 = new Animation ();

			var exitRight3 = new Animation (callback: f => card1.TranslationY = f,
										   start: 0,
										   end: height,
										   easing: Easing.SpringIn);

			var enterLeft3 = new Animation (callback: f => card1.TranslationY = f,
										   start: -height,
										   end: 0,
										   easing: Easing.SpringOut);

			storyboard3.Add (0, 1, enterLeft3);

			storyboard3.Commit (card1, "Loop", length: 3000);
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
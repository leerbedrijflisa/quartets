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
			int AnimationCount = 7;
			var rndAnimation = new Random ((int) DateTime.UtcNow.Ticks);
			int rnd = rndAnimation.Next (AnimationCount);
			var RandomAnimationNumber = rnd;

			var cardListForAnimations = _database.RetrieveNonQuartetCardsInHand ();
			var rndCard = new Random ();
			int r = rndCard.Next (cardListForAnimations.Count);
			card1.Source = cardListForAnimations [r].FileName;

			switch (RandomAnimationNumber) 
			{
				case 0:
					FirstAnimation ();
					Debug.WriteLine ("First Animation is being displayed");
					break;
				case 1:
					SecondAnimation ();
					Debug.WriteLine ("Second Animation is being displayed");
					break;
				case 2: 
					ThirdAnimation ();
					Debug.WriteLine ("Third Animation is being displayed");
					break;
				case 3:
					FourthAnimation ();
					Debug.WriteLine ("Fourth Animation is being displayed");
					break;
				case 4:
					FifthAnimation ();
					Debug.WriteLine ("Fifth Animation is being displayed");
					break;
				case 5:
					SixthAnimation ();
					Debug.WriteLine ("Sixth Animation is being displayed");
					break;
				case 6:
					SeventhAnimation ();
					Debug.WriteLine ("Seventh Animation is being displayed");
					break;
				default:
					FirstAnimation ();
					Debug.WriteLine ("Default animation will be displayed");
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

			var rotationpart1 = new Animation (callback: d => card1.Rotation = d,
										  start: 0,
										  end: card1.Rotation + 735,
										  easing: Easing.CubicOut);
			
			var enterLeft = new Animation (callback: d => card1.TranslationX = d,
										   start: width,
										   end: 0,
										   easing: Easing.SpringIn);

			var exitright = new Animation (callback: d => card1.TranslationX = d,
										   start: 0,
										   end: width,
										   easing: Easing.SpringIn);
			
			var rotationpart2 = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 735,
										  end: 0,
										  easing: Easing.CubicOut);

			storyboard1.Add (0, 1, rotationpart1);
			storyboard1.Add (0.5, 1, enterLeft);
			storyboard1.Add (0, 0.5, exitright);
			storyboard1.Add (0, 1, rotationpart2);

			storyboard1.Commit (card1, "Loop", length: 3000);
		}

		private void SecondAnimation ()
		{
			TappedLayout.Children.Add (card1);
	
			card1.Scale = 0.9;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard2 = new Animation ();
			/*var rotation2 = new Animation (callback: e => card2.Rotation = e,
										  start: card2.Rotation,
										  end: card2.Rotation + 370,
										  easing: Easing.BounceOut);*/

			var exitRight2= new Animation (callback: d => card1.TranslationX = d,
										   start: 0,
										   end: width,
										   easing: Easing.SpringIn);

			var enterLeft2 = new Animation (callback: d => card1.TranslationX = d,
										   start: -width,
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

			var exitRight3 = new Animation (callback: d => card1.TranslationY = d,
										   start: 0,
										   end: height,
										   easing: Easing.SpringIn);

			var enterLeft3 = new Animation (callback: d => card1.TranslationY = d,
										   start: -height,
										   end: 0,
										   easing: Easing.SpringOut);

			storyboard3.Add (0, 1, enterLeft3);

			storyboard3.Commit (card1, "Loop", length: 3000);
		}

		private void FourthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard4 = new Animation ();

			var rotation4 = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 370,
										  end: 0,
										  easing: Easing.CubicOut);

			var exitRight4 = new Animation (callback: d => card1.TranslationY = d,
										   start: 0,
										   end: height,
										   easing: Easing.SpringIn);

			var enterLeft4 = new Animation (callback: d => card1.TranslationY = d,
										   start: -height,
										   end: 0,
										   easing: Easing.SpringOut);

			storyboard4.Add (0, 1, rotation4);
			storyboard4.Add (0, 1, exitRight4);
			storyboard4.Add (0, 1, enterLeft4);

			storyboard4.Commit (card1, "Loop", length: 2500);
		}

		private void FifthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard5 = new Animation ();

			var rotation5 = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 535,
										  end: 0,
										  easing: Easing.SinIn);

			var exitRight5 = new Animation (callback: d => card1.TranslationX = d,
										   start: 0,
										   end: -width,
										   easing: Easing.SpringOut);

			var enterLeft5 = new Animation (callback: d => card1.TranslationX = d,
										   start: width,
										   end: 0,
										   easing: Easing.SpringIn);

			storyboard5.Add (0, 1, rotation5);
			storyboard5.Add (0, 1, exitRight5);
			storyboard5.Add (0, 1, enterLeft5);

			storyboard5.Commit (card1, "Loop", length: 2150);
		}

		private void SixthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard6 = new Animation ();

			var enterLeft6 = new Animation (callback: d => card1.TranslationY = d,
										   start: height,
										   end: 0,
										   easing: Easing.SpringIn);

			storyboard6.Add (0, 1, enterLeft6);

			storyboard6.Commit (card1, "Loop", length: 2150);
		}

		private void SeventhAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 0.7;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard7 = new Animation ();

			var rotation7 = new Animation (callback: d => card1.Rotation = d,
										  start: 0,
										  end: card1.Rotation + 611,
										  easing: Easing.SinIn);

			var enterLeft7 = new Animation (callback: d => card1.TranslationX = d,
										   start: width,
										   end: 0,
										   easing: Easing.SpringIn);

			storyboard7.Add (0, 1, rotation7);
			storyboard7.Add (0, 1, enterLeft7);

			storyboard7.Commit (card1, "Loop", length: 4000);
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
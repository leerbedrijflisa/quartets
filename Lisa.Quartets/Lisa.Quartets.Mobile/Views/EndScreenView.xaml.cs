using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class EndScreenView : ContentPage
	{
		public EndScreenView ()
		{
			InitializeComponent ();
			Tapped ();
			BackgroundImage = "@drawable/endscreenbg.png";
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
					break;
				case 1:
					SecondAnimation ();
					break;
				case 2: 
					ThirdAnimation ();
					break;
				case 3:
					FourthAnimation ();
					break;
				case 4:
					FifthAnimation ();
					break;
				case 5:
					SixthAnimation ();
					break;
				case 6:
					SeventhAnimation ();
					break;
				default:
					FirstAnimation ();
					break;
			}

		}
		private void FirstAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;
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
	
			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var exitRight= new Animation (callback: d => card1.TranslationX = d,
										   start: 0,
										   end: width,
										   easing: Easing.SpringIn);

			var enterLeft = new Animation (callback: d => card1.TranslationX = d,
										   start: -width,
										   end: 0,
										   easing: Easing.SpringOut);

			storyboard.Add (0, 0.5, exitRight);
			storyboard.Add (0.5, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 1400);
		}
		private void ThirdAnimation () 
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;
			card1.VerticalOptions = LayoutOptions.Start;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var exitRight = new Animation (callback: d => card1.TranslationY = d,
										   start: 0,
										   end: height,
										   easing: Easing.SpringIn);

			var enterLeft = new Animation (callback: d => card1.TranslationY = d,
										   start: -height,
										   end: height - 450,
										   easing: Easing.SpringOut);
			
			storyboard.Add (0, 1, exitRight);
			storyboard.Add (0, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 3000);
		}

		private void FourthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var rotation = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 370,
										  end: 0,
										  easing: Easing.CubicOut);

			var exitRight = new Animation (callback: d => card1.TranslationY = d,
										   start: 0,
										   end: height,
										   easing: Easing.SpringIn);

			var enterLeft = new Animation (callback: d => card1.TranslationY = d,
										   start: -height,
										   end: height - 450,
										   easing: Easing.SpringOut);

			storyboard.Add (0, 1, rotation);
			storyboard.Add (0, 1, exitRight);
			storyboard.Add (0, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 2500);
		}

		private void FifthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var rotation = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 535,
										  end: 0,
										  easing: Easing.SinIn);

			var exitRight = new Animation (callback: d => card1.TranslationX = d,
										   start: 0,
										   end: -width,
										   easing: Easing.SpringOut);

			var enterLeft = new Animation (callback: d => card1.TranslationX = d,
										   start: width,
										   end: width -300,
										   easing: Easing.SpringIn);

			storyboard.Add (0, 1, rotation);
			storyboard.Add (0, 1, exitRight);
			storyboard.Add (0, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 2150);
		}

		private void SixthAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var enterLeft = new Animation (callback: d => card1.TranslationY = d,
										   start: height,
										   end: height - 310,
										   easing: Easing.SpringIn);

			storyboard.Add (0, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 2150);
		}

		private void SeventhAnimation ()
		{
			TappedLayout.Children.Add (card1);

			card1.Scale = 1.2;

			var width = Application.Current.MainPage.Width;
			var height = Application.Current.MainPage.Height;

			var storyboard = new Animation ();

			var rotation = new Animation (callback: d => card1.Rotation = d,
										  start: card1.Rotation + 740,
										  end: 0,
										  easing: Easing.SinIn);

			var enterLeft = new Animation (callback: d => card1.TranslationX = d,
										   start: -width,
										   end: width -300,
										   easing: Easing.SpringIn);

			storyboard.Add (0, 1, rotation);
			storyboard.Add (0, 1, enterLeft);

			storyboard.Commit (card1, "Loop", length: 4000);
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
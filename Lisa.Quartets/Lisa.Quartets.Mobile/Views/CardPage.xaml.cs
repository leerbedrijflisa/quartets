using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class CardPage : ContentPage
	{
		public List<string> selectedImages = new List<string>();
		private CardDatabase database;

		public CardPage ()
		{
			database = new CardDatabase();
			var cards = database.GetCards();
			if (cards.Count() == 0)
			{
				database.createDefaultCards ();
			}

			SetImages ();
			InitializeComponent ();
		}

		void OnImageClick(object sender, EventArgs args) {	
			var imageSender = (Image)sender;

			string imageId = imageSender.ClassId.ToString ();

			if (selectedImages.Contains(imageId)) {
				selectedImages.Remove(imageId);
				imageSender.Opacity = 1;
			} else {
				selectedImages.Add (imageId);
				imageSender.Opacity = 0.5;
			}
		}

		private void SetImages()
		{
			var cards = database.GetCards ();

			foreach (var card in cards) 
			{
				System.Diagnostics.Debug.WriteLine (card.FileName);
			}

//			var count = 1;
//			foreach (var layoutImage in cardGrid.Children.OfType<Image>()) 
//			{
//				var cardImage = (Image)layoutImage;
//				var card = database.GetCard (count);
//
//				System.Diagnostics.Debug.WriteLine (card.FileName);
//
//				layoutImage.Source = card.FileName;
//
//				count++;
//			}
		}
	}
}
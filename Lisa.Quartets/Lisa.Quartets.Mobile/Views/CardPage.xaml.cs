using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class CardPage : ContentPage
	{
		public CardPage()
		{
			InitializeComponent();
			EnsureCardsExist();
			SetImages();
		}

		private void EnsureCardsExist()
		{
			var cards = _database.RetrieveCards();
			if (cards.Count() == 0)
			{
				_database.CreateDefaultCards();
			}
		}

		private void OnImageClick(object sender, EventArgs args)
		{	
			var image = (Image) sender;

			if (_selectedImages.Contains(image.ClassId))
			{
				_selectedImages.Remove(image.ClassId);
				image.Opacity = 1;
			}
			else
			{
				_selectedImages.Add(image.ClassId);
				image.Opacity = 0.5;
			}
		}

		private void SetImages()
		{
			var cards = _database.RetrieveCards();

			foreach (var card in cards) 
			{
				System.Diagnostics.Debug.WriteLine(card.FileName);
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

		private CardDatabase _database = new CardDatabase();
		private List<string> _selectedImages = new List<string>();
	}
}
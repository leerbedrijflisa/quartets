using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class InvertedCardView : ContentPage
	{
		public InvertedCardView()
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
				image.Opacity = 0.5;
			}
			else
			{
				_selectedImages.Add(image.ClassId);
				image.Opacity = 1;
			}
		}

		private void SetImages()
		{
			var cards = _database.RetrieveCards();

			foreach (var card in cards) 
			{
				System.Diagnostics.Debug.WriteLine(card.FileName);
			}
		}

		private CardDatabase _database = new CardDatabase();
		private List<string> _selectedImages = new List<string>();
	}
}
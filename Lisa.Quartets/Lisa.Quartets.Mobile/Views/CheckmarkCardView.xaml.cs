using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class CheckmarkCardView : ContentPage
	{
		public CheckmarkCardView()
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
            var parent = (AbsoluteLayout) image.Parent;

			if (_selectedImages.Contains(image.ClassId))
			{
                parent.Children.Remove(_checkmarks[image.ClassId]);
                _selectedImages.Remove(image.ClassId);
			}
			else
			{
                parent.Children.Add(_checkmarks[image.ClassId]);
                _selectedImages.Add(image.ClassId);               
			}
		}

		private void SetImages()
		{
			var cards = _database.RetrieveCards();

			foreach (var card in cards) 
			{
                _checkmarks.Add(card.Name, new Image { Source = ImageSource.FromFile("check.png"), HeightRequest = 30 });
			}
		}

		private CardDatabase _database = new CardDatabase();
		private List<string> _selectedImages = new List<string>();
        private Dictionary<string, Image> _checkmarks = new Dictionary<string, Image>();
	}
}
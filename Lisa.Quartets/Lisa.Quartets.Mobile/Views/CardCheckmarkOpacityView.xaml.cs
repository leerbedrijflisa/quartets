using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class CardCheckmarkOpacityView : ContentPage
	{
		public CardCheckmarkOpacityView()
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

			if (IsSelected(image))
			{
				DeselectImage(image);
				RemoveCheckmark(image);
				image.Opacity = 0.5;
			}
			else
			{
				SelectImage(image);
				AddCheckmark(image);
				image.Opacity = 1;
			}
		}

		private bool IsSelected(Image image)
		{
			return _selectedImages.Contains(image.ClassId);
		}

		private void DeselectImage(Image image)
		{
			_selectedImages.Remove(image.ClassId);
		}

		private void SelectImage(Image image)
		{
			_selectedImages.Add(image.ClassId);
		}

		private void AddCheckmark(Image image)
		{
			var parent = (AbsoluteLayout) image.Parent;
			parent.Children.Add(_checkmarks[image.ClassId]);
		}

		private void RemoveCheckmark(Image image)
		{
			var parent = (AbsoluteLayout) image.Parent;
			parent.Children.Remove(_checkmarks[image.ClassId]);
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
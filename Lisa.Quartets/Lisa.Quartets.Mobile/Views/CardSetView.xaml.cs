using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class CardSetView : ContentPage
	{
		public CardSetView ()
		{
			InitializeComponent ();
			SetCardSetImages();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		private void CardSetSelected (object sender, EventArgs e)
		{
			Navigation.PushAsync(new HandEditorView(typeof(StartView)));
		
		}

		private void Deselect(CardImage image)
		{
			_selectedImages.Remove(image.CardId);
		}

		private bool IsIos()
		{
			return Device.OS == TargetPlatform.iOS;
		}


		private void Select(CardImage image)
		{
			_selectedImages.Add(image.CardId);
		}

		private void SaveSelectedCardSet(object sender, EventArgs args)
		{
			//_database.UpdateSelectedCards(_selectedImages);
			//FindQuartets();

			/*if (_database.RetrieveRequestableCards().Count == 0)
			{
				_newView = CreateNewView(typeof(EmptyHandView));
				ContinueToNextView();
			}
			else
			{
				ContinueToNextView();
			} */
		}

		private void OnImageClick(object sender, EventArgs args)
		{
			var image = (CardImage) sender;

			if (IsSelected(image))
			{
				Deselect(image);
				image.ScaleTo(0.8, 100);

				if (IsIos()) {
					image.FadeTo(0.5, 100);   
				}
				else
				{					
					_opacity[image.CardId].FadeTo(1, 100);
				}
			}
			else
			{
				Select(image);
				image.ScaleTo(1, 100);

				if (IsIos()) {
					image.FadeTo(1, 100);   
				}
				else
				{
					_opacity[image.CardId].FadeTo(0, 100);
				}
			}

			if (_selectedImages.Count > 0)
			{
				//saveButton.IsEnabled = true;
			}
			else
			{
				//saveButton.IsEnabled = false;
			}
		}

		private bool IsSelected(CardImage image)
		{ 
			return _selectedImages.Contains(image.CardId);
		}

		private void SetCardSetImages()
		{
			CardLayout cardGrid = new CardLayout();
			List<CardSet> cardsets = _database.RetrieveCardSets();

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += OnImageClick;
			FileImageSource opacitySource = new FileImageSource { File = "opacity.png" };

			foreach (var cardset in cardsets)
			{
				CardImage image = new CardImage();
				image.Source = cardset.FileName;
				image.CardId = cardset.Id;

				image.Scale = 0.8;
				image.GestureRecognizers.Add(tapGestureRecognizer);

				if (IsIos()) {
					if (IsSelected(image)) {
						image.Opacity = 1;
						image.Scale = 1;
					} else {
						image.Opacity = 0.5;
						image.Scale = 0.8;
					}

					cardGrid.Children.Add(image);				
				} else {
					Image opacity = new Image { Source = opacitySource, Scale = 0.8 };

					if (IsSelected(image))
					{
						opacity.Opacity = 0;
						image.Scale = 1;
					}

					_opacity.Add(image.CardId, opacity);

					var parent = new AbsoluteLayout{ Children = { image, _opacity[image.CardId] } };

					cardGrid.Children.Add(parent);
				}
			} 

			scrollViewCardSet.Content = cardGrid;
		}

		private CardDatabase _database = new CardDatabase();
		private Dictionary<int, Image> _opacity = new Dictionary<int, Image>();
		private List<int> _selectedImages = new List<int>();
	}
}


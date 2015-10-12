using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class CardPage : ContentPage
	{
		public List<string> selectedImages = new List<string>();

		public CardPage ()
		{
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
	}
}


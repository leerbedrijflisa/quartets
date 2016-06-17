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
			//Debug.WriteLine ("hello");
			List<Card> quartet = _database.RetrieveNonQuartetCardsInHand ();
			card1.Source = quartet [0].FileName;
			TappedLayout.Children.Add (card1);
			//Debug.WriteLine (card1);
			int x = 0;
			for(int i = 0; i < 20; i++){
				card1.Scale = card1.Scale + 0.01;
				card1.Rotation = card1.Rotation + 16;
				x++;
				if (x == 30)
				{
					Debug.WriteLine ("Stop");
				}
			}
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


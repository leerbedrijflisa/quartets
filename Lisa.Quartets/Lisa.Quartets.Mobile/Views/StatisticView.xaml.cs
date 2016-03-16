using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class StatisticView : ContentPage
	{
		public StatisticView()
		{
			InitializeComponent();

			List<RequestCardStats> stats = _database.RetrieveStatistics();

			foreach (var item in stats)
			{
				item.Timestamp = item.Timestamp.ToLocalTime();
			}

			statisticList.ItemsSource = stats;         
		}

		private async void ResetStatsClicked(object sender, EventArgs args)
		{
			var action = await DisplayAlert("Waarschuwing", "Weet u zeker dat u alle data wilt verwijderen?", "Ja", "Nee");

			if (action)
			{
				_database.DeleteStats();
			}
		}

		private CardDatabase _database = new CardDatabase();
	}
}


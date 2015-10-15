using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets
{
	public partial class AudioView : ContentPage
	{
		public AudioView()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void PlayAudio (object sender, EventArgs args)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"test.mp3"
			);
		}

		public void PlayAudio2 (object sender, EventArgs args)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"oke.mp3"
			);
		}
	}
}


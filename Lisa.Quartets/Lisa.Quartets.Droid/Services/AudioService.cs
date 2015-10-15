using System;
using Xamarin.Forms;
using Lisa.Quartets.Droid;
using Android.Media;

[assembly: Dependency(typeof(AudioService))]

namespace Lisa.Quartets.Droid
{
	public class AudioService : IAudio
	{
		public AudioService() {}

		private MediaPlayer _mediaPlayer;

		public bool PlayMp3File(string fileName)
		{
			_mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.test);
			_mediaPlayer.Start();

			return true;
		}
			
	}
}


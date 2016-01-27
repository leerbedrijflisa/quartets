using System;
using Xamarin.Forms;
using Lisa.Quartets.Mobile;
using Lisa.Quartets.iOS;
using Foundation;
using AudioToolbox;
using AVFoundation;

[assembly: Dependency(typeof(AudioService))]
namespace Lisa.Quartets.iOS
{
	public class AudioService : IAudio
	{
		public bool PlayFile(string fileName)
		{
			_player = AVAudioPlayer.FromUrl(NSUrl.FromFilename(string.Format("raw/{0}.wav", fileName)));
			_player.Play();

			return true;
		}
			
		private AVAudioPlayer _player;
	}
}


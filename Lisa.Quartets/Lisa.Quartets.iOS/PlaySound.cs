using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Lisa.Quartets.Mobile;
using Lisa.Quartets.iOS;

[assembly: Dependency(typeof(AudioService))]

namespace Lisa.Quartets.iOS
{
	public class UnlockSliderRenderer : SliderRenderer
	{

		private AVAudioPlayer _ringtoneAudioPlayer;

		public AudioPlatformService()
		{
			_ringtoneAudioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename("call.caf"));
			_ringtoneAudioPlayer.NumberOfLoops = -1; // infinite
		}

		public void PlayRingtone()
		{
			if (_ringtoneAudioPlayer != null)
			{
				_ringtoneAudioPlayer.Stop();
			}
			_ringtoneAudioPlayer.Play();
		}

		public void StopRingtone()
		{
			if (_ringtoneAudioPlayer != null)
			{
				_ringtoneAudioPlayer.Stop();
			}
		}
	}
}

using System;
using Xamarin.Forms;

namespace Lisa.Quartets
{
    public class UnlockSlider : Slider
    {
        public event EventHandler OnUnlock;

        public void OnStopDragging()
        {
            if (OnUnlock != null)
            {
                OnUnlock(this, EventArgs.Empty);
            }
        }
    }
}
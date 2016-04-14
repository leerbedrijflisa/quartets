using System;
using Lisa.Quartets.Mobile;

namespace Lisa.Quartets.Droid
{
    public class CircularSliderTouchEventArg : EventArgs
	{
        public CircularSliderRenderer CircularSliderRenderer { get; set;}

        public CircularSliderTouchEventArg(CircularSliderRenderer circularSliderRenderer)
        {
            CircularSliderRenderer = circularSliderRenderer;
        }

	}
}

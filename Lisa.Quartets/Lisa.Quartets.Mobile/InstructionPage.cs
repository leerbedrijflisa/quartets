using System;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public class InstructionPage : ContentPage
	{
		public InstructionPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}



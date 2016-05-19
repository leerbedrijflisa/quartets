using System;
using System.Linq;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public class CardSetLayout : Layout<View>
	{
		protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
		{
			Size cardSize = CalculateCardSize(widthConstraint, heightConstraint);
			double width = widthConstraint;
			double height = cardSize.Height * (Children.Count / 4);
			if (Children.Count % 4 > 0)
			{
				height += cardSize.Height;
			}

			return new SizeRequest(new Size(width, height));
		}
			
		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			int column = 0;
			int row = 0;

			double cardWidth = width / 4.0;
			double cardHeight = _cardHeight * (cardWidth / _cardWidth);

			foreach (View child in Children.Where(c => c.IsVisible))
			{
				var region = new Rectangle(column * 100, row * 100, 100, 100);
				LayoutChildIntoBoundingRegion(child, region);
			} 
		}
			
		private Size CalculateCardSize(double layoutWidth, double layoutHeight)
		{
			double width = layoutWidth / 4.0;
			double height = _cardHeight * (width / _cardWidth);

			return new Size(width, height);
		}

		private int _cardWidth = 182;
		private int _cardHeight = 265;

	}
}


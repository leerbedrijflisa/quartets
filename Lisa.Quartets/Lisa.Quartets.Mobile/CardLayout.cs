using System;
using System.Linq;
using Xamarin.Forms;
​
namespace Lisa.Quartets.Mobile
{
    public class CardLayout : Layout<View>
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
        ​
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            int column = 0;
            int row = 0;
            ​
            double cardWidth = width / 4.0;
            double cardHeight = 245 * (cardWidth / 162);

            foreach (View child in Children.Where(c => c.IsVisible))
            {
                var region = new Rectangle(column * cardWidth, row * cardHeight, cardWidth, cardHeight);
                LayoutChildIntoBoundingRegion(child, region);
                ​
                column++;
                if (column >= 4)
                {
                    column = 0;
                    row++;
                }
            }
        }
        ​
        private Size CalculateCardSize(double layoutWidth, double layoutHeight)
        {
            double width = layoutWidth / 4.0;
            double height = 245 * (width / 162);
            ​
            return new Size(width, height);
        }
    }
}
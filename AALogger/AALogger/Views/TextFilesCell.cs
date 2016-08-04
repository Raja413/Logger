using System;

using Xamarin.Forms;

namespace AALogger
{
	public class TextFilesCell : ViewCell
	{
		public TextFilesCell()
		{
			var title = new Label
			{
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			var layout = new StackLayout
			{
				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { title }
			};

			View = layout;
		}

	}

}



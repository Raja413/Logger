using System;

using Xamarin.Forms;

namespace AALogger
{
	public class LogsListViewCell : ViewCell
	{
		public LogsListViewCell()
		{
			var title = new Label
			{
				VerticalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var subTitle = new Label
			{
				VerticalTextAlignment = TextAlignment.Start,HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var layout = new StackLayout
			{
				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { title, subTitle }
			};

			View = layout;
		}
	}
}



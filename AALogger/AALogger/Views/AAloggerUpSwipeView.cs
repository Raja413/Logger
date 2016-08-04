using System;

using Xamarin.Forms;

namespace AALogger
{
	public class AAloggerUpSwipeView : ContentPage
	{
		ListView listView;

		public AAloggerUpSwipeView()
		{
			Title = "Logs";
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton(this, false);

			listView = new ListView
			{
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(TextFilesCell))
			};
			ToolbarItem toolBar = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				toolBar = new ToolbarItem("close", "send", () =>
				{
					Navigation.PopAsync();
				}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android)
			{
				toolBar = new ToolbarItem("close", "send", () =>
				{
					Navigation.PopAsync();
				}, 0, 0);
			}

			if (Device.OS == TargetPlatform.WinPhone)
			{
				toolBar = new ToolbarItem("close", "send", () =>
				{
					Navigation.PopAsync();
				}, 0, 0);
			}

			ToolbarItems.Add(toolBar);

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			// update the list view 
			//listView.ItemsSource = App.Database.GetItems();
			listView.ItemsSource = getLogs();
		}

		private Array getLogs()
		{
			string[] arr = new string[] { "raja", "reddy" };
			return arr;
		}
	}
}



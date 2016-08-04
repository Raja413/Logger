using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AALogger
{
	public class AALoggerDownSwipeView : ContentPage
	{
		ListView listView;

		public AALoggerDownSwipeView()
		{
			Title = "Console Log";
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton(this, false);


			listView = new ListView
			{
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(LogsListViewCell))
			};
			ToolbarItem toolBar = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				toolBar = new ToolbarItem("close", null, () =>
				{
					Navigation.PopAsync();
				}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android)
			{ 
				toolBar = new ToolbarItem("close", null, () =>
				{
					Navigation.PopAsync();
				}, 0, 0);
			}

			if (Device.OS == TargetPlatform.WinPhone)
			{
				toolBar = new ToolbarItem("close", null, () =>
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
		}
	}

}



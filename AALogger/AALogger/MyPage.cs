using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Xamarin.Forms;

namespace AALogger
{
	public class MyPage : Application
	{
		public MyPage()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryGreen", Color.FromHex("91CA47"));
			Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

			var nav = new NavigationPage(new AAloggerUpSwipeView());
			nav.BarTextColor = Color.Blue;

			MainPage = nav;
		}
	}
}


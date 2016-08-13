using System.Diagnostics;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class BasicEnglishTestPage : ContentPage
	{
		public static int UserOption = 0;
		public BasicEnglishTestPage()
		{
			InitializeComponent();
		}

		async	void OnClick(object sender, System.EventArgs e)
		{
			Button bt = (Button)sender;
			UserOption = bt.Text.Equals("Lý Thuyết") ? 0 : 1;

			await	Navigation.PushAsync(new ListLesson());
		//	NavigationPage.p
		}
	}
}

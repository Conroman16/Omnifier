using System.Windows;

namespace Omnifier.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			Title = Config.AppTitle;
			InitializeComponent();
		}
	}
}

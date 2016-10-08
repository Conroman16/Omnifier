using Omnifier.Core.Models;
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

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			var task = new OmniTask(txtItemName.Text, txtItemNotes.Text);
			if (!task.Submit())
				ShowErrorMessageBox();

			ClearInputs();
		}

		private void ClearInputs()
		{
			txtItemName.Clear();
			txtItemNotes.Clear();
		}

		private static void ShowErrorMessageBox()
		{
			const string title = "Submission Error";
			var message = $"{Config.AppTitle} experienced an error while submitting your task to the Omni Sync Server.  Please check your configuration settings and try again.";
			MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}

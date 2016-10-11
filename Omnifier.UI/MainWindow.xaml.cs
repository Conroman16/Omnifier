using Omnifier.Core.Models;
using Omnifier.UI.Models;
using System.ComponentModel;
using System.Windows;

namespace Omnifier.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static bool SettingsOpen { get; set; }
		private Settings SettingsWindow { get; set; }

		public MainWindow()
		{
			Title = Config.AppTitle;
			InitializeComponent();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (SettingsOpen)
				SettingsWindow.Close();

			base.OnClosing(e);
		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			var task = new OmniTask(txtItemName.Text, txtItemNotes.Text);
			if (!task.Submit())
				ShowErrorMessageBox();

			ClearInputs();
		}

		private void btnSettings_Click(object sender, RoutedEventArgs e)
		{
			OpenSettingsWindow();
		}

		private void ClearInputs()
		{
			txtItemName.Clear();
			txtItemNotes.Clear();
		}

		private void OpenSettingsWindow()
		{
			var settingsModel = new SettingsModel
			{
				MailgunApiKey = Core.Config.MailgunApiKey,
				MailgunDomainName = Core.Config.MailgunDomainName,
				OmniSyncEmail = Core.Config.OmniSyncEmail
			};
			SettingsWindow = new Settings(settingsModel);
			SettingsWindow.Show();

			SettingsOpen = true;
		}

		private static void ShowErrorMessageBox()
		{
			const string title = "Submission Error";
			var message = $"{Config.AppTitle} experienced an error while submitting your task to the Omni Sync Server.  Please check your configuration settings and try again.";
			MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}

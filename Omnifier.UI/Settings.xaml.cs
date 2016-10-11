using Omnifier.UI.Models;
using System;
using System.Windows;

namespace Omnifier.UI
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		private static SettingsModel Model { get; set; }

		public Settings(SettingsModel settings)
		{
			InitializeComponent();
			Model = settings;
			PopulateWindow();
		}

		private void PopulateWindow()
		{
			txtMailgunApiKey.Text = Model.MailgunApiKey;
			txtMailgunDomain.Text = Model.MailgunDomainName;
			txtOmniSyncEmail.Text = Model.OmniSyncEmail;
		}

		protected override void OnClosed(EventArgs e)
		{
			MainWindow.SettingsOpen = false;
			base.OnClosed(e);
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			Model.MailgunApiKey = txtMailgunApiKey.Text;
			Model.MailgunDomainName = txtMailgunDomain.Text;
			Model.OmniSyncEmail = txtOmniSyncEmail.Text;

			Model.Save();

			Close();
		}
	}
}

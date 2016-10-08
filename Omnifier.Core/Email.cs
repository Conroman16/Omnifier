using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Omnifier.Core
{
	public class EmailResponse
	{
		public string message { get; set; }
		public string id { get; set; }
	}

	public static class Email
	{
		private const string ApiUrl = "https://api.mailgun.net/v3/";

		public static IRestResponse<EmailResponse> SendEmail(string itemName, string itemNotes = " ")
		{
			var request = new RestRequest
			{
				Method = Method.POST,
				Resource = "{domain}/messages"
			};

			request.AddParameter("domain", Config.MailgunDomainName, ParameterType.UrlSegment);
			request.AddParameter("from", Config.LocalSenderEmail);
			request.AddParameter("to", Config.OmniSyncEmail);
			request.AddParameter("subject", itemName);
			request.AddParameter("text", string.IsNullOrEmpty(itemNotes) ? " " : itemNotes);

			var client = new RestClient
			{
				BaseUrl = new Uri(ApiUrl),
				Authenticator = new HttpBasicAuthenticator("api", Config.MailgunApiKey)
			};

			return client.Execute<EmailResponse>(request);
		}
	}
}

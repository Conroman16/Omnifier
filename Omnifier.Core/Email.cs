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
		private static string ApiUrl => "https://api.mailgun.net/v3/";
		private static string ApiKey => "key-fd4aa938409a3062fae4174209749a08";
		private static string DomainName => "sandbox127.mailgun.org";
		private static string Sender => $"Conroman16 <omnifier@{DomainName}>";
		private static string Recipient => "conroman16.y385a@sync.omnigroup.com";

		public static IRestResponse<EmailResponse> SendEmail(string itemName, string itemNotes)
		{
			var request = new RestRequest
			{
				Method = Method.POST,
				Resource = "{domain}/messages"
			};

			request.AddParameter("domain", DomainName, ParameterType.UrlSegment);
			request.AddParameter("from", Sender);
			request.AddParameter("to", Recipient);
			request.AddParameter("subject", itemName);
			
			if (itemNotes != null)
				request.AddParameter("text", itemNotes);

			var client = new RestClient
			{
				BaseUrl = new Uri(ApiUrl),
				Authenticator = new HttpBasicAuthenticator("api", ApiKey)
			};

			return client.Execute<EmailResponse>(request);
		}
	}
}

// ReSharper disable MemberCanBePrivate.Global
namespace Omnifier.Core.Models
{
	public class OmniTask
	{
		public string Name { get; set; }
		public string Notes { get; set; }

		public bool Submit()
		{
			var response = Email.SendEmail(Name, Notes);
			return (response.Data.message ?? "").ToLower().Contains("queued");
		}

		public OmniTask() { }
		public OmniTask(string name, string notes = "")
		{
			Name = name;
			Notes = notes;
		}
	}
}

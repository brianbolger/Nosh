using Nancy;
using Raven.Client;

namespace Nosh.Api.Modules
{
	public class IndexModule : NancyModule
	{
		private IDocumentSession DocumentSession { get; set; }

		public IndexModule(IDocumentSession documentSession)
		{
			DocumentSession = documentSession;

			Get["/"] = p => "Nosh API root";
		}
	}
}
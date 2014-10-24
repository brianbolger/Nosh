using System.Configuration;
using Nancy;
using Nancy.TinyIoc;
using Raven.Client;
using Raven.Client.Document;

namespace Nosh.Api
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			base.ConfigureApplicationContainer(container);

			var documentStore = new DocumentStore
				{
					Url = ConfigurationManager.AppSettings["NoshDB_Url"],
					ApiKey = ConfigurationManager.AppSettings["NoshDB_ApiKey"],
					DefaultDatabase = ConfigurationManager.AppSettings["NoshDB_Name"]
				};

			documentStore.Initialize();
			container.Register(documentStore, "DocumentStore");
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			base.ConfigureRequestContainer(container, context);

			var docStore = container.Resolve<DocumentStore>("DocumentStore");
			var documentSession = docStore.OpenSession();
			container.Register<IDocumentSession>(documentSession);
		}
	}
}
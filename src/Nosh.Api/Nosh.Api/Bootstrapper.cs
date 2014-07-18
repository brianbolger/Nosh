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
					ConnectionStringName = "NoshDB"
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
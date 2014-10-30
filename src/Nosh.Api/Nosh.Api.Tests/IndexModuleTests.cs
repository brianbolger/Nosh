﻿using System;
using System.Linq;
using Nancy;
using Nancy.Testing;
using Nosh.Api.Model;
using Nosh.Api.Modules;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Xunit;

namespace Nosh.Api.Tests
{
	public class IndexModuleTests
	{
		private static IDocumentStore _documentStore;

		[Fact]
		public void POST_User()
		{
			var userId = Guid.NewGuid().ToString();

			var user = new User
				{
					Id = userId,
					Name = "Joey"
				};

			var browser = GetConfiguredBrowser();
			var response = browser.Post("/api/users", with => with.JsonBody(user));
			Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

			using (var session = GetDocumentSession())
			{
					var savedUser = session.Load<User>(userId);
					Assert.Equal(user, savedUser);
			}
		}

		[Fact]
		public void POST_Order_ShouldAddAnOrderForToday()
		{
			var orderId = Guid.NewGuid().ToString();

			var order = new Order
				{ 
					Id = orderId,
					Contents = "Ham sambo",
					Price = 3.99m,
					User = GetUserByName("Joey")
				};

			var browser = GetConfiguredBrowser();
			var response = browser.Post("/api/orders", with => with.JsonBody(order));

			Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

			using (var session = GetDocumentSession())
			{
				var savedOrder = session.Load<Order>(orderId);
				Assert.Equal(order, savedOrder);
			}
		}

		private User GetUserByName(string name)
		{
			// Might need to create this if it doesn't exist...

			return GetDocumentSession().Query<User>().FirstOrDefault(u => u.Name == name);
		}

		private static IDocumentStore DocumentStore
		{
			get
			{
				if (_documentStore != null)
					return _documentStore;

				_documentStore = new EmbeddableDocumentStore
					{
						RunInMemory = true,
					};

				//_documentStore = new DocumentStore
				//	{
				//		ConnectionStringName = "NoshDB"
				//	};

				_documentStore.Initialize();

				return _documentStore;
			}
		}

		private static Browser GetConfiguredBrowser()
		{
			var browser = new Browser(config =>
				{
					config.Module<IndexModule>();
					config.Dependency<IDocumentSession>(GetDocumentSession());
				});

			return browser;
		}

		private static IDocumentSession GetDocumentSession()
		{
			return DocumentStore.OpenSession();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Nosh.Api.Indexes;
using Nosh.Api.Model;
using Raven.Client;

namespace Nosh.Api.Modules
{
	public class IndexModule : NancyModule
	{
		private IDocumentSession DocumentSession { get; set; }

		public IndexModule(IDocumentSession documentSession) : base("/api")
		{
			DocumentSession = documentSession;

			Get["/"] = p => "Nosh API root";

			Get["/locations"] = p => GetLocations();
			Get["/locations/{location}"] = p => GetLocationByName(p.location.ToString());
			
			//Get["/locations/{location}/dailyorders"] = p => ...
			// have an overload querystring to specify the date?

			Get["/menus"] = p => GetMenus();
			Get["/menus/{menu}"] = p => GetMenuByName(p.menu.ToString());

			Get["/users/{user}"] = p => GetUserByName(p.user.ToString());
			Get["/users/{user}/orders"] = p => GetOrdersByUser(p.user.ToString());

			Post["/users"] = p => AddUser(this.Bind<User>());
			Post["/orders"] = p => AddOrder(this.Bind<Order>());
		}

		private Response GetLocations()
		{
			return Response.AsJson(DocumentSession.Query<Location>());
		}

		private Response GetLocationByName(string locationName)
		{
			var location = DocumentSession.Query<Location>().FirstOrDefault(l => l.Name.Equals(locationName, StringComparison.OrdinalIgnoreCase));
			return location == null ? HttpStatusCode.NotFound : Response.AsJson(location);
		}

		private Response GetMenus()
		{
			return Response.AsJson(DocumentSession.Query<Menu>());
		}

		private Response GetMenuByName(string menuName)
		{
			var menu = DocumentSession.Query<Menu>().FirstOrDefault(l => l.Name.Equals(menuName, StringComparison.OrdinalIgnoreCase));
			return menu == null ? HttpStatusCode.NotFound : Response.AsJson(menu);
		}

		private Response GetUserByName(string userName)
		{
			var user = DocumentSession.Query<User>().FirstOrDefault(l => l.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
			return user == null ? HttpStatusCode.NotFound : Response.AsJson(user);
		}

		private Response GetOrdersByUser(string userName)
		{
			using (var session = DocumentSession)
			{
				var ordersByUser = session.Query<Orders_ByUserName.Result, Orders_ByUserName>().Where(o => o.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));

				// Not convinced that retrieving the ids & loading them is the best way,
				//  surely I can ask the index for the results directly...?

				var orderIds = ordersByUser.Select(obu => obu.Id);
				return Response.AsJson(session.Load<Order>(orderIds));
			}
		}

		private Response AddUser(User user)
		{
			DocumentSession.Store(user, string.Format("users/{0}", user.Name));
			DocumentSession.SaveChanges();
			return HttpStatusCode.Accepted;
		}

		private Response AddOrder(Order order)
		{
			DocumentSession.Store(order);
			DocumentSession.SaveChanges();
			return HttpStatusCode.Accepted;
		}
	}
}
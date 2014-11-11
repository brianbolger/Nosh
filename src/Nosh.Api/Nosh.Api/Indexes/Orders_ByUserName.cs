using System.Linq;
using Nosh.Api.Model;
using Raven.Client.Indexes;

namespace Nosh.Api.Indexes
{
	public class Orders_ByUserName : AbstractIndexCreationTask<Order, Orders_ByUserName.Result>
	{
		public class Result
		{
			public string Id { get; set; }
			public string UserName { get; set; }
		}

		public Orders_ByUserName()
		{
			Map = orders =>
				from order in orders
				select new
					{
						order.Id,
						UserName = LoadDocument<User>(order.UserId).Name
					};
		}
	}
}
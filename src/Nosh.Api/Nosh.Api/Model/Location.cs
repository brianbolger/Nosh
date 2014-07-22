using System.Collections.Generic;

namespace Nosh.Api.Model
{
	public class Location
	{
		private readonly List<Menu> _menus = new List<Menu>();

		public string Id { get; private set; }

		public string Name { get; set; }

		public IEnumerable<Menu> Menus
		{
			get { return _menus; }
		}

		public void AddMenu(Menu menu)
		{
			_menus.Add(menu);
		}
	}
}
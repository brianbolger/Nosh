using System.Collections.Generic;

namespace Nosh.Api.Model
{
	public class Section
	{
		private List<MenuItem> _menuItems = new List<MenuItem>();

		public string Name { get; set; }

		public string Description { get; set; }

		public string Tag { get; set; }

		public IEnumerable<MenuItem> MenuItems
		{
			get { return _menuItems; }
			private set { _menuItems = value as List<MenuItem>; }

		}

		public void AddMenuItem(MenuItem menuItem)
		{
			_menuItems.Add(menuItem);
		}

		public override string ToString()
		{
			return string.Format("Section: {0}", Name);
		}
	}
}
using System.Collections.Generic;

namespace Nosh.Api.Model
{
	public class Menu
	{
		private List<Section> _sections = new List<Section>();

		public string Id { get; private set; }

		public string Name { get; set; }

		public IEnumerable<Section> Sections
		{
			get { return _sections; }
			private set { _sections = value as List<Section>; }
		}

		public void AddSection(Section section)
		{
			_sections.Add(section);
		}

		public override string ToString()
		{
			return string.Format("Menu: {0}", Name);
		}
	}
}
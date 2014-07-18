using Nancy;

namespace Nosh.Api.Modules
{
	public class IndexModule : NancyModule
	{
		public IndexModule()
		{
			Get["/"] = p => "Nosh API root";
		}
	}
}
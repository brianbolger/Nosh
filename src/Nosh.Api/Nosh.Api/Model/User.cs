using System;

namespace Nosh.Api.Model
{
	public class User : IEquatable<User>
	{
		public string Id { get; set; }
		public string Name { get; set; }

		#region Equality members

		public bool Equals(User other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Id, other.Id) && string.Equals(Name, other.Name);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((User) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Id != null ? Id.GetHashCode() : 0)*397) ^ (Name != null ? Name.GetHashCode() : 0);
			}
		}

		public static bool operator ==(User left, User right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(User left, User right)
		{
			return !Equals(left, right);
		}

		#endregion

	}
}
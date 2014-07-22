using System;

namespace Nosh.Api.Model
{
	public class Order : IEquatable<Order>
	{
		public string Id { get; private set; }
		public string UserName { get; set; }
		//public User User { get; set; }
		public string Contents { get; set; }
		public decimal Price { get; set; }

		public override string ToString()
		{
			return string.Format(
				"UserName:{0} Contents:{1} Price:{2}",
				UserName, Contents, Price);
		}

		#region Equality Operators

		public bool Equals(Order other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(UserName, other.UserName) && string.Equals(Contents, other.Contents) && Price == other.Price;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Order)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = (UserName != null ? UserName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Contents != null ? Contents.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Price.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Order left, Order right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Order left, Order right)
		{
			return !Equals(left, right);
		}

		#endregion
	}
}
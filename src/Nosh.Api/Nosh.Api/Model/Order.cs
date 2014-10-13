using System;

namespace Nosh.Api.Model
{
	public class Order : IEquatable<Order>
	{
		public Order()
		{
			DateTime = DateTime.Now;
		}

		public string Id { get; set; }

		public User User { get; set; }
		public string Contents { get; set; }
		public decimal Price { get; set; }
		public DateTime DateTime { get; set; }

		public override string ToString()
		{
			return string.Format("User: {0}, Contents: {1}, Price: {2}, DateTime: {3}", User.Name, Contents, Price, DateTime);
		}

		#region Equality members
		
		public bool Equals(Order other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Id, other.Id) && Equals(User, other.User) && string.Equals(Contents, other.Contents) &&
			       Price == other.Price;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Order) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Id != null ? Id.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (User != null ? User.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (Contents != null ? Contents.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ Price.GetHashCode();
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
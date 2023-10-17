namespace LES.Domain.Models
{
    public class Client
    {
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool Active { get; set; }
		public List<Address> Address { get; set; }
		public List<Order> Orders { get; set; }
		public List<Card> PaymentMethods { get; set; }

	}
}

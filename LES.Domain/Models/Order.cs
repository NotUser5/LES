namespace LES.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Card Card { get; set; }
		public DateTime OrderDate { get; set; }
		public int ClientId { get; set; }
		public Client Client { get; set; }
        public bool Active { get; set; }
    }
}

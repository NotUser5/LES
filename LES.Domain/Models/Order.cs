namespace LES.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Card Card { get; set; }
    }
}

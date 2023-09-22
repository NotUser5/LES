namespace LES.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

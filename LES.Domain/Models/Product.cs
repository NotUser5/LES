namespace LES.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qtd { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
	}
}

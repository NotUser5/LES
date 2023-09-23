namespace LES.Domain.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int ZipCode { get; set; }
        public string? Description { get; set; }
    }
}

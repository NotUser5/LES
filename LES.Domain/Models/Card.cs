namespace LES.Domain.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Brand { get; set; }
        public string HolderName { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

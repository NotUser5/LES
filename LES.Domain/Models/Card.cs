namespace LES.Domain.Models
{
	public class Card
	{
		public Guid Id { get; set; }
		public int ClientId { get; set; }
		public int CardNumber { get; set; }
		public string Brand { get; set; }
		public string CardHolderName { get; set; }
		public int Cvv { get; set; }
		public DateTime ExpirationDate { get; set; }
	}
}

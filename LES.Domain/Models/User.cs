namespace LES.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        //public string Nickname { get; set; }
        public Address Address{ get; set; }
    }
}

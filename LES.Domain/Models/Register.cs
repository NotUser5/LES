namespace LES.Domain.Models
{
    //todo: take a look on register login flow
    public class Register
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; } = string.Empty;
    }
}

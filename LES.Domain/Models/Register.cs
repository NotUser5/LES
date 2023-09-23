namespace LES.Domain.Models
{
    //todo: take a look on register login flow
    public class Register
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
    }
}

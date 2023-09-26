using Microsoft.AspNetCore.Identity;

namespace LES.Domain.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public DateTime Birthdate { get; set; }
        //public string Cpf { get; set; }
        //public string Nickname { get; set; }
        //public Address Address{ get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace LES.Domain.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; } = string.Empty;
        //public string Nickname { get; set; }
        //public Address Address{ get; set; }
    }
}

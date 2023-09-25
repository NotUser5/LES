using System.ComponentModel.DataAnnotations;

namespace LES.Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthdate { get; set; }
        //public string Nickname { get; set; }
        //public Address Address{ get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LES.Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Cpf is required")]
        public string Cpf { get; set; }
        public DateTime Birthdate { get; set; }
        //public string Nickname { get; set; }
        //public Address Address{ get; set; }
    }
}

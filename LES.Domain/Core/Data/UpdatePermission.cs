using System.ComponentModel.DataAnnotations;

namespace LES.Domain.Core.Data
{
    public class UpdatePermission
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}

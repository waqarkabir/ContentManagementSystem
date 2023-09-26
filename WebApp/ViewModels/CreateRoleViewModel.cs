using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

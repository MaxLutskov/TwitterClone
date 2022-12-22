using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Server.API.Controllers.DTO.Users
{
    public class UserInput
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

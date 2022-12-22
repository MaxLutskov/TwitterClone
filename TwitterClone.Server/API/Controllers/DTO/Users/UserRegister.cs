using System.ComponentModel.DataAnnotations;
using TwitterClone.Business.Models;

namespace TwitterClone.Server.API.Controllers.DTO.Users
{
    public class UserRegister
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        public UserModel ToUserModel()
        {
            return new UserModel
            {
                Email = Email,
                Password = Password,
                UserName = UserName
            };
        }
    }
}

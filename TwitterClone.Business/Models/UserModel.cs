using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwitterClone.Business.Abstraction;

namespace TwitterClone.Business.Models
{
    public class UserModel : BaseModel
    {
        [Required, Column(TypeName = "varchar(200)")]
        public string UserName { get; set; } = "";

        [Required, Column(TypeName = "varchar(200)")]
        public string Password { get; set; } = "";

        [Required, Column(TypeName = "varchar(200)")]
        public string Salt { get; set; } = "";

        [Required, Column(TypeName = "varchar(200)")]
        public string IdentityName { get; set; } = "";

        [Required, Column(TypeName = "varchar(200)")]
        public string Email { get; set; } = "";

        [Column(TypeName = "varchar(400)")]
        public string Bio { get; set; } = "";

        [Column(TypeName = "date")]
        public DateTime BirthDate { get ; set; }

        public List<TweetModel>? Tweets { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwitterClone.Business.Abstraction;

namespace TwitterClone.Business.Models
{
    public class TweetModel : BaseModel
    {
        [Required, Column(TypeName = "varchar(50)")]
        public Guid UserId { get; set; }

        [Required, Column(TypeName = "varchar(500)")]
        public string Content { get; set; } = "";
        public TweetModel? RootTweet { get; set; }
        public List<TweetModel>? Tweets { get; set; }
        public int Likes { get; set; } = 0;
    }
}

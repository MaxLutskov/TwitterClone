using TwitterClone.Business.Models;

namespace TwitterClone.Server.API.Controllers.DTO.Tweets
{
    public class TweetInput
    {
        public string Content { get; set; } = String.Empty;
        public TweetModel? RootTweet { get; set; } = new TweetModel();
        public TweetModel ToModel()
        {
            return new TweetModel()
            {
                Content = Content,
                RootTweet = RootTweet
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TwitterClone.Business.Models;

namespace TwitterClone.MSSQL.EFConexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TweetModel> Tweets { get; set; }
        
    }
}

using Microsoft.EntityFrameworkCore;
using TwitterClone.Business.Models;

namespace TwitterClone.MSSQL.EFConexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TweetModel> Tweets { get; set; }
        
    }
}

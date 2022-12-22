using Microsoft.EntityFrameworkCore;
using TwitterClone.Business.Abstraction;
using TwitterClone.Business.IRepositories;
using TwitterClone.Business.Models;
using TwitterClone.MSSQL.EFConexts;

namespace TwitterClone.MSSQL.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly DataContext db;
        public TweetRepository(DataContext db)
        {
            this.db = db;
        }

        public async Task<TweetModel> CreateAsync(TweetModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;

            await db.Tweets.AddAsync(model);
            db.SaveChanges();
            return model;
        }

        public async void Delete(Guid id)
        {
            var tweet = await GetByIdAsync(id);
            if (tweet == null)
                throw new NullReferenceException();
            db.Tweets.Remove(tweet);
            db.SaveChanges();
        }

        public async Task<EntitiesSet<TweetModel>> GetAllAsync(int pageSize, int page)
        {
            var tweets = await db.Tweets.OrderByDescending(x => x.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            if (tweets == null)
                throw new NullReferenceException();
            var total = await db.Tweets.CountAsync();
            EntitiesSet<TweetModel> entitiesSet = new()
            {
                Entities = tweets,
                PageSize = pageSize,
                Total = total
            };
            return entitiesSet;
        }

        public async Task<TweetModel> GetByIdAsync(Guid id)
        {
            var tweet = await db.Tweets.FirstOrDefaultAsync(t => t.Id == id);
            if (tweet == null)
                throw new NullReferenceException();

            return tweet;
        }

        public async Task<EntitiesSet<TweetModel>> GetByUserIdAsync(Guid userId, int pageSize, int page)
        {
            var tweets = await db.Tweets.Skip((page - 1) * pageSize).Take(pageSize).Where(t => t.UserId == userId).ToListAsync();
            var total = await db.Tweets.Where(t => t.UserId == userId).CountAsync();
            if (tweets == null)
                throw new NullReferenceException();
            EntitiesSet<TweetModel> entitiesSet = new()
            {
                Entities = tweets,
                PageSize = pageSize,
                Total = total
            };
            return entitiesSet;
        }

        public TweetModel Update(TweetModel model)
        {
            db.Tweets.Update(model);
            db.SaveChanges();
            return model;
        }
    }
}

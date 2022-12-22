using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Abstraction;
using TwitterClone.Business.Models;

namespace TwitterClone.Business.IRepositories
{
    public interface ITweetRepository
    {
        public Task<TweetModel> GetByIdAsync(Guid id);
        public Task<EntitiesSet<TweetModel>> GetByUserIdAsync(Guid userId, int pageSize, int page);
        public Task<EntitiesSet<TweetModel>> GetAllAsync(int pageSize, int page);
        public Task<TweetModel> CreateAsync(TweetModel model);
        public TweetModel Update(TweetModel model);
        public void Delete(Guid id);
    }
}

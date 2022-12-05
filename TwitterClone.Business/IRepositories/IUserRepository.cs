using TwitterClone.Business.Models;

namespace TwitterClone.Business.IRepositories
{
    public interface IUserRepository
    {
        public Task<UserModel> GetByIdAsync(Guid id);
        public Task<UserModel> GetByEmailAsync(string email);
        public Task<IEnumerable<UserModel>> GetAllAsync();
        public Task<UserModel> CreateAsync(UserModel model);
        public UserModel UpdateAsync(UserModel model);
        public void Delete(Guid id);
    }
}

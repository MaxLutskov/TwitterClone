using Microsoft.EntityFrameworkCore;
using TwitterClone.Business.Extension;
using TwitterClone.Business.IRepositories;
using TwitterClone.Business.Models;
using TwitterClone.MSSQL.EFConexts;

namespace TwitterCloneMSSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;
        public UserRepository(DataContext db)
        {
            this.db = db;
        }
        public async Task<UserModel> CreateAsync(UserModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.Password = model.Password.CreateMD5WithSalt(out var salt);
            model.Salt = salt;
            model.UniqueName = "user" + Guid.NewGuid().ToString();

            await db.Users.AddAsync(model);
            db.SaveChanges();
            return model;
        }

        public async void Delete(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
                throw new NullReferenceException();
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await db.Users.ToListAsync();
            return users;
        }

        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;

            return user;
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new NullReferenceException();

            return user;
        }

        public UserModel Update(UserModel model)
        {
            db.Users.Update(model);
            db.SaveChanges();
            return model;
        }
    }
}

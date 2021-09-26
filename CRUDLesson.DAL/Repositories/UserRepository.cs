using System.Threading.Tasks;
using CRUSLesson.Domain.Entity;
using CRUSLesson.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDLesson.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Insert(User user)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> Get(string name)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Users.FirstOrDefaultAsync(x => x.Name == name);
            }
        }
        
        public async Task Update(User user)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(User user)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
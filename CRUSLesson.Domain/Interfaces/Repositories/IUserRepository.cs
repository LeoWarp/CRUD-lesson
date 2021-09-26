using System.Threading.Tasks;
using CRUSLesson.Domain.Entity;

namespace CRUSLesson.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User user);
        
        Task<User> Get(string name);

        Task Delete(User user);

        Task Update(User user);
    }
}
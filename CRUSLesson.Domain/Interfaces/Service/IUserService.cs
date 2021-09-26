using System.Threading.Tasks;
using CRUSLesson.Domain.Response;

namespace CRUSLesson.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(string name, string email, string password);

        Task<BaseResponse> GetUser(string name);

        Task<BaseResponse> Delete(string name);
        
        Task<BaseResponse> Update(string name, string newName);
    }
}
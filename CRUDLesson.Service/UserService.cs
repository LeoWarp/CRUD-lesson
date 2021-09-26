using System;
using System.Threading.Tasks;
using CRUDLesson.DAL.Repositories;
using CRUSLesson.Domain.Entity;
using CRUSLesson.Domain.Interfaces.Repositories;
using CRUSLesson.Domain.Interfaces.Service;
using CRUSLesson.Domain.Response;

namespace CRUDLesson.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> CreateUser(string name, string email, string password)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var user = await _userRepository.Get(name);
                if (user == null)
                {
                    user = new User()
                    {
                        Name = name,
                        Email = email
                    };
                    await _userRepository.Insert(user);

                    baseResponse.Data = user;
                    baseResponse.Message = $"Пользователь {user.Name} добавился";
                    return baseResponse;
                }
                baseResponse.Message = $"Пользователь {user.Name} уже есть";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> GetUser(string name)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var user = await _userRepository.Get(name);
                if (user != null)
                {
                    baseResponse.Data = user;
                    return baseResponse;
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> Delete(string name)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var user = await _userRepository.Get(name);
                if (user != null)
                {
                    await _userRepository.Delete(user);

                    baseResponse.Message = "Пользователь удалён";
                    baseResponse.Data = user;
                    return baseResponse;
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> Update(string name, string newName)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var user = await _userRepository.Get(name);
                if (user != null)
                {
                    user.Name = newName;
                    await _userRepository.Update(user);

                    baseResponse.Data = user;
                    baseResponse.Message = $"Имя обновилось с {name} на {newName}";
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }
    }
}
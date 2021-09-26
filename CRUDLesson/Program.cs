using System;
using System.Threading.Tasks;
using CRUDLesson.DAL.Repositories;
using CRUDLesson.Service;
using CRUSLesson.Domain.Entity;

namespace CRUDLesson
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Create\n" +
                                  "2. Read\n" +
                                  "3. Update\n" +
                                  "4. Delete");
                Console.WriteLine("Введите команду:");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        await Create();
                        break;
                    case "2":
                        await Read();
                        break;
                    case "3":
                        await Update();
                        break;
                    case "4":
                        await Delete();
                        break;
                    default:
                        return;
                }
            }
        }
        
        private static async Task Create()
        {
            var userService = new UserService(new UserRepository());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();
            
            Console.WriteLine("Введите почту:");
            var email = Console.ReadLine();
            
            Console.WriteLine("Введите пароль:");
            var password = Console.ReadLine();
            
            var response = await userService.CreateUser(name, email, password);
            Console.WriteLine(response.Message);
        }
        
        private static async Task Read()
        {
            var userService = new UserService(new UserRepository());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            var user = (await userService.GetUser(name)).Data as User;
            Console.WriteLine(user?.ToString());
        }

        private static async Task Update()
        {
            var userService = new UserService(new UserRepository());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите новое имя:");
            var newName = Console.ReadLine();

            var response = await userService.Update(name, newName);
            Console.WriteLine(response.Message);
        }
        
        private static async Task Delete()
        {
            var userService = new UserService(new UserRepository());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            var response = await userService.Delete(name);
            Console.WriteLine(response.Message);
        }
    }
}
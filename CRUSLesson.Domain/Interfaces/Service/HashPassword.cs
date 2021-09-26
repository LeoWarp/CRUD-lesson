using System.Security.Cryptography;

namespace CRUSLesson.Domain.Interfaces.Service
{
    public class HashPassword
    {
        public string Hash()
        {
            using (var sha = new SHA256Managed())
            {
                
            }

            return "";
        }
    }
}
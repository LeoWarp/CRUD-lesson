namespace CRUSLesson.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name = {Name} | Email = {Email}";
        }
    }
}
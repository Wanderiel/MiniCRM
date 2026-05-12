namespace Domain.Models
{
    public class Client
    {
        public Client(string name, string description, string email, int id)
        {
            Name = name;
            Description = description;
            Email = email;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
    }
}

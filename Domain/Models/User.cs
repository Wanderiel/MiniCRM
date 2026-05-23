namespace Domain.Models
{
    public class User
    {
        public User()
        { }

        public User(string name)
        {
            Name = name;
        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description}";
        }
    }
}

namespace API.Dtos
{
    public class CreatedUserDto
    {
        public CreatedUserDto(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

namespace Domain.Models.Users
{
    public record FullName
    {
        private FullName() { }

        private FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static FullName Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException($"Не верный формат {nameof(firstName)}");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException($"Не верный формат {nameof(lastName)}");

            return new FullName(firstName, lastName);
        }
    }
}

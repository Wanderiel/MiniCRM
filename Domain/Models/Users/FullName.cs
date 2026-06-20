namespace Domain.Models.Users
{
    public class FullName
    {
        private readonly string _firstName;
        private readonly string _lastName;

        private FullName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;

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

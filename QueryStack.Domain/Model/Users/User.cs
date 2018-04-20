namespace QueryStack.Domain.Model.Users
{
    public class User
    {
        public User(string name, int age, bool enabled, RegisterStatus status)
        {
            Name = name;
            Age = age;
            Enabled = enabled;
            Status = status;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public bool Enabled { get; private set; }

        public RegisterStatus Status { get; private set; }
    }
}

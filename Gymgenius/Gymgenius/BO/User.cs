using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class User
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public bool IsTrainer{ get; set; }

        [SetsRequiredMembers]
        public User(int id, string firstName, string lastName, int? age, string? email, bool isTrainer)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            IsTrainer = isTrainer;
        }

        public override string ToString()
        {
            return $"User ID: {Id}, User Name: {FirstName} {LastName}, Email: {Email}";
        }
    }
}

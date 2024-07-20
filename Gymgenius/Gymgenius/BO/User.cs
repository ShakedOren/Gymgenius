using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public bool IsTrainer{ get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        protected bool Equals(User other)
            {
            return UserName == other.UserName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, FirstName, LastName, Age, Email, IsTrainer);
        }

        public override string ToString()
        {
            return $"UserName: {UserName}, User Name: {FirstName} {LastName}, Email: {Email}";
        }
    }
}

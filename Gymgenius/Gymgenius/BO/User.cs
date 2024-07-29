using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class User
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        public bool IsTrainer{ get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Range(1, 3, ErrorMessage = "RoleId must be between 1 and 3")]
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

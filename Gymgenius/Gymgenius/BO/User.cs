﻿using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class User
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public bool IsTrainer{ get; set; }

        public User(){}
        [SetsRequiredMembers]
        public User(string userName, string firstName, string lastName, int? age, string? email, bool isTrainer)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            IsTrainer = isTrainer;
        }

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

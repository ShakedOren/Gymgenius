using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class Exercise
    {
        public required string Name { get; set; }
        public Exercise(){}

        [SetsRequiredMembers]
        public Exercise(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Exercise Name: {Name}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Exercise other)
            {
                return Name.Equals(other.Name);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

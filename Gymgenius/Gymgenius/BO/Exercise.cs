using System.Diagnostics.CodeAnalysis;

namespace Gymgenius.bo
{
    public class Exercise
    {
        public string Name { get; set; }
        public Exercise(){}

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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Exercise)obj);
        }
        protected bool Equals(Exercise other)
        {
            return Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

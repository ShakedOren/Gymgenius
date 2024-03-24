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
    }
}

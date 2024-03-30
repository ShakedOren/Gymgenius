using Gymgenius.bo;
using Gymgenius.dal;
using System.Diagnostics.CodeAnalysis;

namespace GymGenius.BO
{
    public class TrainingProgram
    {
        public string Name { get; set; }

        [SetsRequiredMembers]
        public TrainingProgram(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrainingProgram)obj);
        }

        protected bool Equals(TrainingProgram other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

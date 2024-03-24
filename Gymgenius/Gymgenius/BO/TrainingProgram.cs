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
    }
}

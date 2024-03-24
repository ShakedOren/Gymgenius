using Gymgenius.bo;
using Gymgenius.dal;
using System.Diagnostics.CodeAnalysis;

namespace GymGenius.BO
{
    public class TrainingProgram
    {
        public required int Id { get; set; }
        public string Name { get; set; }
        public TrainingProgram(){}

        public TrainingProgram(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

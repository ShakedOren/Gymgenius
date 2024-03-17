using Gymgenius.bo;
using Gymgenius.dal;
using System.Diagnostics.CodeAnalysis;

namespace GymGenius.BO
{
    public class TrainingProgram
    {
        public required int Id { get; set; }

        public TrainingProgram(int id)
        {
            Id = id;
        }
    }
}

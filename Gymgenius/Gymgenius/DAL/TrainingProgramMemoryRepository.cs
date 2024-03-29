﻿using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.DAL
{
    public class TrainingProgramMemoryRepository : ITrainingProgramRepository
    {
        private List<TrainingProgram> _programs= [];

        public void AddTrainingProgram(TrainingProgram trainingProgram)
        {
            _programs.Add(trainingProgram);
        }

        public void DeleteTrainingProgram(int trainingProgramId)
        {
            _programs.Remove(GetTrainingProgramById(trainingProgramId));
        }

        public List<TrainingProgram> GetAllTrainingPrograms()
        {
            return _programs;
        }

        public TrainingProgram GetTrainingProgramById(int trainingProgramId)
        {
            return _programs.Find(u => u.Id == trainingProgramId) ?? throw new Exception("Program Not Found");
        }

        public bool IsTrainingProgramExists(int trainingProgramId)
        {
            return _programs.Any(u => u.Id == trainingProgramId);
        }
    }
}

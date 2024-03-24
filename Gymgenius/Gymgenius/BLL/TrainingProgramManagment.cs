﻿using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.bo
{
    public class TrainingProgramManagment
    {
        private readonly ITrainingProgramRepository _programs;

        public TrainingProgramManagment(ITrainingProgramRepository programs)
        {
            _programs = programs;
        }

        public async Task<TrainingProgram> GetTrainingProgramById(int trainingProgramId)
        {

            if (!await _programs.IsTrainingProgramExists(trainingProgramId))
            {
                throw new Exception("No program found.");
            }

            return await _programs.GetTrainingProgramById(trainingProgramId);
        }

        public async Task<List<TrainingProgram>> GetAllTrainingPrograms()
        {
            return await _programs.GetAllTrainingPrograms();
        }

        public async Task AddTrainingProgram(TrainingProgram trainingProgram)
        {
            await _programs.AddTrainingProgram(trainingProgram);
        }

        public async Task DeleteTrainingProgram(int trainingProgramId)
        {
            if (!await _programs.IsTrainingProgramExists(trainingProgramId))
            {
                throw new Exception("No program found.");
            }

            await _programs.DeleteTrainingProgram(trainingProgramId);
        }

        public async Task<bool> IsTrainingProgramExists(int trainingProgramId) 
        {
            return await _programs.IsTrainingProgramExists(trainingProgramId);
        }
    }
}
﻿using Gymgenius.dal;
using GymGenius.BO;
using GymGenius.DAL;

namespace Gymgenius.bo
{
    public class ExerciseManagment
    {
        private readonly IExerciseRepository _exercises;

        public ExerciseManagment(IExerciseRepository exercises)
        {
            _exercises = exercises;
        }

        public Exercise GetExerciseByName(string name)
        {
            if (!_exercises.IsExerciseExists(name))
            {
                throw new Exception("No exercise found.");
            }

            return _exercises.GetExerciseByName(name);
        }

        public List<Exercise> GetAllExercises()
        {
            return _exercises.GetAllExercises();
        }

        public void AddExercise(Exercise exercise)
        {
            _exercises.AddExercise(exercise);
        }

        public void DeleteExercise(string name)
        {

            if (!_exercises.IsExerciseExists(name))
            {
                throw new Exception("No exercise found.");
            }

            _exercises.DeleteExercise(name);
        }

        public bool IsExerciseExists(string name)
        {
            return _exercises.IsExerciseExists(name);
        }
    }
}
using Gymgenius.bll;
using Gymgenius.dal;
using GymGenius.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Gymgenius.Tests
{
    internal class Helper
    {
        private static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IUserRepository, UserMemoryRepository>().
            AddSingleton<IExerciseRepository, ExerciseMemoryRepository>().
            AddSingleton<IExerciseToProgramRepository, ExerciseToProgramMemoryRepository>().
            AddSingleton<IUserToProgramRepository, UserToProgramMemoryRepository>().
            AddSingleton<ITrainingProgramRepository, TrainingProgramMemoryRepository>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var provider = Provider();

            return provider.GetRequiredService<T>();
        }
    }
}

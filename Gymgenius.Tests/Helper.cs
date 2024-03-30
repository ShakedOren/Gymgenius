using Gymgenius.bll;
using Gymgenius.dal;
using GymGenius.DAL;
using Microsoft.Extensions.Configuration;
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
            services.AddSingleton<IUserRepository, UserMemoryRepository>();
            services.AddSingleton<IExerciseRepository, ExerciseMemoryRepository>();
            services.AddSingleton<IExerciseToProgramRepository, ExerciseToProgramMemoryRepository>();
            services.AddSingleton<IUserToProgramRepository, UserToProgramMemoryRepository>();
            services.AddSingleton<ITrainingProgramRepository, TrainingProgramMemoryRepository>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var provider = Provider();

            return provider.GetRequiredService<T>();
        }
    }
}

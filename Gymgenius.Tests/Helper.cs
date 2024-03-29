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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", false)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddSingleton<IUserRepository, UserMSSQLRepository>();
            services.AddSingleton<IExerciseRepository, ExerciseMSSQLRepository>();
            services.AddSingleton<IExerciseToProgramRepository, ExerciseToProgramMSSQLRepository>();
            services.AddSingleton<IUserToProgramRepository, UserToProgramMSSQLRepository>();
            services.AddSingleton<ITrainingProgramRepository, TrainingProgramMSSQLRepository>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var provider = Provider();

            return provider.GetRequiredService<T>();
        }
    }
}

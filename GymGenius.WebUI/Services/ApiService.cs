﻿
// Services/ApiService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Gymgenius.bo;
using GymGenius.BO;

namespace GymGenius.WebUI.Services
{
    public class ApiService(HttpClient httpClient)
    {
        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Exercise>>("/Exercise/list_exercises");
        }

		public async Task<Exercise> GetExerciseAsync(string name)
        {
            return await httpClient.GetFromJsonAsync<Exercise>($"/Exercise/get_exercise/{name}");
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            var response = await httpClient.PostAsJsonAsync("/Exercise/add_exercise", exercise);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteExerciseAsync(string name)
        {   
            var response = await httpClient.DeleteAsync($"/Exercise/delete_exercise/{name}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
	        return await httpClient.GetFromJsonAsync<IEnumerable<User>>("/User/list_users");
        }

        public async Task<User> GetUserAsync(string username)
        {
	        return await httpClient.GetFromJsonAsync<User>($"/User/get_user/{username}");
        }

        public async Task DeleteUserAsync(string username)
        {
	        var response = await httpClient.DeleteAsync($"/User/delete_user/{username}");
            response.EnsureSuccessStatusCode();
        }
		public async Task AddProgramAsync(TrainingProgram program)
		{
			var response = await httpClient.PostAsJsonAsync("/TrainingProgram/add_program", program);
            response.EnsureSuccessStatusCode();
		}
		public async Task<IEnumerable<TrainingProgram>> GetProgramsAsync()
		{
			return await httpClient.GetFromJsonAsync<IEnumerable<TrainingProgram>>("/TrainingProgram/list_programs");
		}
		public async Task DeleteProgramAsync(string name)
		{
			var response = await httpClient.DeleteAsync($"/TrainingProgram/delete_program/{name}");
            response.EnsureSuccessStatusCode();
		}
        public async Task<TrainingProgram> GetProgramAsync(string name)
        {
            return await httpClient.GetFromJsonAsync<TrainingProgram>($"/TrainingProgram/get_program/{name}");
        }
        public async Task<TrainingProgram?> GetUserProgramAsync(string username)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<TrainingProgram?>($"/UserToProgram/get_user_program/{username}");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Exercise>> GetExercisesOfProgramAsync(string name)
		{
			return await httpClient.GetFromJsonAsync<IEnumerable<Exercise>>($"/ExerciseToProgram/list_exercises/{name}");
		}
        public async Task AddProgramToUser(string username, string program)
        {
            await httpClient.PostAsync($"/UserToProgram/add_program_to_user/{username}/{program}", null);
        }

        public async Task RemoveProgramFromUser(string username)
        {
            await httpClient.DeleteAsync($"/UserToProgram/remove_program_from_user/{username}");
        }

        // User MethodsGetUserByUsername
        public async Task<string> LoginAsync(UserLogin userLoginDto)
        {
			var json = JsonSerializer.Serialize(userLoginDto);
            var response = await httpClient.PostAsJsonAsync("/Auth/login", userLoginDto);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }

        public async Task SignupAsync(User userSignupDto)
        {
            var response = await httpClient.PostAsJsonAsync("/Auth/signup", userSignupDto);
            response.EnsureSuccessStatusCode();
        }
        public async Task<Role?> GetUserRoleAsync(string username)
        {
            return await httpClient.GetFromJsonAsync<Role>($"/Role/user-role/{username}");
        }

        public async Task<List<Role>?> GetRolesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Role>>("/Role/list_roles");
        }
        public async Task UpdateUserRole(string username, int roleId)
        {
            await httpClient.PostAsync($"/User/change_user_role/{username}/{roleId}", null);
        }
		public async Task AddExerciseToProgramAsync(string exercise, string program)
		{
			await httpClient.PostAsync($"/ExerciseToProgram/add_exercise_to_program/{exercise}/{program}", null);
		}

		public async Task RemoveExerciseFromProgramAsync(string exercise, string program)
		{
			await httpClient.DeleteAsync($"/ExerciseToProgram/delete_exercise_from_program/{exercise}/{program}");
		}
        public async Task LogTrainingAsync(TrainingLog trainingLog)
        {
            var response = await httpClient.PostAsJsonAsync("/TrainingLog/log_training", trainingLog);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<TrainingLog>> GetTrainingLogsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TrainingLog>>("/TrainingLog/get_logs");
        }

        public async Task<IEnumerable<TrainingLog>> GetTrainingLogsByUserAsync(string userName)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TrainingLog>>($"/TrainingLog/get_logs_by_user/{userName}");
        }
    }
}

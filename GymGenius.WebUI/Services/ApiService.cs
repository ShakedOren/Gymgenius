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
            await httpClient.PostAsJsonAsync("/Exercise/add_exercise", exercise);
        }

        public async Task DeleteExerciseAsync(string name)
        {
            await httpClient.DeleteAsync($"/Exercise/delete_exercise/{name}");
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
	        return await httpClient.GetFromJsonAsync<IEnumerable<User>>("/User/list_users");
        }

        public async Task<User> GetUserAsync(string username)
        {
	        return await httpClient.GetFromJsonAsync<User>($"/User/get_user/{username}");
        }

        public async Task AddUserAsync(User user)
        {
	        await httpClient.PostAsJsonAsync("/User/add_user", user);
        }

        public async Task DeleteUserAsync(string username)
        {
	        await httpClient.DeleteAsync($"/User/delete_user/{username}");
        }
		public async Task AddProgramAsync(TrainingProgram program)
		{
			await httpClient.PostAsJsonAsync("/TrainingProgram/add_program", program);
		}
		public async Task<IEnumerable<TrainingProgram>> GetProgramsAsync()
		{
			return await httpClient.GetFromJsonAsync<IEnumerable<TrainingProgram>>("/TrainingProgram/list_programs");
		}
		public async Task DeleteProgramAsync(string name)
		{
			await httpClient.DeleteAsync($"/TrainingProgram/delete_program/{name}");
		}
		public async Task<TrainingProgram> GetProgramAsync(string name)
		{
			return await httpClient.GetFromJsonAsync<TrainingProgram>($"/TrainingProgram/get_program/{name}");
		}
		public async Task<IEnumerable<Exercise>> GetExercisesOfProgramAsync(string name)
		{
			return await httpClient.GetFromJsonAsync<IEnumerable<Exercise>>($"/ExerciseToProgram/list_exercises/{name}");
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
            await httpClient.PostAsJsonAsync("/Auth/signup", userSignupDto);
        }

        public async Task<string> GetUserRoleAsync(string username)
        {
            var response = await httpClient.GetStringAsync($"/Auth/user-role/{username}");
            return response;
        }
    }
}

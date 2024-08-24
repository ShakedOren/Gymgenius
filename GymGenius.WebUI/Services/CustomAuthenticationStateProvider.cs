    using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;

namespace GymGenius.WebUI.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(HttpClient httpClient, ApiService apiService, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _apiService = apiService;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = "";
            try
            {
                token = await _localStorage.GetItemAsync<string>("authToken");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var username = await GetUsernameFromTokenAsync();

            var claims = new List<Claim>
	        {
	            new Claim(ClaimTypes.Name, username)
	        };

            var role = await _apiService.GetUserRoleAsync(username);
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));

            var identity = new ClaimsIdentity(claims, "apiauth_type");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        public async Task<string> GetUsernameFromTokenAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var claims = ParseClaimsFromJwt(token);
            var usernameClaim = claims.FirstOrDefault(c => c.Type == "unique_name");

            return usernameClaim?.Value;
        }
        public async Task NotifyUserAuthentication(string token)
        {
	        await _localStorage.SetItemAsync("authToken", token);
			var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task NotifyUserLogout()
        {
	        await _localStorage.RemoveItemAsync("authToken");
			var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
			return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}

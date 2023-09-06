using Newtonsoft.Json;

namespace WDVA_ECommerce.Client.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _http;
		private readonly AuthenticationStateProvider _authStateProvider;

		public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
			_http=http;
			_authStateProvider=authStateProvider;
		}

		public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
		}

		public async Task<bool> IsUserAuthenticated()
		{
			return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
		}

		public async Task<ServiceResponse<string>> Login(UserLogin request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/login", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
		}

		public async Task<UserRegister> PopulateRandomUser()
		{
			//external API info
			string _apiUri = "https://randomuser.me/api/?nat=us";

			//make call to randomuser.me api and return the user to registration page
			var result = new UserRegister();

			// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
			var response = await _http.GetAsync(_apiUri);

			var randomUser = JsonConvert.DeserializeObject<RandomUser.Root>(await response.Content.ReadAsStringAsync()).results.FirstOrDefault();

			result.PersonalInfo = new PersonalInfo
			{
				FirstName= randomUser.name.first,
				LastName= randomUser.name.last,
				Street= $"{randomUser.location.street.number} {randomUser.location.street.name}",
				City= randomUser.location.city,
				State= randomUser.location.state,
				Zip= randomUser.location.postcode,
				Country= randomUser.location.country,
				Phone= randomUser.phone,
				DOB = randomUser.dob.date,
				Gender = randomUser.gender
			};

			result.Email = randomUser.email;
			result.Password = randomUser.login.password;
			result.ConfirmPassword = randomUser.login.password;

			return result;
		}

		public async Task<ServiceResponse<int>> Register(UserRegister request)
		{
			var result = await _http.PostAsJsonAsync("api/auth/register", request);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
		}
	}
}

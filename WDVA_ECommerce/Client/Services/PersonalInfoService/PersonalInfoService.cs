namespace WDVA_ECommerce.Client.Services.PersonalInfoService
{
	public class PersonalInfoService : IPersonalInfoService
	{
		private readonly HttpClient _http;

		public PersonalInfoService(HttpClient http)
        {
			_http=http;
		}
        public async Task<PersonalInfo> AddOrUpdatePersonalInfo(PersonalInfo personalInfo)
		{
			var response = await _http.PostAsJsonAsync("api/personalinfo", personalInfo);
			return response.Content.ReadFromJsonAsync<ServiceResponse<PersonalInfo>>().Result.Data;
		}

		public async Task<PersonalInfo> GetPersonalInfo()
		{
			var response = await _http.GetFromJsonAsync<ServiceResponse<PersonalInfo>>("api/personalinfo");
			return response.Data;
		}
	}
}

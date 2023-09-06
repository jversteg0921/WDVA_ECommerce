namespace WDVA_ECommerce.Server.Services.PersonalInfoService
{
	public class PersonalInfoService : IPersonalInfoService
	{
		private readonly DataContext _context;
		private readonly IAuthService _authService;

		public PersonalInfoService(DataContext context, IAuthService authService)
        {
			_context=context;
			_authService=authService;
		}
        public async Task<ServiceResponse<PersonalInfo>> AddOrUpdatePersonalInfo(PersonalInfo personalInfo, int? userId)
		{
			var response = new ServiceResponse<PersonalInfo>();
			var dbPersonalInfo = (await GetPersonalInfo()).Data;
			if(dbPersonalInfo == null) {
				if(userId != null)
				{
					personalInfo.UserId = (int)userId;
				}
				else
				{
					personalInfo.UserId = _authService.GetUserId();
				}				
				_context.PersonalInfo.Add(personalInfo);
				response.Data = personalInfo;
			}
			else
			{
				dbPersonalInfo.FirstName = personalInfo.FirstName;
				dbPersonalInfo.LastName = personalInfo.LastName;
				dbPersonalInfo.Street = personalInfo.Street;
				dbPersonalInfo.City = personalInfo.City;
				dbPersonalInfo.State = personalInfo.State;
				dbPersonalInfo.Zip = personalInfo.Zip;
				dbPersonalInfo.Country = personalInfo.Country;

				response.Data = dbPersonalInfo;
			}
			await _context.SaveChangesAsync();

			return response;
		}

		public async Task<ServiceResponse<PersonalInfo>> GetPersonalInfo()
		{
			int userId = _authService.GetUserId();
			var personalInfo = await _context.PersonalInfo.FirstOrDefaultAsync(p => p.UserId == userId);

			return new ServiceResponse<PersonalInfo>
			{
				Data = personalInfo
			};
        }
	}
}

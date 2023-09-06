namespace WDVA_ECommerce.Server.Services.PersonalInfoService
{
	public interface IPersonalInfoService
	{
		Task<ServiceResponse<PersonalInfo>> GetPersonalInfo();
		Task<ServiceResponse<PersonalInfo>> AddOrUpdatePersonalInfo(PersonalInfo personalInfo, int? userId);
	}
}

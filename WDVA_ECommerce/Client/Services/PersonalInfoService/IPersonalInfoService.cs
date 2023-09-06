namespace WDVA_ECommerce.Client.Services.PersonalInfoService
{
	public interface IPersonalInfoService
	{
		Task<PersonalInfo> GetPersonalInfo();
		Task<PersonalInfo> AddOrUpdatePersonalInfo(PersonalInfo personalInfo);
	}
}

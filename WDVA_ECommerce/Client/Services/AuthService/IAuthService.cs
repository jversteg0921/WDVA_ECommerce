namespace WDVA_ECommerce.Client.Services.AuthService
{
	public interface IAuthService
	{
		Task<ServiceResponse<int>> Register(UserRegister request);
		Task<ServiceResponse<string>> Login(UserLogin request);
		Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
		Task<UserRegister> PopulateRandomUser();
		Task<bool> IsUserAuthenticated();
	}
}

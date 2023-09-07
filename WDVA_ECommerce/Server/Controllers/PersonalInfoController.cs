using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WDVA_ECommerce.Server.Controllers
{
	/// <summary>
	/// Manage Personal Information of User
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class PersonalInfoController : ControllerBase
	{
		private readonly IPersonalInfoService _personalInfoService;

		public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
			_personalInfoService=personalInfoService;
		}

		/// <summary>
		/// Get any personal info available for user
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<PersonalInfo>>> GetPersonalInfo()
		{
			return await _personalInfoService.GetPersonalInfo();
		}

		/// <summary>
		/// Adds or Updates personal information of user
		/// </summary>
		/// <param name="personalInfo"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<ServiceResponse<PersonalInfo>>> AddOrUpdatePersonalInfo(PersonalInfo personalInfo, int? userId)
		{
			return await _personalInfoService.AddOrUpdatePersonalInfo(personalInfo, userId);
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WDVA_ECommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonalInfoController : ControllerBase
	{
		private readonly IPersonalInfoService _personalInfoService;

		public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
			_personalInfoService=personalInfoService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<PersonalInfo>>> GetPersonalInfo()
		{
			return await _personalInfoService.GetPersonalInfo();
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<PersonalInfo>>> AddOrUpdatePersonalInfo(PersonalInfo personalInfo, int? userId)
		{
			return await _personalInfoService.AddOrUpdatePersonalInfo(personalInfo, userId);
		}
	}
}

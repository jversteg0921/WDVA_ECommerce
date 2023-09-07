using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WDVA_ECommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		private readonly IPersonalInfoService _personalInfoService;

		public AuthController(IAuthService authService, IPersonalInfoService personalInfoService)
		{
			_authService=authService;
			_personalInfoService=personalInfoService;
		}

		[HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
		{
			
			var response = await _authService.Register(new User
			{
				Email =request.Email,
				PersonalInfo = request.PersonalInfo
			}, request.Password);

			if (!response.Success)
			{
				return BadRequest(response);
			}	

			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
		{
			var response = await _authService.Login(request.Email, request.Password);
			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPost("change-password"), Authorize]
		public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

			if (!response.Success)
			{
				return BadRequest(response);
			}
			
			return Ok(response);
		}

		[HttpDelete, Authorize]
		public async Task<ActionResult<ServiceResponse<bool>>> DeleteAccount()
		{			
			var response = await _authService.DeleteAccount();

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}
	}
}

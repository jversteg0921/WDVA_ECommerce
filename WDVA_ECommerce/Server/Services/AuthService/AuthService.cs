﻿using Azure;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using WDVA_ECommerce.Shared;

namespace WDVA_ECommerce.Server.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;

		

		public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
			_context=context;
			_configuration=configuration;
			_httpContextAccessor=httpContextAccessor;
		}
		//Logs user in by recreating password hash with given password and comparing to stored password hash.
		public async Task<ServiceResponse<string>> Login(string email, string password)
		{
			var response = new ServiceResponse<string>();
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

			if(user == null)
			{
				response.Success = false;
				response.Message = "User not found.";
			}
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
				response.Success = false;
				response.Message = "Wrong Password.";
			}
			else
			{
				response.Data = CreateToken(user);
			}

            


			return response;
		}
		//Registers a user by creating a password hash/salt and storing with user data in database.
		public async Task<ServiceResponse<int>> Register(User user, string password)
		{
			if (await UserExists(user.Email))
			{
				return new ServiceResponse<int>
				{
					Success = false,
					Message = "User with that email already exists"
				};
			}

			CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			//Add user to db
			_context.Users.Add(user);

			//then associate additonal data with user
			
			user.PersonalInfo.UserId = user.Id;
				
			_context.PersonalInfo.Add(user.PersonalInfo);			
			await _context.SaveChangesAsync();

			





			return new ServiceResponse<int>
			{
				Data = user.Id,
				Message = "Registration successful!" 
			};

		}
		//Checks if a user email already exists in the database
		public async Task<bool> UserExists(string email)
		{
			if (await _context.Users.AnyAsync(user => user.Email.ToLower()
				.Equals(email.ToLower())))
			{
				return true;
			}
			return false;
		}

		public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
		{
			var user = await _context.Users.FindAsync(userId);
			if (user == null)
			{
				return new ServiceResponse<bool>
				{
					Success = false,
					Message = "User not found."
				};
			}

			CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			await _context.SaveChangesAsync();

			return new ServiceResponse<bool> { Data = true, Message = "Password has been updated." };
		}

		public async Task<ServiceResponse<bool>> DeleteAccount()
		{
			var userId = GetUserId();

			var user = await _context.Users.FirstOrDefaultAsync(u=> u.Id == GetUserId());

			if (user == null)
			{
				return new ServiceResponse<bool>
				{
					Data = false,
					Success = false,
					Message = "Could not find user. Please login."
				};
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return new ServiceResponse<bool>
			{
				Data = true
			};
		}

		public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using(var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

				return computedHash.SequenceEqual(passwordHash);
			}
		}

		private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Email)
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		
	}
}

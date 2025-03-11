using DatingApp.DTOs;
using DatingApp.Entites;
using DatingApp.EntityFramework;
using DatingApp.Interfaces;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DatingApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ITokenService _tokenService;

        public AccountController(DatingAppContext context, ITokenService tokenService) : base(context)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Đăng ký tài khoản
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ServiceResponse> Register(RegisterDTO registerDTO)
        {
            var res = new ServiceResponse();
            if (await UserExists(registerDTO.UserName))
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Tên đăng nhập đã tồn tại";
                return res;
            }
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            var user = new AppUser()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            res.Data = new UserDTO()
            {
                UserName = user.UserName,
                Token = _tokenService.CreateJWTToken(user),
            };
            return res;
        }

        [HttpPost("login")]
        public async Task<ServiceResponse> Login(LoginDTO loginDTO)
        {
            var res = new ServiceResponse();
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null)
            {
                res.IsSuccess = false;
                res.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                return res;
            }
            using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    res.IsSuccess = false;
                    res.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return res;
                }
            }
            res.Data = new UserDTO()
            {
                UserName = user.UserName,
                Token = _tokenService.CreateJWTToken(user),
            };
            return res;
        }


        /// <summary>
        /// Kiểm tra xem tên đăng nhập có tồn tại không
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName);
        }

    }
}

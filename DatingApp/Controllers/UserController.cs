using AutoMapper;
using DatingApp.DTOs;
using DatingApp.EntityFramework;
using DatingApp.Interfaces;
using DatingApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper){
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ServiceResponse> GetUsers()
        {
            var res = new ServiceResponse();
            var listUsers = await _userRepository.GetUsersAsync();
            res.Data  = _mapper.Map<IEnumerable<MemberDTO>>(listUsers);
            return res;
        }

        [HttpGet("v2")]
        public async Task<ServiceResponse> GetUsersV2()
        {
            var res = new ServiceResponse();
            res.Data = await _userRepository.GetUsersV2Async();
            return res;
        }

        [HttpGet("{username}")]
        public async Task<ServiceResponse> GetUser(string username)
        {
            var res = new ServiceResponse();
            var user = await _userRepository.GetUserByUserNameAsync(username);
            res.Data = _mapper.Map<MemberDTO>(user);
            return res;
        }
    }
}

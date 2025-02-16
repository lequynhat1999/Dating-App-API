using DatingApp.EntityFramework;
using DatingApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(DatingAppContext datingAppContext) : base(datingAppContext) {

        }
        [HttpGet]
        public async Task<ServiceResponse> GetUsers()
        {
            var res = new ServiceResponse();
            res.Data = await _context.Users.ToListAsync();
            return res;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ServiceResponse> GetUser(int id)
        {
            var res = new ServiceResponse();
            res.Data = await _context.Users.FindAsync(id);
            return res;
        }
    }
}

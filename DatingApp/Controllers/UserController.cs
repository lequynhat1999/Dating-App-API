using DatingApp.EntityFramework;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DatingAppContext _context;

        public UserController(DatingAppContext context) {
            _context = context;    
        }
        [HttpGet]
        public async Task<ServiceResponse> GetUsers()
        {
            var res = new ServiceResponse();
            res.Data = await _context.Users.ToListAsync();
            return res;
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse> GetUser(int id)
        {
            var res = new ServiceResponse();
            res.Data = await _context.Users.FindAsync(id);
            return res;
        }
    }
}

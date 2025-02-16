using DatingApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly DatingAppContext _context;

        public BaseController(DatingAppContext context) {
            _context = context;
        }
    }
}

using DatingApp.Entites;
using DatingApp.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.Json;

namespace DatingApp.Controllers
{
    [Authorize]
    public class FakeDataController : BaseController
    {
        public FakeDataController(DatingAppContext datingAppContext) : base(datingAppContext)
        {
            
        }

        [HttpGet("fake-data")]
        public async Task GetFakeData()
        {
            var jsonData = await System.IO.File.ReadAllTextAsync("FakeData/FakeData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(jsonData);
            foreach (var user in users)
            {
                // Hash the password
                using var hmac = new HMACSHA512();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("lqnhat123"));

                // Set other properties if needed
                user.Created = DateTime.Now;
                user.LastActive = DateTime.Now;

                // Add the user to the context
                _context.Users.Add(user);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
    }
}

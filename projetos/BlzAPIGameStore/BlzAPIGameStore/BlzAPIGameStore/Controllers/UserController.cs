using BlzAPIGameStore.Backend.Data;
using BlzAPIGameStore.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlzAPIGameStore.Backend.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        [HttpGet(Name ="validate-user")]
        public async Task<bool> ValidateUser(string email, string passwordHash)
        {
            var _VUser = new User();
            try
            {
                _VUser = await _context.Users.Where(p => p.Email == email).FirstAsync();
            }
            catch(Exception)
            {
                throw;
            }
            if (_VUser.PasswordHash == passwordHash) return true;
            else return false;
        }
    }
}

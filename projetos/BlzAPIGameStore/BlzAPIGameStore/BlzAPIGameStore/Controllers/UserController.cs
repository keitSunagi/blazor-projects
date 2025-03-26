using BlzAPIGameStore.Backend.Data;
using BlzAPIGameStore.Backend.Models;
using BlzAPIGameStore.Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlzAPIGameStore.Backend.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        [HttpGet("validate-user")]
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
        [HttpGet("user-role")]
        public async Task<IActionResult> GetUserRole([FromQuery] string id)
        {
            try
            {
                var role = await _context.Users.Where(p => p.Id == id)
                    .Select(p => p.Role)
                    .FirstOrDefaultAsync();
                //Deixar aqui mesmo que seja redundante. Vai que né.
                if (role == null) return BadRequest("Usuário não possui cargo");
                else return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno" + ex.Message);
            }
        }
    }
}

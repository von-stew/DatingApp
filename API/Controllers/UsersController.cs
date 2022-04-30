using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        public DataContext _context { get; }
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);   
        }

        //Test for git
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<AppUser>> DeleteUser(int id)
        // {
        //     var data = await _context.Users.FindAsync(id);   
        //     _context.Remove(data);
        //     _context.SaveChanges();
        //     return await _context.Users.FirstOrDefaultAsync();
        // }
    }
}
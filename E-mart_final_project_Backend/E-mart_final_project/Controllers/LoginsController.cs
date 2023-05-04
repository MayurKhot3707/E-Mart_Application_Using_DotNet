using E_mart_final_project.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_mart_final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly EmartContext _context;

        public LoginsController(EmartContext context)
        {
            _context = context;
        }


        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Login>>> PostLogin(Login login)
        {
            if (login == null)
            {
                return Problem("Enter Data to Login");
            }


            var user = await _context.User.FirstOrDefaultAsync((user) => user.UserName == login.UserName && user.Password == login.Password);

            if (user == null)
            {
                return BadRequest("User not valid");
            }
            else
                if (login.UserName.Equals(user.UserName) && login.Password.Equals(user.Password))
            {
                return Ok(user);
            }

            return BadRequest("Invalid Userid. OR Password");


        }


    }

}

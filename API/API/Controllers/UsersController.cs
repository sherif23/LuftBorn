using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository repo;

        public UsersController(IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost ("addnewuser")]
        public async Task <IActionResult> AddNewUser (User user)
        {
            User userCreated = await repo.AddNewUser(user);

            return Ok(userCreated);
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            User userUpdated = await repo.UpdateUser(user);

            return Ok(userUpdated);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers ()
        {

            List<User> users = await repo.GetUsers();

            return Ok(users);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {

            User user = await repo.GetUser(id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            bool res = await repo.DeleteUser(id);

            if (res == false)
                return BadRequest();

            return Ok();
        }





    }
}

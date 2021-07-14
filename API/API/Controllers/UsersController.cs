using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public UsersController(IUserRepository repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }

        [HttpPost ("addnewuser")]
        public async Task <IActionResult> AddNewUser (UserForDetailedDto userForDetailedDto)
        {
            User user = _mapper.Map<User>(userForDetailedDto);
            User userCreated = await repo.AddNewUser(user);

            return Ok(userCreated);
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser(UserForDetailedDto userForDetailedDto)
        {
            User user = _mapper.Map<User>(userForDetailedDto);
            
            User userUpdated = await repo.UpdateUser(user);

            return Ok(userUpdated);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers ()
        {

            List<User> users = await repo.GetUsers();

            List<UserForDetailedDto> usersDtails = new List<UserForDetailedDto>(); 
            foreach (User user in users) {
                UserForDetailedDto userForDetailedDto = _mapper.Map<UserForDetailedDto>(user);
                usersDtails.Add(userForDetailedDto);
            }

            return Ok(usersDtails);
        }

        [HttpGet ("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {

            User user = await repo.GetUser(id);

            UserForDetailedDto userForDetailedDto = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userForDetailedDto);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoPloomesTuneUP.Models;
using ProcessoSeletivoPloomesTuneUP.Repository.Interfaces;
using System.Data;
using System.Net;

namespace ProcessoSeletivoPloomesTuneUP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser([FromBody] UserModel newUser)
        {
            UserModel user = await _userRepository.PostUser(newUser);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetUserById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> PutUser([FromBody] UserModel updateUser, int id)
        {
            updateUser.Id = id;
            UserModel user = await _userRepository.PutUser(updateUser, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool isDeleted = await _userRepository.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}

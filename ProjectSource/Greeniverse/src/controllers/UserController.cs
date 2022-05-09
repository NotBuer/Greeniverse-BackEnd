using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.repositories;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Mvc;
namespace BlogPessoal.src.controller
{
    [ApiController]
    [Route("api/User")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region Attribute

        private readonly IUser _repository;

        #endregion


        #region Constructor

        public UserController(IUser repository)  
        {
            _repository = repository;
        }

        #endregion


        #region Methods


        [HttpGet("id/{idUser}")]
        public IActionResult GetUserById([FromRoute] int idUser)
        {
            var user = _repository.GetUserById(idUser);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUserByName([FromQuery] string nameUser)
        {
            var user = _repository.GetUserByName(nameUser);

            if (user.Count < 1) return NoContent();

            return Ok(user);
        }

        [HttpGet("email/{emailUser}")]
        public IActionResult GetUserByEmail([FromRoute] string emailUser)
        {
            var user = _repository.GetUserByEmail(emailUser);

            if (user == null) return NotFound();

            return Ok(user);
        }
        
              #endregion

    }
}
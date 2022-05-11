﻿using Greeniverse.src.dtos;
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
        #region Attributes

        private readonly IUser _repository;

        #endregion


        #region Constructors

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

        [HttpPost]
        public IActionResult NewUser([FromBody] NewUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.NewUser(user);
            return Created($"api/User/email/{user.Email}", user);
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.UpdateUser(user);
            return Ok(user);
        }
        [HttpDelete("delete/{idUser}")]
        public IActionResult DeleteUser([FromRoute] int idUser)
        {
            _repository.DeleteUser(idUser);
            return NoContent();
        }
        #endregion

    }
}
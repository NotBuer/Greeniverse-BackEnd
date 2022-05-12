using Greeniverse.src.DTOS;
using Greeniverse.src.repositories;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogPessoal.src.controller
{
    [ApiController]
    [Route("api/User")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region Attributes

        private readonly IUser _repository;
        private readonly IAuthentication _services;

        #endregion

        #region Constructors

        public UserController(IUser repository, IAuthentication services)  
        {
            _repository = repository;
            _services = services;
        }

        #endregion

        #region Methods


        [HttpGet("id/{idUser}")]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int idUser)
        {
            var user = await _repository.GetUserByIdAsync(idUser);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<IActionResult> GetUserByNameAsync([FromQuery] string nameUser)
        {
            var user = await _repository.GetUserByNameAsync(nameUser);

            if (user.Count < 1) return NoContent();

            return Ok(user);
        }

        [HttpGet("email/{emailUser}")]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<IActionResult> GetUserByEmailAsync([FromRoute] string emailUser)
        {
            var user = await _repository.GetUserByEmailAsync(emailUser);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> NewUserAsync([FromBody] NewUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
               await _services.CreateUserWithoutDuplicateAsync(user);
               return Created($"api/User/email/{user.Email}", user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            user.Password = _services.EncodePassword(user.Password);

            await _repository.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete("delete/{idUser}")]
        [Authorize(Roles = "Business")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int idUser)
        {
            await _repository.DeleteUserAsync(idUser);
            return NoContent();
        }

        #endregion

    }
}
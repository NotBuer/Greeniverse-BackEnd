using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="idUser">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return user</response>
        /// <response code="404">User don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idUser}")]
        [Authorize(Roles = "IndividualPerson,Business")]
        public async Task<ActionResult> GetUserByIdAsync([FromRoute] int idUser)
        {
            UserModel user = await _repository.GetUserByIdAsync(idUser);

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Get user by Name
        /// </summary>
        /// <param name="nameUser">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorn user</response>
        /// <response code="204">Name don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<ActionResult> GetUserByNameAsync([FromQuery] string nameUser)
        {
            List<UserModel> user = await _repository.GetUserByNameAsync(nameUser);

            if (user.Count < 1) return NoContent();

            return Ok(user);
        }
        
        /// <summary>
        /// Get user by Email
        /// </summary>
        /// <param name="emailUser">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorn user</response>
        /// <response code="404">Email don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("email/{emailUser}")]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<ActionResult> GetUserByEmailAsync([FromRoute] string emailUser)
        {
            UserModel user = await _repository.GetUserByEmailAsync(emailUser);
            if (user == null) return NotFound();
            return Ok(user);
        }
        
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">NewUserDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// requisition example:
        ///
        ///     POST /api/User
        ///     {
        ///        "name": "Uriel Boaz",
        ///        "email": "uriel@gmail.com",
        ///        "password": "12345678",
        ///        "address": "AddressTest - 123",
        ///        "telephone": "(11) 96543-2356"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Return created user</response>
        /// <response code="400">request error</response>
        /// <response code="401">E-mail already registered</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> NewUserAsync([FromBody] NewUserDTO user)
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

        /// <summary>
        /// Updated user
        /// </summary>
        /// <param name="user">UpdateUserDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// requisition example:
        ///
        ///     PUT /api/User
        ///     {
        ///        "id": 1,    
        ///        "name": "Uriel Boaz",
        ///        "email": "uriel@email.com"
        ///        "password": "11223344",
        ///        "address": "AddressTest - 123",
        ///        "telephone": "(11) 96543-2356",
        ///        "userType": "Business"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Return updated user</response>
        /// <response code="400">requisition error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            user.Password = _services.EncodePassword(user.Password);

            await _repository.UpdateUserAsync(user);
            return Ok(user);
        }

        /// <summary>
        /// Delete user by Id
        /// </summary>
        /// <param name="idUser">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">User deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idUser}")]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] int idUser)
        {
            await _repository.DeleteUserAsync(idUser);
            return NoContent();
        }

        #endregion

    }
}
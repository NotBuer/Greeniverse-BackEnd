using System;
using System.Threading.Tasks;
using Greeniverse.src.dtos;
using Greeniverse.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Authentication")]
    [Produces("application/json")]

    public class AuthenticationController : ControllerBase
    {
        #region Attribute

        private readonly IAuthentication _services;

        #endregion Attribute

        #region Constructor

        public AuthenticationController(IAuthentication services)
        {
            _services = services;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Get Authorization
        /// </summary>
        /// <param name="authentication">AutenticarDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     POST /api/Authentication
        ///     {
        ///        "email": "murilo@domain.com",
        ///        "senha": "134652"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Return authorization created</response>
        /// <response code="400">Request error</response>
        /// <response code="401">Invalid email or password</response>

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorizationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateAsync([FromBody] AuthenticationDTO authentication)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                AuthorizationDTO authorization = await _services.GetAuthorizationAsync(authentication);
                return Ok(authorization);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        #endregion
    }
}
using System;
using System.Threading.Tasks;
using Greeniverse.src.dtos;
using Greeniverse.src.services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateAsync([FromBody] AuthenticationDTO authentication)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var authorization = await _services.GetAuthorizationAsync(authentication);
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
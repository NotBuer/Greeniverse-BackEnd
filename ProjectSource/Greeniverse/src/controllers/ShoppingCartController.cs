using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Greeniverse.src.controllers
{
    [ApiController]
    [Route("api/ShoppingCart")]
    [Produces("application/json")]
    public class ShoppingCartController : ControllerBase
    {
        
        #region Attribute

        private readonly IShoppingCart _repository;

        #endregion

        #region Constructor

        public ShoppingCartController(IShoppingCart repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get shoppingcart by Id
        /// </summary>
        /// <param name="idShoppingCart">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the ShoppingCart</response>
        /// <response code="404">ShoppingCart not existent</response>

        [HttpGet("id/{idShoppingCart}")]
        [Authorize]
        public async Task<ActionResult> GetShoppingCartByIdAsync([FromRoute] int idShoppingCart)
        {
            var shoppingcart = _repository.GetShoppingCartByIdAsync(idShoppingCart);

            if (shoppingcart == null) return NotFound();

            return Ok(shoppingcart);
        }

        /// <summary>
        /// Get shoppingcart products list
        /// </summary>
        /// <param name="shoppingCart">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the ShoppingCart Products list</response>
        /// <response code="404">ShoppingCart not existent</response>

        [HttpGet]
        [Authorize]
        public Task<ActionResult> GetAllProductsAsync()
        {
            var list = await _repository.GetAllProductsAsync();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        /// <summary>
        /// Create a new shopping cart
        /// </summary>
        /// <param name="shoppingCart">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Create a new shopping cart</response>
        /// <response code="400">Cannot create shopping cart</response>

        [HttpPost]
        [Authorize]
        public Task<ActionResult> NewShoppingCartAsync([FromBody] NewShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewShoppingCartAsync(shoppingCart);

            return Created($"api/ShoppingCart", shoppingCart);
        }

        /// <summary>
        /// Update the existing shopping cart
        /// </summary>
        /// <param name="shoppingCart">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Update shopping cart</response>
        /// <response code="400">Cannot update shopping cart</response>

        [HttpPut]
        public Task<ActionResult> UpdateShoppingCartAsync([FromBody] UpdateShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateShoppingCartAsync(shoppingCart);

            return Ok(shoppingCart);
        }

        /// <summary>
        /// Delete the existing shopping cart
        /// </summary>
        /// <param name="idShoppingCart">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">No content</response>

        [HttpDelete("delete/{idShoppingCart}")]
        [Authorize]
        public Task<ActionResult> DeleteShoppingCartAsync([FromRoute] int idShoppingCart)
        {
            await _repository.DeleteShoppingCartAsync(idShoppingCart);
            return NoContent();
        }

        #endregion

    }
}

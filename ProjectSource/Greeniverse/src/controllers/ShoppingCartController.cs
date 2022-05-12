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

        [HttpGet("id/{idShoppingCart}")]
        [Authorize]
        public async Task<ActionResult> GetShoppingCartByIdAsync([FromRoute] int idShoppingCart)
        {
            var shoppingcart = _repository.GetShoppingCartByIdAsync(idShoppingCart);

            if (shoppingcart == null) return NotFound();

            return Ok(shoppingcart);
        }

        [HttpGet]
        [Authorize]
        public Task<ActionResult> GetAllProductsAsync()
        {
            var list = await _repository.GetAllProductsAsync();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public Task<ActionResult> NewShoppingCartAsync([FromBody] NewShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewShoppingCartAsync(shoppingCart);

            return Created($"api/ShoppingCart", shoppingCart);
        }

        [HttpPut]
        public Task<ActionResult> UpdateShoppingCartAsync([FromBody] UpdateShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateShoppingCartAsync(shoppingCart);

            return Ok(shoppingCart);
        }

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

using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetShoppingCartById([FromRoute] int idShoppingCart)
        {
            var shoppingcart = _repository.GetShoppingCartById(idShoppingCart);

            if (shoppingcart == null) return NotFound();

            return Ok(shoppingcart);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var list = _repository.GetAllProducts();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        [HttpPost]
        [Authorize]
        public IActionResult NewShoppingCart([FromBody] NewShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.NewShoppingCart(shoppingCart);

            return Created($"api/ShoppingCart", shoppingCart);
        }

        [HttpPut]
        public IActionResult UpdateShoppingCart([FromBody] UpdateShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.UpdateShoppingCart(shoppingCart);

            return Ok(shoppingCart);
        }

        [HttpDelete("delete/{idShoppingCart}")]
        [Authorize]
        public IActionResult DeleteShoppingCart([FromRoute] int idShoppingCart)
        {
            _repository.DeleteShoppingCart(idShoppingCart);
            return NoContent();
        }

        #endregion

    }
}

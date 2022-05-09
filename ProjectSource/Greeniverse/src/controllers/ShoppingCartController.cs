using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Mvc;

namespace Greeniverse.src.controllers
{
    [ApiController]
    [Route("api/ShoppingCart")]
    [Produces("application/json")]
    public class ShoppingCartController : ControllerBase
    {
        #region Attributes

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
        public IActionResult GetShoppingCartById([FromRoute] int idShoppingCart)
        {
            var shoppingcart = _repository.GetShoppingCartById(idShoppingCart);

            if(shoppingcart == null) return NotFound();

            return Ok(shoppingcart);
        }



        #endregion
    }
}

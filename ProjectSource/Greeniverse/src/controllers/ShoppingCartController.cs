using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idShoppingCart}")]
        [Authorize]
        public async Task<ActionResult> GetShoppingCartByIdAsync([FromRoute] int idShoppingCart)
        {
            ShoppingCartModel shoppingcart = await _repository.GetShoppingCartByIdAsync(idShoppingCart);

            if (shoppingcart == null) return NotFound();

            return Ok(shoppingcart);
        }

        /// <summary>
        /// Get shoppingcart products list
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the ShoppingCart Products list</response>
        /// <response code="204">ShoppingCart not existent</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            List<ShoppingCartModel> list = await _repository.GetAllProductsAsync();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        /// <summary>
        /// Get user by Name
        /// </summary>
        /// <param name="emailPurchaser">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorn shoppingcart</response>
        /// <response code="204">ShoppingCart don't exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("search")]
        [Authorize(Roles = "IndividualPerson, Business")]
        public async Task<ActionResult> GetAllProductsByEmailPurchaserAsync([FromQuery]string emailPurchaser)
        {
            List<ShoppingCartModel> shoppingcart = await _repository.GetAllProductsByEmailPurchaserAsync(emailPurchaser);

            if (shoppingcart.Count < 1) return NoContent();

            return Ok(shoppingcart);
        }


        /// <summary>
        /// Create a new shopping cart
        /// </summary>
        /// <param name="shoppingCart">NewShoppingDTO</param>
        /// <returns>ActionResult</returns>
        /// /// <remarks>
        /// requisition example:
        ///
        ///     POST /api/ShoppingCart
        ///     {
        ///        "paymentMethod": PIX,
        ///        "voucher": "50% de desconto",
        ///        "deliveryAddress": "TestAddress - 184",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Return created Shopping Cart</response>
        /// <response code="400">request error</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShoppingCartModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewShoppingCartAsync([FromBody] NewShoppingCartDTO shoppingCart)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewShoppingCartAsync(shoppingCart);

            return Created($"api/ShoppingCart", shoppingCart);
        }

        /// <summary>
        /// Update the existing shopping cart
        /// </summary>
        /// <param name="shoppingCart">UpdateShoppingCartDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/ShoppingCart
        ///     {
        ///        "paymentMethod": PIX,
        ///        "voucher": "50% de desconto",
        ///        "deliveryAddress": "TestAddress - 184"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Shopping Cart updated</response>
        /// <response code="400">Error in request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateShoppingCartAsync([FromBody] UpdateShoppingCartDTO shoppingCart)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idShoppingCart}")]
        [Authorize]
        public async Task<ActionResult> DeleteShoppingCartAsync([FromRoute] int idShoppingCart)
        {
            await _repository.DeleteShoppingCartAsync(idShoppingCart);
            return NoContent();
        }

        #endregion

    }
}

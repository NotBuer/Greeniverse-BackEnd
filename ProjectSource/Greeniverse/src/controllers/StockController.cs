
﻿using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Greeniverse.src.controllers
{
    [ApiController]
    [Route("api/Stock")]
    [Produces("application/json")]
    public class StockControllers : ControllerBase
    {
        #region Attribute

        private readonly IStock _repository;

        #endregion

        #region Constructor

        public StockControllers(IStock repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Returns all themes</response>
        /// <response code="204">No content</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var list = await _repository.GetAllProductsStockAsync();

            if (list.Count == 1) return NoContent();
            return Ok(list);

        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        ///<returns>ActionResult</returns>
        /// <param name="idStock">int</param>
        /// <response code="200">Return the Product</response>
        /// <response code="404">Product not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idStock}")]
        [Authorize]
        public async Task<ActionResult> GetProductByIdAsync([FromRoute] int idStock)
        {

            var stock = await _repository.GetProductByIdAsync(idStock);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        /// <summary>
        /// Get Product By Search
        /// </summary>
        /// <param name="productCategory">Enum</param>
        /// <param name="description">StockDTO</param>
        ///<param name="productName">StockDTO</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the Product</response>
        /// <response code="204">Ok, but no content</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult> GetProductsBySearchAsync(
            [FromQuery] ProductCategory productCategory,
            [FromQuery] string description,
            [FromQuery] string productName)
        {
            var stocks = await _repository.GetProductsBySearchAsync(productCategory, description, productName);
            if (stocks.Count < 1) return NoContent();
            return Ok(stocks);
        }

        /// <summary>
        /// Create a new Product
        /// </summary>
        /// <param name="stock">StockDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Stock
        ///     {
        ///         "id": 1,
        ///        "productCategory": "Fruits",
        ///        "description": "red fruit",
        ///        "price": 3.55f,
        ///        "productName": "strawberry",
        ///        "provider": "Americanas",
        ///        "productPhoto": "ProductURL"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created stock</response>
        /// <response code="400">Error in request</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StockModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> NewProductAsync([FromBody] NewStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewProductAsync(stock);

            return Created($"Api/stocks/id/{stock.Id}", stock);
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="stock">UpdateStockDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Stock
        ///     {
        ///         "id": 1,
        ///        "productCategory": "Fruits",
        ///        "description": "red fruit",
        ///        "price": 4.55f,
        ///        "productName": "strawberry",
        ///        "provider": "Americanas",
        ///        "productPhoto": "ProductURL"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Product updated</response>
        /// <response code="400">Error in request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> UpdateProductAsync([FromBody] UpdateStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repository.UpdateProductAsync(stock);
            return Ok(stock);
        }

        /// <summary>
        /// Delete a product by id
        /// </summary>
        /// <param name="idStock">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Ok, but no content</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idStock}")]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> DeleteProductAsync([FromRoute] int idStock)
        {
            await _repository.DeleteProductAsync(idStock);
            return NoContent();
        }

        #endregion
    }
}

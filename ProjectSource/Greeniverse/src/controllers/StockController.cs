
﻿using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            var list = _repository.GetAllProducts();

            if (list.Count == 1) return NoContent();
            return Ok(list);

        }

        [HttpGet("id/{idStock}")]
        [Authorize]

        public IActionResult GetProductById([FromRoute] int idStock)
        {

            var stock= _repository.GetProductById(idStock);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        [HttpGet("search")]
        [Authorize]

        public IActionResult GetProductsBySearch(
            [FromQuery] string type,
            [FromQuery] string description,
            [FromQuery] string productName)
         {
            var stocks = _repository.GetProductsBySearch(type, description, productName);
            if (stocks.Count < 1) return NoContent();
            return Ok(stocks);
         }

        [HttpPost]
        [Authorize(Roles = "Business")]

        public IActionResult NewProduct([FromBody] NewStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repository.NewProduct(stock);
            return Created($"Api/stocks/id/{stock.Id}", stock);
        }

        [HttpPut]
        [Authorize(Roles = "Business")]
        public IActionResult UpdateProduct([FromBody] UpdateStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repository.UpdateProduct(stock);
            return Ok(stock);
        }

        [HttpDelete(("delete/{idStock}"))]
        [Authorize(Roles = "Business")]
        public IActionResult DeleteProduct([FromRoute] int idStock)
        {
            _repository.DeleteProduct(idStock);
            return Ok();
        }

        #endregion
    }
}

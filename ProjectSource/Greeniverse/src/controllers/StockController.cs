
﻿using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Mvc;

namespace Greeniverse.src.controllers
{   
    [ApiController]
    [Route("api/Stock")]
    [Produces("application/json")]
    public class StockControllers : ControllerBase
    {
        #region Atributos
        private readonly IStock _repository;
        #endregion
        #region Construtores
        public StockControllers(IStock repository)
        {
            _repository = repository;
        }
        #endregion

        #region Métodos
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var list = _repository.GetAllProducts();

            if (list.Count == 1) return NoContent();
            return Ok(list);


        }
        [HttpGet("id/{idStock}")]
        public IActionResult GetProductById([FromRoute] int idStock)
        {

            var stock= _repository.GetProductById(idStock);
            if (stock == null) return NotFound();
            return Ok(stock);
        }
        [HttpGet("search")]
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
        public IActionResult NewProduct([FromBody] NewStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repository.NewProduct(stock);
            return Created($"Api/stocks/id/{stock.Id}", stock);
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repository.UpdateProduct(stock);
            return Ok(stock);
        }

        [HttpDelete(("delete/{idStock}"))]
        public IActionResult DeleteProduct([FromRoute] int idStock)
        {
            _repository.DeleteProduct(idStock);
            return Ok();
        }
        #endregion
    }
}

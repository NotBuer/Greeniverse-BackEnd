<<<<<<< HEAD
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

=======
﻿
>>>>>>> 1a0aaa1d316a89d7a5b3f75f1accf7c3d8a15668
        #region Métodos
        [HttpGet]
        public IActionResult GetAllProducts()
        {
<<<<<<< HEAD
            var list = _repository.GetAllProducts();

            if (list.Count == 1) return NoContent();
            return Ok(list);
=======

>>>>>>> 1a0aaa1d316a89d7a5b3f75f1accf7c3d8a15668
        }
        [HttpGet("id/{idStock}")]
        public IActionResult GetProductById([FromRoute] int idStock)
        {
<<<<<<< HEAD
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
=======

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
>>>>>>> 1a0aaa1d316a89d7a5b3f75f1accf7c3d8a15668
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
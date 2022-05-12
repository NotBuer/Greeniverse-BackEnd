
﻿using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public  async Task<ActionResult> GetAllProductsAsync()
        {
            var list = await _repository.GetAllProductsAsync();

            if (list.Count == 1) return NoContent();
            return Ok(list);

        }

        [HttpGet("id/{idStock}")]
        [Authorize]
        public async Task<ActionResult> GetProductByIdAsync([FromRoute] int idStock)
        {

            var stock= await _repository.GetProductByIdAsync(idStock);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult> GetProductsBySearchAsync(
            [FromQuery] string type,
            [FromQuery] string description,
            [FromQuery] string productName)
        {
            var stocks =await _repository.GetProductsBySearchAsync(type, description, productName);
            if (stocks.Count < 1) return NoContent();
            return Ok(stocks);
        }

        [HttpPost]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> NewProductAsync([FromBody] NewStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repository.NewProductAsync(stock);
            return Created($"Api/stocks/id/{stock.Id}", stock);
        }

        [HttpPut]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> UpdateProductAsync([FromBody] UpdateStockDTO stock)
        {
            if (!ModelState.IsValid) return BadRequest();
           await _repository.UpdateProductAsync(stock);
            return Ok(stock);
        }

        [HttpDelete(("delete/{idStock}"))]
        [Authorize(Roles = "Business")]
        public async Task<ActionResult> DeleteProductAsync([FromRoute] int idStock)
        {
            await _repository.DeleteProductAsync(idStock);
            return NoContent();
        }

        #endregion
    }
}

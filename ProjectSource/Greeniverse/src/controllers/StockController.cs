
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
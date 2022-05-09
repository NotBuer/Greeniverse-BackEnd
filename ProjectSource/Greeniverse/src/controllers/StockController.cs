using Greeniverse.src.dtos;
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

using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.repositorios.implementacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestMethod]
    public async Task GetStockByDescriptionReturnProductName()
    {   
        
        var opt = new DbContextOptionsBuilder<GreeniverseContext>()
        .UseInMemoryDatabase(databaseName: "db_greeniverse")
        .Options;

        _context = new GreeniverseContext(opt);
        _repository = new StockRepository(_context);

        
        await _repository.NewStockAsync(new NewStockDTO("Banana"));
     
        await _repository.NewStockAsync(new NewStockDTO("Morango"));

        var stock = await _repositoriy.GetStockByDescriptionAsync("Banana");

     
        Assert.AreEqual(2, stock.Count);
    }

    [TestMethod]
    public async Task AlternateStockDescriptionReturnType()
    {
        
        var opt = new DbContextOptionsBuilder<GreeniverseContext>()
        .UseInMemoryDatabase(databaseName: "db_greeniverse")
        .Options;

        _context = new GreeniverseContexto(opt);
        _repository = new StockRepository(_context);

       
        await _repository.NovoTemaAsync(new NewStockDTO("Banana"));

        await _repository.UpdateStockAsync(new UpdateStockDTO(1, "Morango"));

        var stock = await _repository.GetStockByIdAsync(1);

        Assert.AreEqual("Morango", stock.Description);
    }

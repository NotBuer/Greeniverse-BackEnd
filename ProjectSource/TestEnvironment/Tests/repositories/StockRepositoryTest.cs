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
        .UseInMemoryDatabase(databaseName: "db_blogpessoal12")
        .Options;

        _contexto = new BlogPessoalContexto(opt);
        _repositorio = new TemaRepositorio(_contexto);

        
        await _repositorio.NovoTemaAsync(new NovoTemaDTO("Java"));
     
        await _repositorio.NovoTemaAsync(new NovoTemaDTO("JavaScript"));

      
        var temas = await _repositorio.PegarTemasPelaDescricaoAsync("Java");

     
        Assert.AreEqual(2, temas.Count);
    }

    [TestMethod]
    public async Task AlterarTemaPythonRetornaTemaCobol()
    {
        
        var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
        .UseInMemoryDatabase(databaseName: "db_blogpessoal13")
        .Options;

        _contexto = new BlogPessoalContexto(opt);
        _repositorio = new TemaRepositorio(_contexto);

       
        await _repositorio.NovoTemaAsync(new NovoTemaDTO("Python"));

        await _repositorio.AtualizarTemaAsync(new AtualizarTemaDTO(1, "COBOL"));

        var stock = await _repository.GetProductByIdAsync(1);

        Assert.AreEqual("COBOL", stock.Description);
    }

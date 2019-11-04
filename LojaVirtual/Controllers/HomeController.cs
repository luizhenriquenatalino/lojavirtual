using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]            
        public IActionResult Index(int? pagina, string pesquisa)
        {
            var produtos = _produtoRepository.ObterTodosProdutos(pagina, pesquisa);
            return View(produtos);
        }      

    }
}
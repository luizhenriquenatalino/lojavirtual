using LojaVirtual.Models;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {

        private IProdutoRepository _produtoRepository;
        private IConfiguracaoLojaRepository _configuracaoLojaRepository;
        public ProdutoController(IProdutoRepository produtoRepository, IConfiguracaoLojaRepository configuracaoLojaRepository)
        {
            _produtoRepository = produtoRepository;
            _configuracaoLojaRepository = configuracaoLojaRepository;
        }

        [HttpGet]
        public ActionResult Index(int? pagina, string pesquisa)
        {
            var produtos = _produtoRepository.ObterTodosProdutos(pagina, pesquisa);
            return View(produtos);
        }
     
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        { 
            if (ModelState.IsValid)
            {
                _produtoRepository.Cadastrar(produto);
                ConfiguracaoLoja configuracaoLoja = _configuracaoLojaRepository.ObterConfiguracao();
                _produtoRepository.AtualizarPrecoVenda(configuracaoLoja);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpGet]
        public IActionResult Visualizar(int Id)
        {
            var produto = _produtoRepository.ObterProduto(Id);
            return View(produto);
        }
    }
}

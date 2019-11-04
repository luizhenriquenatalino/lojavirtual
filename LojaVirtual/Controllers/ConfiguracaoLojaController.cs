using LojaVirtual.Models;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ConfiguracaoLojaController : Controller
    {

        IConfiguracaoLojaRepository _configuracaoLojaRepository;
        IProdutoRepository _produtoRepository;

        public ConfiguracaoLojaController(IConfiguracaoLojaRepository configuracaoLojaRepository, IProdutoRepository produtoRepository)
        {
            _configuracaoLojaRepository = configuracaoLojaRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var configuracaoLoja = _configuracaoLojaRepository.ObterConfiguracao();
            return View(configuracaoLoja);
        }

        [HttpPost]
        public IActionResult Cadastrar(ConfiguracaoLoja configuracaoLoja)
        {
            if (ModelState.IsValid)
            {
                _configuracaoLojaRepository.Cadastrar(configuracaoLoja);
                _produtoRepository.AtualizarPrecoVenda(configuracaoLoja);
                return RedirectToAction("Index", "Home");
            }
            return View(configuracaoLoja);
        }
    }
}
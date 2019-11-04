using AutoMapper;
using LojaVirtual.Infra.CarrinhoCompra;
using LojaVirtual.Models;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LojaVirtual.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        private CookieCarrinhoCompra _carrinhoCompra;
        private IProdutoRepository _produtoRepository;
        private IMapper _mapper;
        public CarrinhoCompraController(CookieCarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _carrinhoCompra = carrinhoCompra;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<ProdutoItem> produtoItemCompleto = new List<ProdutoItem>();
            List<ProdutoItem> produtoItemCarrinho = _carrinhoCompra.Consultar();
            foreach(var item in produtoItemCarrinho)
            {
                Produto produto = _produtoRepository.ObterProduto(item.Id);
                ProdutoItem produtoItem = _mapper.Map<ProdutoItem>(produto);
                produtoItem.QuantidadeProdutoCarrinho = item.QuantidadeProdutoCarrinho;
                produtoItemCompleto.Add(produtoItem);
            }
            return View(produtoItemCompleto);
        }
        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (produto == null)
            {
                return View("Não Existe Item");
            }
            else
            {
                var item = new ProdutoItem() { Id = id, QuantidadeProdutoCarrinho = 1 };
                _carrinhoCompra.Cadastrar(item);
                return RedirectToAction(nameof(Index));
            }                        
        }
        public IActionResult AlterarQuantidade(int id, int quantidade)
        {
            _carrinhoCompra.Atualizar(new ProdutoItem { Id = id, QuantidadeProdutoCarrinho = quantidade });
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoverItem(int id)
        {
            _carrinhoCompra.Remover(new ProdutoItem() { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
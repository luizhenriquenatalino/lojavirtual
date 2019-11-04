using LojaVirtual.Database;
using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        IConfiguration _conf;
        LojaVirtualContext _banco;
        IConfiguracaoLojaRepository _configuracaoLojaRepository;

        public ProdutoRepository(LojaVirtualContext banco, IConfiguration configuration, IConfiguracaoLojaRepository configuracaoLojaRepository)
        {
            _banco = banco;
            _conf = configuration;
            _configuracaoLojaRepository = configuracaoLojaRepository;
        }

        public void AtualizarPrecoVenda(ConfiguracaoLoja configuracaoLoja)
        {            
            var produtos = _banco.Produtos.Where(p => p.Custo > 0);
            var totalProdutos = produtos.Count();

            if (totalProdutos == 0)
            {
                return;
            }

            var despesaTotalRateada = configuracaoLoja.CustoDespesa / totalProdutos;
            foreach(var produto in produtos)
            {
                produto.PrecoVenda = produto.Custo + despesaTotalRateada;

                if (configuracaoLoja.PercentualLucro > 0)
                {
                    produto.PrecoVenda *= (1 + configuracaoLoja.PercentualLucro / 100);
                }        
            }
            _banco.SaveChanges();
        }

        public void Cadastrar(Produto produto)
        {
            _banco.Add(produto);
            _banco.SaveChanges();
        }

        public Produto ObterProduto(int Id)
        {
            return _banco.Produtos.Find(Id);
        }

        public IPagedList<Produto> ObterTodosProdutos(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int NumeroPagina = pagina ?? 1;

            var bancoProduto = _banco.Produtos.AsQueryable().Where(a => a.Custo > 0);

            if (!string.IsNullOrEmpty(pesquisa))
            {
                bancoProduto = bancoProduto.Where(a => a.Nome.Contains(pesquisa.Trim()));
            }
            return bancoProduto.ToPagedList<Produto>(NumeroPagina, RegistroPorPagina);
        }
    }
}

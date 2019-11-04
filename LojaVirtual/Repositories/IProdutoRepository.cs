using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);      
        Produto ObterProduto(int Id);
        IPagedList<Produto> ObterTodosProdutos(int? pagina, string pesquisa);
        void AtualizarPrecoVenda(ConfiguracaoLoja configuracaoLoja);
    }
}

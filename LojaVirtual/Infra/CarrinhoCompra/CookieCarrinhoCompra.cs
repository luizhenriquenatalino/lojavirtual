using LojaVirtual.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Infra.CarrinhoCompra
{
    public class CookieCarrinhoCompra
    {
        private Cookie.Cookie _cookie;
        private string key = "Carrinho.Compras";
        public CookieCarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }

        public void Cadastrar(ProdutoItem item)
        {
            List<ProdutoItem> Lista = null;
            if ( _cookie.Existe(key) )
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);
                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.QuantidadeProdutoCarrinho = ItemLocalizado.QuantidadeProdutoCarrinho + item.QuantidadeProdutoCarrinho;
                }
                
            }
            else
            {
                Lista = new List<ProdutoItem>();
                Lista.Add(item);
            }
            Salvar(Lista);
        }

        public void Salvar(List<ProdutoItem> itens)
        {
            if (itens != null)
            {
                string valores = JsonConvert.SerializeObject(itens);
                _cookie.Cadastrar(key, valores);
            }
        }

        public void Atualizar(ProdutoItem item)
        {
            var ListaProdutos = Consultar();
            var ItemLocalizado = ListaProdutos.SingleOrDefault(a => a.Id == item.Id);
            if (ItemLocalizado != null)
            {
                ItemLocalizado.QuantidadeProdutoCarrinho = item.QuantidadeProdutoCarrinho;
                Salvar(ListaProdutos);
            }
        }

        public void Remover(ProdutoItem item)
        {
            var ListaProdutos = Consultar();
            var ItemLocalizado = ListaProdutos.SingleOrDefault(a => a.Id == item.Id);
            if (ItemLocalizado != null)
            {
                ListaProdutos.Remove(ItemLocalizado);
                Salvar(ListaProdutos);
            }

        }

        public List<ProdutoItem> Consultar()
        {
            if (Existe(key))
            {
                string valores = _cookie.Consultar(key);
                return JsonConvert.DeserializeObject<List<ProdutoItem>>(valores);
            }
            else
            {
                return new List<ProdutoItem>();
            }
        }

        public bool Existe(string Key)
        {
            return _cookie.Existe(key);            
        }
        public void RemoverTodos()
        {
            _cookie.Remover(key);
        }
    }

}

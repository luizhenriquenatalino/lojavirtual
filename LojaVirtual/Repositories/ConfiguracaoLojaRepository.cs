using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual.Repositories
{
    public class ConfiguracaoLojaRepository : IConfiguracaoLojaRepository
    {
        IConfiguration _conf;
        LojaVirtualContext _banco;

        public ConfiguracaoLojaRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;            
        }

        public void Cadastrar(ConfiguracaoLoja configuracaoLoja)
        {
            if (configuracaoLoja.Id == 0)
            {
                _banco.Add(configuracaoLoja);
            } else { 
                _banco.Update(configuracaoLoja);
            }
            _banco.SaveChanges();
        }

        public ConfiguracaoLoja ObterConfiguracao()
        {
            try
            {
                var configuracaoLoja = _banco.ConfiguracaoLojas.First();                
                if (configuracaoLoja.CustoDespesa == 0)
                {
                    configuracaoLoja.CustoDespesa = 400;
                }
                return configuracaoLoja;
            } 
            catch (Exception)
            {
                return new ConfiguracaoLoja() { CustoDespesa = 400, PercentualLucro = 0 };
            }
            
        }
    }
}

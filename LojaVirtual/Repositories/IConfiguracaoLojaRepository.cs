﻿using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public interface IConfiguracaoLojaRepository
    {
        void Cadastrar(ConfiguracaoLoja configuracaoLoja);
        ConfiguracaoLoja ObterConfiguracao();
    }
}

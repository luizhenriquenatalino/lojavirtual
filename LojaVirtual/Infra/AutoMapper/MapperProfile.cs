using AutoMapper;
using LojaVirtual.Models;

namespace LojaVirtual.Infra.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Produto, ProdutoItem>();
        }
    }
}

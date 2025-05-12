using Application.DTOs.Venda.Atualizar;
using Application.DTOs.Vendas.Filtro;
using AutoMapper;
using Domain.Commands.Vendas.Atualizar;

namespace Application.Mappings
{
    internal class DashBoardProfile : Profile
    {
        public DashBoardProfile()
        {
            CreateMap<AtualizarPedidoCommand, AtualizarPedidoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPedidoDto, AtualizarPedidoCommand>();
            CreateMap<PedidoDto, AtualizarPedidoCommand>();            
        }
    }
}
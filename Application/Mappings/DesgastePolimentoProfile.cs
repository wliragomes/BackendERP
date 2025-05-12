using Application.DTOs.Produtos.DesgastePolimentos;
using Application.DTOs.Produtos.DesgastePolimentos.Adicionar;
using Application.DTOs.Produtos.DesgastePolimentos.Atualizar;
using Application.DTOs.Produtos.DesgastePolimentos.Excluir;
using AutoMapper;
using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Domain.Commands.Produtos.DesgastePolimentos.Adicionar;
using Domain.Commands.Produtos.DesgastePolimentos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class DesgastePolimentoProfile : Profile
    {

        public DesgastePolimentoProfile()
        {
            CreateMap<AdicionarDesgastePolimentoCommand, AdicionarDesgastePolimentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarDesgastePolimentoDto, AdicionarDesgastePolimentoCommand>();
            CreateMap<DesgastePolimentoDto, AdicionarDesgastePolimentoCommand>();


            CreateMap<AtualizarDesgastePolimentoCommand, AtualizarDesgastePolimentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarDesgastePolimentoDto, AtualizarDesgastePolimentoCommand>();
            CreateMap<DesgastePolimentoDto, AtualizarDesgastePolimentoCommand>();

            CreateMap<FilterBulkBase, ExcluirDesgastePolimentoCommand>();
            CreateMap<ExcluirDesgastePolimentoCommand, ExcluirDesgastePolimentoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }


    }
}

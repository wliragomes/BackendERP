using Application.DTOs.Produtos.ClasseReajustes;
using Application.DTOs.Produtos.ClasseReajustes.Adicionar;
using Application.DTOs.Produtos.ClasseReajustes.Atualizar;
using Application.DTOs.Produtos.ClasseReajustes.Excluir;
using AutoMapper;
using Domain.Commands.Produtos.ClasseReajustes.Adicionar;
using Domain.Commands.Produtos.ClasseReajustes.Atualizar;
using Domain.Commands.Produtos.ClasseReajustes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ClasseReajusteProfile : Profile
    {

        public ClasseReajusteProfile()
        {
            CreateMap<AdicionarClasseReajusteCommand, AdicionarClasseReajusteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarClasseReajusteDto, AdicionarClasseReajusteCommand>();
            CreateMap<ClasseReajusteDto, AdicionarClasseReajusteCommand>();


            CreateMap<AtualizarClasseReajusteCommand, AtualizarClasseReajusteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarClasseReajusteDto, AtualizarClasseReajusteCommand>();
            CreateMap<ClasseReajusteDto, AtualizarClasseReajusteCommand>();

            CreateMap<FilterBulkBase, ExcluirClasseReajusteCommand>();
            CreateMap<ExcluirClasseReajusteCommand, ExcluirClasseReajusteDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }


    }
}

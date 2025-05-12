using Application.DTOs.Parametros.Adicionar;
using Application.DTOs.Parametros;
using AutoMapper;
using Domain.Commands.Parametros.Adicionar;
using Domain.Commands.Parametros.Atualizar;
using Domain.Commands.Parametros.Excluir;
using SharedKernel.SharedObjects;
using Domain.Commands.MedidasJumbo;
using Application.DTOs.Parametros.Atualizar;
using Application.DTOs.Parametros.Excluir;

public class ParametroProfile : Profile
{
    public ParametroProfile()
    {
        CreateMap<AdicionarParametroCommand, AdicionarParametroRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AdicionarParametroDto, AdicionarParametroCommand>();
        CreateMap<ParametroDto, AdicionarParametroCommand>();

        CreateMap<MedidaJumboDto, MedidaJumboCommand>();

        CreateMap<AtualizarParametroCommand, AtualizarParametroRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AtualizarParametroDto, AtualizarParametroCommand>();
        CreateMap<ParametroDto, AtualizarParametroCommand>();

        /* -----------------*/


        //CreateMap<AtualizarParametroRequestDto, AtualizarParametroCommand>()
        //    .ForMember(dest => dest.MedidaJumbo, opt => opt.MapFrom(src => src.Formulario.MedidaJumbo));


        /*---------------------*/
        CreateMap<FilterBulkBase, ExcluirParametroCommand>();
        CreateMap<ExcluirParametroCommand, ExcluirParametroDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
    }
}
using Application.DTOs.Auth;
using AutoMapper;
using Domain.Commands.Auth;
using Domain.Commands.Auth.ForgottenPassword;
using Domain.Commands.Auth.RecoveryPassword;
using Domain.Commands.Auth.UpdateAnyPassword;
using Domain.Commands.Auth.UpdatePassword;

namespace Application.Mappings
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginValueDto, LoginCommand>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Formulario.User))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Formulario.Password))
                .ForMember(dest => dest.EndActiveSessions, opt => opt.MapFrom(src => src.Formulario.EndActiveSessions));

            CreateMap<ForgottenPasswordValueDto, ForgottenPasswordCommand>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Formulario.Type))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Formulario.User))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Formulario.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Formulario.Phone))
                .ForMember(dest => dest.CpfCnpj, opt => opt.MapFrom(src => src.Formulario.CpfCnpj))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Formulario.BirthDate));

            CreateMap<RecoveryPasswordDto, RecoveryPasswordCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Formulario.UserId))
                .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Formulario.NewPassword))
                .ForMember(dest => dest.NewPasswordConfirmation, opt => opt.MapFrom(src => src.Formulario.NewPasswordConfirmation));

            CreateMap<UpdateLoginPasswordDto, UpdateLoginPasswordCommand>();

            //---------------
            //CreateMap<AddUserValuesDto, AddUserCommand>();
            //CreateMap<AddUserCommand, AddUserDto>()
            //    .ForMember(dest => dest.FormValues, opt => opt.MapFrom(src => src)).ReverseMap();
            //CreateMap<UserValuesDto, AddUserCommand>();

            //CreateMap<UpdateUserValueDto, UpdateUserCommand>();
            //CreateMap<UpdateUserCommand, UpdateUserDto>()
            //    .ForMember(dest => dest.FormValues, opt => opt.MapFrom(src => src)).ReverseMap();

            //CreateMap<FilterBulkBase, DeleteUserCommand>();
            //CreateMap<DeleteUserCommand, DeleteUserDto>()
            //    .ForMember(dest => dest.FormValues, opt => opt.MapFrom(src => src.DeleteBulkBase)).ReverseMap();

            CreateMap<UpdateLoginPasswordDto, UpdateLoginPasswordCommand>()
                //.ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.Formulario.IdUser))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Formulario.Password))
                .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Formulario.NewPassword))
                .ForMember(dest => dest.NewPasswordConfirmation, opt => opt.MapFrom(src => src.Formulario.NewPasswordConfirmation));

            CreateMap<UpdateAnyPasswordDto, UpdateAnyPasswordCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Formulario.UserId))
                .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Formulario.NewPassword))
                .ForMember(dest => dest.NewPasswordConfirmation, opt => opt.MapFrom(src => src.Formulario.NewPasswordConfirmation));

            //CreateMap<Users, UserReportDto>()
            //        .ForMember(dest => dest.Code, opt => opt.MapFrom(source => source.Code))
            //        .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name));

        }
    }
}

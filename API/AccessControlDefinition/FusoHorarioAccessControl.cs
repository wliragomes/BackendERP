using SharedKernel.Helpers.Authorization.AccessControlDefinition.Enum;

namespace API.AccessControlDefinition
{
    public static class FusoHorarioAccessControl
    {
        private const string BaseCode = $"{Modules.Cadastro}-{AccessControlCadastro.FusoHorario}-00-";

        public const string Read = $"{BaseCode}{AccessLevel.Read}";
        public const string Create = $"{BaseCode}{AccessLevel.Create}";
        public const string Delete = $"{BaseCode}{AccessLevel.Delete}";
        public const string Update = $"{BaseCode}{AccessLevel.Update}";
        public const string Print = $"{BaseCode}{AccessLevel.Print}";
    }
}

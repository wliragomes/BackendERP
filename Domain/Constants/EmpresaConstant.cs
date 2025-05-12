namespace Domain.Constants
{
    public class EmpresaConstant
    {
        public const int MaxLengthCpfCnpj = 18;
        public const int MaxLengthInscricaoEstadual = 50;
        public const int MaxLengthInscricaoSuframa = 50;
        public const int MaxLengthRazaoSocial = 255;
        public const int MaxLengthNomeFantasia = 255;

        public const string CARACTERES_PERMITIDO_18 = "Numero de Caracteres permitido ultrapassado, informe um novo de até 14 caracteres";
        public const string CARACTERES_PERMITIDO_50 = "Numero de Caracteres permitido ultrapassado, informe um novo de até 50 caracteres";
        public const string CARACTERES_PERMITIDO_255 = "Numero de Caracteres permitido ultrapassado, informe um novo de até 255 caracteres";
        public const string CPFCNPJ_JA_REGISTRADO = "CPFCNPJ já cadastrado! Informe um novo.";

    }
}


namespace Domain.Commands.Auth.Login
{
    public class ParameterizeGeneralCredentialsByCompany
    {
        public Guid? Id { get; set; }
        public Guid? IdCompany { get; set; }
        public int MinPasswordLength { get; set; }
        public int MaxPasswordLength { get; set; }
        public string? PasswordStructure { get; set; }
        public bool AcceptNumber { get; set; }
        public bool AcceptUppercase { get; set; }
        public bool AcceptLowercase { get; set; }
        public bool AcceptSpecialChar { get; set; }
        public bool? AllowPasswordWithUsername { get; set; }
        public bool? AllowPasswordWithVendorCode { get; set; }
        public bool? AllowSequentialChars { get; set; }
        public bool? AllowFirstThreeNonNumbers { get; set; }
        public int? MaximoTentativasInvalidas { get; set; }
        public bool ExibirTentativasRestantesLoginInvalido { get; set; }
        public string? AcaoSobreExcederTentativasInvalidas { get; set; }
        public bool? ValidatePreviousPasswords { get; set; }
        public int ConsiderLastXxPasswords { get; set; }
        public bool AllowMultipleConcurrentUserSessions { get; set; }
        public string? PasswordGenerationMethod { get; set; }
        public bool ValidateUserInactivity { get; set; }
        public int? InactivityDays { get; set; }
        public int PasswordExpiryDays { get; set; }
        public int? NotifyXDaysBeforePasswordExpiry { get; set; }
        public int? MaxInvalidAttemptsConsorcioChannel { get; set; }
    }
}

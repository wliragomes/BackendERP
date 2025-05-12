using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Usuarios
{
    public class Users : EntityId
    {
        public string UserName { get; private set; }
        public string Senha { get; private set; }
        public Guid IdPessoa { get; private set; }
        public bool Status { get; private set; }
        public DateTime? LastLoginDetailsMobile { get; private set; }
        public DateTime? LastLoginDetailsApis { get; private set; }

        public int? Tentativas { get; private set; }
        public short? Blocked { get; private set; }

        public decimal? UnblockCode { get; private set; }
        public DateTime? UnBlockCodeExpire { get; private set; } = DateTime.UtcNow;

        public DateTime? LastLoginDetailsWeb { get; private set; }
        public DateTime? LastPasswordCreation { get; private set; }
        public bool? SpecialPermission { get; private set; }
        public string? EmailRecovery { get; private set; }
        public string? PhoneRecovery { get; private set; }

        public Pessoa? Pessoa { get; private set; }
        public ICollection<RelacionaUsuarioFuncionalidadeNivelAcesso>? RelacionaUsuarioFuncionalidadeNivelAcesso { get; private set; }

        public Users()
        {
        }

        public Users(string userName, string password, Guid idPeople)
        {
            SetId(Guid.NewGuid());
            UserName = userName;
            Senha = password;
            IdPessoa = idPeople;
            SpecialPermission = false;
            Status = true;

            SetCreateAtAndUpdateAtToNow();
        }

        public Users(string userName, string password, Guid idPeople, string phoneRecovery, string emailRecovery, bool status,
            short blocked, DateTime? lastLoginDetailsWeb, DateTime? lastLoginDetailsMobile, DateTime? lastLoginDetailsApis, 
            DateTime lastPasswordCreation, bool specialPermission)
        {
            UserName = userName;
            Senha = password;
            IdPessoa = idPeople;
            EmailRecovery = emailRecovery;
            PhoneRecovery = phoneRecovery;
            Status = status;
            Blocked = blocked;
            LastLoginDetailsWeb = lastLoginDetailsWeb;
            LastLoginDetailsMobile = lastLoginDetailsMobile;
            LastLoginDetailsApis = lastLoginDetailsApis;
            LastPasswordCreation = lastPasswordCreation;
            SpecialPermission = specialPermission;

            SetCreateAtAndUpdateAtToNow();
        }

        public Users(Guid id, string password, Guid idPeople, bool status)
        {
            SetId(id);
            Senha = password;
            IdPessoa = idPeople;
            Status = status;

            SetCreateAtAndUpdateAtToNow();
        }

        public Users(Guid id, Guid idPeople, int blocked, bool specialPermission)
        {
            SetId(id);
            IdPessoa = idPeople;
            Blocked = (short)blocked;
            SpecialPermission = specialPermission;
        }

        public void Update(Guid idPeople,bool specialPermission, string emailRecovery, string phoneRecovery)
        {
            IdPessoa = idPeople;
            SpecialPermission = specialPermission;            
            EmailRecovery = emailRecovery;
            PhoneRecovery = phoneRecovery;

            ChangeUpdateAtToDateTimeNow();
        }

        public void SetPassword(string encryptedPassword)
        {
            Senha = encryptedPassword;
            LastPasswordCreation = DateTime.UtcNow;
        }

        public void SetAttempts()
        {
            Tentativas++;
        }

        public void ClearAttempts()
        {
            Tentativas = 0;
        }

        public void SetBlock(short reason)
        {
            Blocked = reason;
        }

        public void SetLastLoginDetailsWeb()
        {
            LastLoginDetailsWeb = DateTime.UtcNow;
        }

        public void SetLastPasswordCreation()
        {
            LastPasswordCreation = DateTime.UtcNow;
        }
    }
}

namespace Domain.Constants
{
    public class LoginConstant
    {
        public const string ACESSO_BLOQUEADO = "Usuário bloqueado! Entre em contato com o administrador!";
        public const string USER_INACTIVITY = "Usuário inativo! Entre em contato com o administrador.";
        public const string USUARIO_NAO_ENCONTRADO = @"Usuário ou senha inválida! Tente novamente ou clique em “Esqueci minha senha” para recuperá-la.";
        public const string USUARIO_NAO_ENCONTRADO_POR_TENTATIVAS = USUARIO_NAO_ENCONTRADO + @" Tentativas de acesso restantes para bloqueio do usuário: {0}";
        public const string USUARIO_BLOQUEADO_EXCEDEU_TENTATIVAS = @"Usuário bloqueado por tentativas de acesso inválidas! Entre em contato com o administrador!";
        public const string USUARIO_BLOQUEADO_INATIVIDADE = @"Usuário bloqueado por inatividade! Entre em contato com o administrador!";
        public const string AUTENTICACAO_DE_DOIS_FATORES = "Autenticação de 2 fatores";
        public const string USER_ALREADY_LOGGED_IN = "Usuário já possui sessão ativa. Deseja encerrá-la?";
        public const string PASSWORD_WILL_EXPIRE = "Sua senha irá expirar em {0} {1}. Acesse o link abaixo para atualizá-la";
        public const string PASSWORD_EXPIRE_TODAY = "Sua senha irá expirar hoje. Acesse o link abaixo para atualizá-la";
        public const string NOT_ALLOWED_FOR_THIS_TIME = "Tentativa de acesso fora do período permitido!";
        public const string EXPIRED_PASSWORD = "Senha expirada! Entre em contato com o administrador!";
        public const string USER_NO_DEFAULT_ADMIN = "Usuário não tem administradora padrão";
        public const string USER_WITHOUT_ADMIN_ACCESS = "Usuário não tem acesso à administradora";

        public const short Inatividade = 1;
        public const short TentativasInvalidas = 2;
        public const short BloqueadoPorUsuario = 3;
        public const short MaxLengthUser = 30;
    }
}

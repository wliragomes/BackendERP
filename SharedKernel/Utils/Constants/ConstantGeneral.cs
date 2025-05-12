namespace SharedKernel.Utils.Constants
{
    public static class ConstantGeneral
    {
        public const string REQUIRED_FIELD = "Obrigatório.";
        public const string NAME_ALREADY_REGISTERED = "Nome já utilizado. Informe um novo.";
        public const string FIELD_ALREADY_REGISTERED = "{0} já utilizado. Informe um novo.";
        public const string CANNOT_GREATER_THAN = "O campo não deve aceitar mais que {0} caracteres.";
        public const string MUST_ALPHANUMERIC = "O campo só aceita letra e números.";
        public const string MUST_NUMERIC = "O campo só aceita números.";
        public const string CANNOT_BE_NULL = "O campo não pode ser nulo.";
        public const string EXACT_SIZE = "O campo deve ter exatamente {0} caracteres.";
        public const string ERROR_ENTITY_VALIDATION_NULL_OR_MAX_LENGTH = "Erro na validação dos dados. Entidade nula ou tamanho acima do configurado.";

        // Campo Id
        public const string PROPERTY_ID_NAME = "Id";

        public const string NOT_FOUND = "Sem registros encontrados para o Id fornecido.";
        public const string SELECTED_AND_NOT_SELECTED_IDS = "Não é possível enviar Id's Selecionados e Id's não Selecionados na mesma requisição.";

        // Campo codigo
        public const string CODE_INVALID_VALUE = "Código inválido. Informe um novo.";

        public const string CODE_ALREADY_REGISTERED = "Código já utilizado. Informe um novo.";

        // Mensagens genéricas do DELETE
        public const string CANNOT_HAVE_LINKED_BOUND = "A exclusão não foi realizada. O item está vinculado a um cadastro.";

        public const string FIELD_REMOVED_CANNOTBE_EQUALDB = "O registro não pode ser excluído porque já foi excluído anteriormente.";

        // DomainException
        public const string ERROR_ENTITY_VALIDATION = "Erro na validação dos dados. Entidade nula ou tamanho acima do configurado.";

        public const string SELECTION_SELECT = "SELECIONE";
        public const string SELECTION_ACCEPT = "ACEITAR";
        public const string SELECTION_NOT_ACCEPTT = "NÃO ACEITAR";

        public const string HelveticaBold = "Helvetica-Bold";
        public const string Helvetica = "Helvetica";
    }
}

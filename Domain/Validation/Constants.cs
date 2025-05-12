namespace Domain.Validation
{
    public static class Constants
    {
        public const string CANNOT_BE_NULL = "O campo não pode ser nulo.";
        public const string CANNOT_BE_NULL_LIST = "A lista de {0} não pode ser nula";
        public const string CANNOT_BE_EMPTY = "O campo não pode ser vazio.";
        public const string CANNOT_GREATER = "O campo não deve aceitar mais que";
        public const string CANNOT_GREATER_THAN = "O campo não deve aceitar mais que {0} caracteres.";
        public const string CANNOT_GREATER_200 = "O campo não deve aceitar mais que 200 caracteres.";
        public const string CANNOT_GREATER_50 = "O campo não deve aceitar mais que 50 caracteres.";
        public const string CANNOT_GREATER_3 = "O campo não deve aceitar mais que 3 caracteres.";
        public const string DATE_NOT_CORRECT_FORMAT = "Campo DATA em formato incorreto.";
        public const string STATUS_NOT_CORRECT_FORMAT = "Campo STATUS em formato incorreto.";
        public const string REMOVED_NOT_CORRECT_FORMAT = "Campo REMOVIDO não esta no formato correto.";
        public const string GUID_NOT_CORRECT_FORMAT = "Campo ID(GUID) não esta no formato correto.";
        public const string FILE_NOT_CORRECT_FORMAT = "Campo FILE não esta no formato correto.";
        public const string ID_VALID_GUID = "O campo ID tem que ser um GUID válido";
        public const string CANNOT_HAVE_LINKED_BOUND = "A exclusão não foi realizada. O item está vinculado a um cadastro.";
        public const string REGISTER_NOT_FOUND = "Nenhum registro encontrado para o ID fornecido.";
        public const string MUST_ALPHANUMERIC = "O campo só aceita letra e números.";
        public const string ENTITY_NOT_FOUND = "Sem registros encontrados para o Id fornecido";
        public const string INVALID_CODE = "Código inválido. Informe um novo.";
        public const string CODE_ALREADY_REGISTERED = "Código já utilizado. Informe um novo.";
        public const string NAME_ALREADY_REGISTERED = "Nome já utilizado. Informe um novo.";
        public const string REGISTER_NOT_FOUND_BY_PARAMETER = "Nenhum registro encontrado.";
        public const string CANNOT_DELETE_ASSET_OBJECT = "Para realizar a exclusão do registro, primeiro é necessário realizar a exclusão das vigências atribuídas a esse bem objeto.";
        public const string CANNOT_DELETE_ASSET_OBJECT_WITH_BOUND = "Primeiro deverá ser realizada a exclusão do cadastro de bem base para reajuste.";
        public const string EFFECTIVEDATE_NOT_FOUND = "Sem vigências encontradas para o Id informado.";
        public const string EFFECTIVEDATE_FINISH_FIRST_EFFECTIVE_DATES = "Deve finalizar as vigências ativas atribuídas ao bem objeto base de reajuste.";
        public const string EFFECTIVEDATE_FINISH_FIRST_BOUNDS = "Deve excluir o vínculo dos bens objetos que estejam utilizando o bem objeto base para o reajuste de preço.";
        public const string EFFECTIVEDATE_DELETE_BOUND_ASSET_OBJECT_PLAN_COMMERCIAL = "A exclusão não foi realizada. O item possui vigências ativas atribuídas aos planos comerciais.";
    }
}

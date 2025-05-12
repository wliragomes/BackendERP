namespace Domain.Constant
{
    public static class ErrorMessages
    {
        public const string USER_ID_EMPTY = "Usuário não informado.";
        public const string REQUIRED_FIELD = "Obrigatório.";
        public const string ValorInvalido = "Valor inválido.";
        public const string ERROR_REGISTER_NOT_FOUND = "Nenhum registro encontrado para o ID fornecido.";
        public const string CANNOT_HAVE_LINKED_BOUND = "A exclusão não foi realizada. O item está vinculado a um cadastro.";
        public const string CANNOT_HAVE_IDSELECT_AND_IDNOTSELECTED = "Ambos os campos id selecionado e id não selecionado foram preenchidos.";
        public const string REGISTER_NOT_FOUND_BY_PARAMETER = "Nenhum registro encontrado.";
        public const string ERROR_CANNOT_GREATER_THAN = "O campo não deve aceitar mais que {0} caracteres.";
        public const string ERROR_NAME_ALREADY_REGISTERED = "Nome já utilizado! Informe um novo.";
        public const string CANNOT_BE_EMPTY = "O campo não pode ser vazio.";
    }
}

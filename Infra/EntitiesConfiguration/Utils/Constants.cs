namespace Domain.Utils
{
    public static class Constants
    {
        public const int MIN_PAGESIZE = 15;
        public const int BATCH_SIZE = 1000;

        public const string NOT_FOUND = "Sem registros encontrados para o Id fornecido.";
        public const string NOT_FOUND_LIST = "Nenhum registro encontrado para o Id's fornecidos.";
        public const string CODE_ALREADY_REGISTERED = Validation.Constants.CODE_ALREADY_REGISTERED;
        public const string NAME_ALREADY_REGISTERED = Validation.Constants.NAME_ALREADY_REGISTERED;
        public const string ENTITY_VALIDATION_ERROR = "Erro na validação dos dados. Verifique as informações enviadas e tente novamente.";
        public const string CANNOT_GREATER_THAN = Validation.Constants.CANNOT_GREATER_THAN;
        public const string ERROR_ENTITY_VALIDATION_NULL_OR_MAX_LENGTH = "Erro na validação dos dados. Entidade nula ou tamanho acima do configurado.";

        public const string CODE_ALREADY_REGISTERED_WITH_PARAM = "Código {0} já utilizado. Informe um novo.";
        public const string NAME_ALREADY_REGISTERED_WITH_PARAM = "Nome {0} já utilizado. Informe um novo.";

        public const string CANNOT_HAVE_IDSELECT_AND_IDNOTSELECTED = "Ambos os campos id selecionado e id não selecionado foram preenchidos.";

        public const string CANNOT_BE_NULL = Validation.Constants.CANNOT_BE_NULL;
        public const string CANNOT_BE_EMPTY = Validation.Constants.CANNOT_BE_EMPTY;
        public const string CANNOT_LESS_1 = "O número não pode ser menor que 1.";
        public const string INTEGER_FIELD = "O campo tem que ser um inteiro positivo.";
        public const string CANNOT_GREATER3 = "O campo não deve aceitar mais que 3 caracteres.";
        public const string CANNOT_GREATER6 = "O campo não deve aceitar mais que 6 caracteres.";
        public const string CANNOT_GREATER10 = "O campo não deve aceitar mais que 10 caracteres.";
        public const string CANNOT_GREATER50 = "O campo não deve aceitar mais que 50 caracteres.";
        public const string CANNOT_GREATER100 = "O campo não deve aceitar mais que 100 caracteres.";
        public const string CANNOT_GREATER200 = "O campo não deve aceitar mais que 200 caracteres.";
        public const string ID_VALID_GUID = Validation.Constants.ID_VALID_GUID;
        public const string IDs = "IDs";


        public const string REGISTER_ID_NOT_FOUND = "Nenhum registro encontrado para o Id: ";
        public const string REQUIRED_FIELD = "Obrigatório.";


        public const string TOTAL_OF_RECORDS = "Quantidade de registros";
        public const string CODE_INVALID_VALUE = "Código inválido. Informe um novo.";
        public const string CODE_NULL = "O code não deve ser nulo.";
        public const string INACTIVE = "Inactive";
        public const string ACTIVE = "active";
        public const string ALL = "all";
        public const string DUPLICATED_CODE = "O Código está duplicado";
        public const string DUPLICATED_NAME = "O nome está duplicado";
        public const string DUPLICATED_ID = "O Id está duplicado";


        public const string MAX_YEAR_MOBILE_WARRANTY_OUT_OF_RANGE = "O valor de garantia móvel deve estar entre 0 e 99.";
        public const string MINIMUM_AMOUNT_CHARGERS_PARCEL_OUT_OF_RANGE = "O Valor da parcela deve estar entre R$0,00 e R$9.999.999.999,99.";
        public const string MINIMUM_AMOUNT_CHARGERS_DIFFERENCE_OUT_OF_RANGE = "O Valor da diferença deve estar entre R$0,00 e R$9.999.999.999,99.";
        public const string MINIMUM_AMOUNT_CHARGERS_OTHER_OUT_OF_RANGE = "O Valor das demais cobranças deve estar entre R$0,00 e R$9.999.999.999,99.";
        public const string MINIMUM_AMOUNT_DIFFERENTS_REQUIRED = REQUIRED_FIELD;
        public const string MINIMUM_AMOUNT_OTHERS_REQUIRED = REQUIRED_FIELD;
        public const string DISCHARGE_MAX_VALUE_NULL_EMPTY = REQUIRED_FIELD;
        public const string DISCHARGE_MAX_VALUE_OUT_OF_RANGE = "O valor máximo devedor deve estar entre R$0,01 e R$9.999.999.999,99.";
        public const string DISCHARGE_MIN_PERCENTAGE_NULL_EMPTY = REQUIRED_FIELD;
        public const string DISCHARGE_MIN_PERCENTAGE_OUT_OF_RANGE = "O percentual mínimo deve estar entre 000.000001% e 100.000000%.";
        public const string SEGMENT_NULL_OR_EMPTY_ON_ADD_PRODUCT = REQUIRED_FIELD;
        public const string SEGMENT_NULL_OR_EMPTY_ON_UPDATE_PRODUCT = REQUIRED_FIELD;
        public const string SEGMENT_NOT_FOUND = "Segmento não cadastrado! Selecione ou informe um código existente.";
        public const string SEGMENT_OUT_OF_RANGE = "O código do segmento não pode ter mais de 2 caracteres.";
        public const string PROPERTY_CLASSIFICATION_NULL_OR_EMPTY_ON_ADD_PRODUCT = REQUIRED_FIELD;
        public const string PROPERTY_CLASSIFICATION_NULL_OR_EMPTY_ON_UPDATE_PRODUCT = REQUIRED_FIELD;
        public const string PROPERTY_CLASSIFICATION_NOT_FOUND = "Classificação do bem objeto não cadastrado! Selecione ou informe um código existente.";
        public const string PROPERTY_CLASSIFICATION_OUT_OF_RANGE = "O código da classificação do bem objeto não pode ter mais de 1 caractere.";
        public const string CODE_NULL_OR_EMPTY_ON_ADD_PRODUCT = REQUIRED_FIELD;
        public const string CODE_NULL_OR_EMPTY_ON_UPDATE_PRODUCT = REQUIRED_FIELD;
        public const string CODE_OUT_OF_RANGE = "O código não pode ter mais de 3 caracteres.";
        public const string NAME_NULL_OR_EMPTY_ON_ADD_PRODUCT = REQUIRED_FIELD;
        public const string NAME_NULL_OR_EMPTY_ON_UPDATE_PRODUCT = REQUIRED_FIELD;
        public const string NAME_OUT_OF_RANGE = "O nome não pode ter mais de 50 caracteres.";
        public const string SAG_NULL_OR_EMPTY_ON_ADD_PRODUCT = REQUIRED_FIELD;
        public const string SAG_NULL_OR_EMPTY_ON_UPDATE_PRODUCT = REQUIRED_FIELD;
        public const string NAME_IMAGE_OUT_OF_RANGE = "O nome do arquivo da imagem deve ter no mínimo 20 caracteres.";

        public const string SAG_OUT_OF_RANGE_ON_ADD_PRODUCT = "O segmento SAG cota não pode ter mais de 2 dígitos.";
        public const string SAG_WITH_NON_NUMBER = "Segmento SAG Cota inválido! Informe um novo.";
        public const string ICON_NOT_FOUND = "Ícone não cadastrado! Selecione ou informe um existente.";
        public const string ID_PRODUCT_NOT_FOUND_ON_ADD_PRODUCT = "Produto não cadastrado! Selecione ou informe um produto existente.";
        public const string ID_PRODUCT_NOT_FOUND_ON_UPDATE_PRODUCT = "Produto não cadastrado! Selecione ou informe um produto existente.";
        public const string IDS_PRODUCT_PROPERTY = "idsProducts";

        public const string ASSET_OBJECT_NOT_REGISTERED = "Bem objeto não cadastrado! Selecione ou informe um bem objeto existente";

        public const string FACTORY_NOT_FOUND = "Fabricante não encotrado para o Id fornecido";
        public const string FACTORY_REMOVED = "O fabricante não pode ser atualizado, pois já foi removido";
        public const string FACTORY_NOT_REGISTERED = "Fabricante não cadastrado! Selecione ou informe um fabricante existente";
        public const string FACTORY_COD_ALPHANUMERIC = Validation.Constants.MUST_ALPHANUMERIC;

        public const string VIGENCY_OPEN_ERROR = "A abertura da vigência não foi realizada. O item não possui data final da vigência.";
        public const string VIGENCY_CANNOT_BE_CHANGED = "Esta vigência não pode ser alterada.";
        public const string VIGENCY_NOT_LAST = "Não é a última vigência.";
        public const string INVALID_DATE_CURRENT = "Data inválida! Informe data igual ou maior que a data atual.";
        public const string INVALID_DATE_REGISTERED = "Data inválida! Informe data maior ou igual que a cadastrada.";
        public const string INVALID_DATE_FINAL = "Data inválida! Informe uma data igual ou maior que o início da vigência.";
        public const string INITIAL_DATE_SHOULD_BE_BEFORE_FINAL = "A data inicial deve ser anterior à data final.";
        public const string DATE_RANGE_OVERLAP = "Data inválida! Informe data maior que a cadastrada.";
        public const string DATE_VIGENCY_FINAL_DATE_INVALID_LESS = "Data inválida! Informe data menor que a cadastrada.";
        public const string DATE_VIGENCY_FINAL_DATE_INVALID = "Data inválida! Informe data maior que o final da última vigência.";
        public const string MUST_ALPHANUMERIC = Validation.Constants.MUST_ALPHANUMERIC;
        public const string DISABLE_PARAMETER = "Parâmetro desabilitado para esta funcionalidade.";

        public const string CANNOT_UPDATE_PRICE_PER_PERGION_NATIONAL_REGION = "Não foi possível alterar o preço por região marcado como região nacional atual, pois o mesmo ja está vinculado a um reajuste";
        public const string CANNOT_ADD_PRICE_PER_REGION_NATIONAL_REGION = "Não foi possível adicionar como região nacional, pois um preço por região da lista já foi cadastrado como região nacional";
        public const string NAME_NULL_OR_EMPTY_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string NAME_NULL_OR_EMPTY_ON_UPDATE_ASSETOBJECT = REQUIRED_FIELD;
        public const string CODE_NULL_OR_EMPTY_ON_UPDATE_ASSETOBJECT = REQUIRED_FIELD;
        public const string CODE_NULL_OR_EMPTY_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string UPDATE_PRICE_NULL_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string UPDATE_PRICE_BY_FACTORY_NULL_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string IS_BOUND_PLAN_COMMERCIAL_NULL_OR_EMPTY_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string IMAGE_NULL_OR_EMPTY_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;
        public const string ASSET_OBJECT_TYPE_NULL_OR_EMPTY_ON_ADD_ASSETOBJECT = REQUIRED_FIELD;

        public const string CORRECTION_INDEX_NOT_REGISTERED = "Índice de correção não cadastrado! Selecione ou informe um índice existente";
        public const string CORRECTION_INDEX_NOT_ACTIVE = "Índice de correção não está ativo! Selecione ou informe um índice ativo";

        // Mensagens genéricas do DELETE
        public const string DELETE_SELECTED_AND_NOT_SELECTED_IDS = "Não é possível enviar Id's Selecionados e Id's não Selecionados na mesma requisição";
        public const string CANNOT_HAVE_LINKED_BOUND = "A exclusão não foi realizada. O item está vinculado a um cadastro.";
        public const string CANNOT_HAVE_EFFECTIVE_DATE = "O vínculo não pode ser desfeito pois possui vigência aberta";
        public const string WRONG_FILE_FORMAT_SIZE = "Formato ou tamanho do arquivo diferente do permitido.";
        public const string NEED_NULL = "O campo precisa ser nulo";
        public const string NEED_EMPTY = "O campo precisa estar vazio";


        // Mensagens validacao para - AssetObject 
        public const string NEED_EMPTY_ASSET = "Esse parâmetro não deve ser informado para bens classificados como imóvel ou serviços.";
        public const string INVALID_ASSET = "É necessário este bem objeto ter a opção atualizar preço pela tabela do fabricante como verdadeiro.";
        public const string NOT_FOUND_ASSET_TYPE = "Tipo de bem objeto inexistente.";

        // Mensagens validações para - CreditLimit
        public const string INVALID_DATE_MUST_BE_GREATER_THAN_LAST = "Data inválida! Informe uma data maior que o último cadastro de vigência.";

        // Mensgens validações para - BoundAssetObject
        public const string CANT_BE_SAME_ASSETOBJECT = "Não é possível informar o mesmo bem como base de reajuste e bem reajustado.";
        public const string BASE_DOESNT_EXIST = "O bem objeto informado não é base de reajuste.";
        public const string ASSET_HASNT_EFFECTIVE_DATE = "O bem objeto informado não é vigente.";
        public const string ASSET_IS_BASE = "O bem objeto informado é base de reajuste e não pode ser reajustado.";
        public const string LIST_OF_INVALIDS_GUIDS = "A lista contém Guids inválidos.";

        public const string URL_APPSETTINGS_CONFIGURATION = "ProjectsUrls:UrlConfiguration";
        public const string URL_APPSETTINGS_VIGENCIA = "MsVigenciaUrl";
    }
}

using Domain.Interfaces.Repositories;

namespace Domain.Commands.Common
{
    public class SharedMethods
    {
        private readonly IUnitOfWork _unitOfWork;
        public SharedMethods(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SharedMethods()
        {
        }

        //public async Task<Users> GetUserByAccessCodeOrCpfCnpj(bool allowCpfCnpj, string accessCodeOrCpfCnpj)
        //{
        //    Users? user = null;
        //    if (allowCpfCnpj)
        //        user = await _unitOfWork.UserRepository.GetUserByCpfCnpj(accessCodeOrCpfCnpj);

        //    user ??= await _unitOfWork.UserRepository.GetUserByAccessCode(accessCodeOrCpfCnpj);

        //    return user;
        //}

        public async Task<bool> ItemExistInDb(Guid? id, IUnitOfWork _unitOfWork)
        {
            var resp = await _unitOfWork.UserRepository.Exists(id);
            return resp;
        }

        //public async Task<ParameterizeGeneralCredentialsByCompanyResponse?> GetParameterGeral(HttpRequestCommon? _httpRequestCommon)
        //{
        //    var result = await _httpRequestCommon!.GetParameterizeGeneralData();
        //    return result.Data == null ? new ParameterizeGeneralCredentialsByCompanyResponse() : result.Data!.Item;
        //}

        //public bool ValidatePassword<T>(string password, ParameterizeGeneralCredentialsByCompanyResponse? _parameterizeGeneralCredentialsByCompanyResponse, TesteResponse<T> _response, string propertyPasswordName = "newPassword")
        //{
        //    var errorMsg = "";
        //    if (_parameterizeGeneralCredentialsByCompanyResponse!.MinPasswordLength > 0 || _parameterizeGeneralCredentialsByCompanyResponse!.MaxPasswordLength > 0)
        //    {
        //        string digitoOrDigitos = _parameterizeGeneralCredentialsByCompanyResponse.MinPasswordLength > 1 ? "dígitos" : "dígito";
        //        errorMsg += "conter " + $"no mínimo {_parameterizeGeneralCredentialsByCompanyResponse.MinPasswordLength!.ToString().PadLeft(2, '0')} {digitoOrDigitos}";

        //        digitoOrDigitos = _parameterizeGeneralCredentialsByCompanyResponse.MaxPasswordLength > 1 ? "dígitos" : "dígito";
        //        errorMsg += $", no máximo {_parameterizeGeneralCredentialsByCompanyResponse.MaxPasswordLength.ToString().PadLeft(2, '0')} {digitoOrDigitos}";
        //    }

        //    var errorMsgComplexa = string.Empty;
        //    if (_parameterizeGeneralCredentialsByCompanyResponse.PasswordStructure!.ToLower() == "complexa")
        //    {
        //        List<string> msgError = new List<string>();
        //        if (_parameterizeGeneralCredentialsByCompanyResponse.AcceptNumber == true)
        //            msgError.Add("números");

        //        if (_parameterizeGeneralCredentialsByCompanyResponse.AcceptSpecialChar == true)
        //            msgError.Add("caracteres especiais");

        //        if (_parameterizeGeneralCredentialsByCompanyResponse.AcceptUppercase)
        //            msgError.Add("letras maiúsculas");

        //        if (_parameterizeGeneralCredentialsByCompanyResponse.AcceptLowercase)
        //            msgError.Add("letras minúsculas");

        //        if (msgError.Count > 0)
        //        {
        //            var errorMsgComplexaAux = string.Empty;
        //            foreach (var item in msgError)
        //            {
        //                errorMsgComplexaAux += (errorMsgComplexaAux != string.Empty ? (item == msgError[msgError.Count - 1] ? " e " : ", ") : string.Empty) + item;
        //            }

        //            errorMsg += ", possuir " + errorMsgComplexaAux;
        //        }
        //    }

        //    errorMsg += errorMsgComplexa;

        //    if (errorMsg != string.Empty)
        //    {
        //        var msgError = "Senha não atende o padrão definido! A senha deverá " + errorMsg + "!";
        //        _response.AddError(propertyPasswordName, msgError, password);
        //        return false;
        //    }

        //    return true;
        //}

        //public async Task<bool> PasswordAlreadyExist<T>(Guid userId, string password, ParameterizeGeneralCredentialsByCompanyResponse? _parameterizeGeneralCredentialsByCompanyResponse, TesteResponse<T> _response)
        //{
        //    var serializedPassword = LibraryCryptography.PasswordEncryption.EncryptPassword(password);
        //    var result = await _unitOfWork.LastUsedPasswordsRepository.PasswordAlreadyExist(serializedPassword, userId, _parameterizeGeneralCredentialsByCompanyResponse!.ConsiderLastXxPasswords);
        //    if (result)
        //    {
        //        _response.AddError(UserConstant.PROPERTY_PASSWORD_NEW, UserConstant.PASSWORD_ALREADY_EXISTS, password);
        //        return true;
        //    }
        //    return false;
        //}

        public string FormatCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            if (cpfCnpj.Length <= 11)
            {
                return Convert.ToUInt64(cpfCnpj).ToString(@"000\.000\.000\-00");
            }

            return Convert.ToUInt64(cpfCnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        //#region Password



        //public void ValidatePassword<T>(string password, string CodeSeller, string? userName,
        //    ParameterizeGeneralCredentialsByCompanyResponse passwordParameters, TesteResponse<T> response, string propertyPasswordName)
        //{
        //    if (PasswordWithBlankSpace(password))
        //    {
        //        response.AddError(propertyPasswordName, UserConstant.NOT_ALLOWED_PASSWORD_SPACE_BLANK, password);
        //        return;
        //    }

        //    if (!passwordParameters.AllowPasswordWithUsername!.Value && userName != null && password.Length > 3)
        //    {
        //        var input = Regex.Replace(password, @"^[^a-zA-Z0-9]+", "");
        //        var palavrasTexto = Regex.Split(userName, @"\W+").ToList();
        //        palavrasTexto = palavrasTexto.Where(x => x.Length > 2).ToList();
        //        string padrao = @"(" + string.Join("|", palavrasTexto.Select(Regex.Escape)) + @")";
        //        Regex regex = new Regex(padrao, RegexOptions.IgnoreCase);
        //        if (regex.IsMatch(input))
        //        {
        //            response.AddError(propertyPasswordName, UserConstant.NOT_ALLOWED_PASSWORD_USERNAME, password);
        //            return;
        //        }

        //    }

        //    if (!passwordParameters.AllowPasswordWithVendorCode!.Value &&
        //         (!string.IsNullOrEmpty(CodeSeller!) && PasswordHasVendorCode(password, CodeSeller!)))
        //    {
        //        response.AddError(propertyPasswordName, UserConstant.NOT_ALLOWED_PASSWORD_VENDOR_CODE, password);
        //        return;
        //    }

        //    if (!passwordParameters.AllowSequentialChars!.Value &&
        //        PasswordHasSequentialChars(password))
        //    {
        //        response.AddError(propertyPasswordName, UserConstant.NOT_ALLOWED_PASSWORD_SEQUENTIAL_CHAR, password);
        //        return;
        //    }

        //    if (!passwordParameters.AllowFirstThreeNonNumbers!.Value &&
        //        !PasswordHasFirstThreeNonNumbers(password))
        //    {
        //        response.AddError(propertyPasswordName, UserConstant.ONLY_ALLOWED_PASSWORD_INITIAL_NUMBERS, password);
        //        return;
        //    }

        //    if (!PasswordIsValid(password, passwordParameters))
        //    {
        //        SharedMethods sharedMethods = new SharedMethods(_unitOfWork);
        //        sharedMethods.ValidatePassword(password, passwordParameters, response, propertyPasswordName);

        //        //return;
        //    }
        //}

        //public bool PasswordIsValid(string password,
        //    ParameterizeGeneralCredentialsByCompanyResponse passwordParams)
        //{
        //    var passwordObject = new LibraryCryptography.ObjectValidate(
        //        passwordParams.MinPasswordLength,
        //        passwordParams.MaxPasswordLength,
        //        passwordParams.PasswordStructure == "COMPLEXA",
        //        passwordParams.AcceptNumber,
        //        passwordParams.AcceptSpecialChar,
        //        passwordParams.AcceptUppercase,
        //        passwordParams.AcceptLowercase);

        //    return LibraryCryptography.PasswordEncryption.IsPasswordValidWithObject(password, passwordObject);
        //}

        //private bool PasswordHasFirstThreeNonNumbers(string password)
        //{
        //    if (password.Length < 3)
        //        return false;

        //    var isNumber = int.TryParse(password.Substring(0, 3), out int _);
        //    return isNumber;
        //}

        //private bool PasswordHasSequentialChars(string password)
        //{
        //    for (int index = 0; index < password.Length - 2; index++)
        //    {
        //        var character1 = password[index];
        //        var character2 = password[index + 1];
        //        var character3 = password[index + 2];

        //        if (character1 + 1 == character2 && character2 + 1 == character3)
        //            return true;
        //    }

        //    return false;
        //}

        //private bool PasswordHasVendorCode(string password, string codeSeller)
        //{
        //    const int sellerCodeLength = 6;
        //    return password.Contains(codeSeller.ReturnHandlerCode(sellerCodeLength));
        //}

        //private bool PasswordWithBlankSpace(string password)
        //{
        //    return password.Contains(" ");
        //}


        //public async Task<ResponseObjectDto<ParameterizeGeneralCredentialsByCompanyResponse?>> GetParameterizeGeneralData(string _msConfigurationUrl, IHttpRequestCustom _httpRequestCustom)
        //{
        //    var url = new HttpRequestCustomUrl(_msConfigurationUrl, "ParameterizeGeneral", "get-parameterize-general-credentials");

        //    dynamic result = await _httpRequestCustom.Get<dynamic>(url, null);

        //    var objectResult = JsonConvert.DeserializeObject<ResponseObjectDto<ParameterizeGeneralCredentialsByCompanyResponse>>(result!.ToString());

        //    return objectResult;
        //}

        //#endregion


        //public void SendTokenMessage(Users user)
        //{
        //    Random random = new Random();
        //    var token = random.Next(100000, 999999);
        //    user.SetUnBlockCode(token);
        //    user.SetUnBlockCodeExpiration(DateTime.UtcNow.AddMinutes(5));
        //    //TODO: Enviar token por SMS
        //}
    }
}

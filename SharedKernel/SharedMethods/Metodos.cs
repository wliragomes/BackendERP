using System.Globalization;
using System.Text;

namespace SharedKernel.SharedMethods
{
    public class Metodos
    {
        public static string FormatarCpfCnpj(string cpfCnpj)
        {
            if (cpfCnpj.Length == 11)
            {
                return Convert.ToUInt64(cpfCnpj).ToString(@"000\.000\.000\-00");
            }
            else if (cpfCnpj.Length == 14)
            {
                return Convert.ToUInt64(cpfCnpj).ToString(@"00\.000\.000\/0000\-00");
            }
            else
            {
                return cpfCnpj;
            }
        }

        public static string RemoverAcentos(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public static string ApenasNumeros(string input)
        {
            StringBuilder numeros = new StringBuilder();

            foreach (char caractere in input)
            {
                if (char.IsDigit(caractere))
                {
                    numeros.Append(caractere);
                }
            }

            return numeros.ToString();
        }

        public static List<T> FiltrarLista<T>(List<T> lista, string[] campos, string valorFiltro)
        {
            if (campos == null || campos.Length == 0 || string.IsNullOrWhiteSpace(valorFiltro))
            {
                return lista;
            }

            List<T> resultado = lista.Where(item => CamposContemValor(item, campos, valorFiltro)).ToList();

            return resultado;
        }

        private static bool CamposContemValor<T>(T objeto, string[] caminhos, string valorFiltro)
        {
            foreach (string caminho in caminhos)
            {
                var propriedades = caminho.Split('.');
                object? valorPropriedade = objeto;

                foreach (var propriedadeNome in propriedades)
                {
                    if (valorPropriedade == null)
                    {
                        break;
                    }

                    var propriedade = valorPropriedade
                        .GetType()
                        .GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, propriedadeNome, StringComparison.OrdinalIgnoreCase));

                    if (propriedade != null)
                    {
                        valorPropriedade = propriedade.GetValue(valorPropriedade);
                    }
                    else
                    {
                        break;
                    }
                }

                if (valorPropriedade != null)
                {
                    if (valorPropriedade is string stringValue && stringValue.Contains(valorFiltro, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else if (valorPropriedade is DateTime dateTimeValue)
                    {
                        string valorDateTimeString = dateTimeValue.ToString("dd/MM/yyyy HH:mm:ss");
                        if (valorDateTimeString.Contains(valorFiltro))
                        {
                            return true;
                        }
                    }
                    else if (valorPropriedade is decimal decimalValue && decimalValue != 0)
                    {
                        string valorDecimalString = decimalValue.ToString(CultureInfo.InvariantCulture);
                        if (valorDecimalString.Contains(valorFiltro))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool IsCpfCnpjValido(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
            {
                return false;
            }

            cpfCnpj = ApenasNumeros(cpfCnpj);

            if (cpfCnpj.Length == 11)
            {
                return IsValidCPF(cpfCnpj);
            }
            else if (cpfCnpj.Length == 14)
            {
                return IsValidCNPJ(cpfCnpj);
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidCPF(string cpf)
        {
            cpf = cpf.Trim();

            if (cpf.Length != 11 || !ApenasDigitos(cpf) || TodosDigitosIguais(cpf))
                return false;

            int[] multiplicadores = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadores[i];

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            soma = 0;
            multiplicadores = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadores[i];

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return digitoVerificador1 == int.Parse(cpf[9].ToString()) && digitoVerificador2 == int.Parse(cpf[10].ToString());
        }

        public static bool IsValidCNPJ(string cnpj)
        {
            cnpj = cnpj.Trim();

            if (cnpj.Length != 14 || !ApenasDigitos(cnpj) || TodosDigitosIguais(cnpj))
                return false;

            int[] multiplicadores = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores[i];

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            soma = 0;
            multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores[i];

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return digitoVerificador1 == int.Parse(cnpj[12].ToString()) && digitoVerificador2 == int.Parse(cnpj[13].ToString());
        }

        private static bool ApenasDigitos(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private static bool TodosDigitosIguais(string input)
        {
            char firstChar = input[0];
            return input.All(c => c == firstChar);
        }

        public static string PegaTresPrimeirosDigitos(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 3)
                return input;

            return input.Substring(0, 3);
        }

        public static string PegaRestanteTresPrimeirosDigitos(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 3)
                return input;

            return input.Substring(3);
        }

        public static string PegaPrimeiraPalavra(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var quantidadePalavras = input.Split(' ');

            return quantidadePalavras.First();
        }

        public static string PegaRestantePrimeiraPalavra(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var quantidadePalavras = input.Split(' ');

            return input.Substring(quantidadePalavras.First().Length);
        }

    }
}

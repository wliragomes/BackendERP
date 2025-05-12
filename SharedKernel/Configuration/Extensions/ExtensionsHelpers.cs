using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.Utils.Constants;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedKernel.Configuration.Extensions
{
    public static class ExtensionsHelpers
    {
        public static bool HasProperty(this Type obj, PaginationRequest paginationRequest)
        {
            var entityFields = obj.GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();

            if ((!entityFields.Contains(paginationRequest.FilterBy) || !entityFields.Contains(paginationRequest.OrderBy)))
                throw new DomainException(ConstantPagination.ParametrosFiltroNaoEncontrados);

            return true;
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string CleanAndNormalize(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            var parts = name.Trim().Split().Where(part => !string.IsNullOrWhiteSpace(part));

            return string.Join(" ", parts);
        }

        public static bool SomenteNumeros(this string value)
        {
            return int.TryParse(value, out _);
        }

        public static bool NumericoOuNulo(this string value)
        {
            if (value == null)
                return true;
            else
                return int.TryParse(value, out _);
        }

        public static bool SomenteAlphaNumerico(this string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            var regex = new Regex(@"^[a-zA-Z0-9]*$");

            if (regex.IsMatch(code))
                return true;
            else
                return false;
        }

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            string normalizedString = text.Normalize(NormalizationForm.FormD);
            char[] removedChars = normalizedString
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(removedChars).Normalize(NormalizationForm.FormC).ToUpper();
        }
    }
}

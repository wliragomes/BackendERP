using FluentValidation.Results;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;

namespace SharedKernel.SharedObjects
{
    public class TesteResponse<T>
    {
        public int Index { get; private set; }
        public T? FormValues { get; private set; }
        public int StatusCode { get; private set; } = 201;
        public List<TesteErrors> Errors { get; private set; } = new List<TesteErrors>();

        [JsonConstructor]
        public TesteResponse(int index, T data)
        {
            Index = index;
            FormValues = data;
        }

        public TesteResponse(int index)
        {
            SetIndex(index);
        }

        public TesteResponse(int index, string field, string msg, string value, HttpStatusCode statusCode)
        {
            SetIndex(index);
            AddError(field, msg, value);
            SetStatusCode();
        }

        public TesteResponse(int index, string field, string msg, object value, HttpStatusCode statusCode)
        {
            SetIndex(index);
            AddError(field, msg, value);
            SetStatusCode();
        }

        public TesteResponse(ValidationResult validationResult)
        {
            AddErrors(validationResult);
            SetStatusCode();
        }

        public TesteResponse(int index, ValidationResult validationResult)
        {
            SetIndex(index);
            AddErrors(validationResult);
            SetStatusCode();
        }

        public TesteResponse(int index, T formValues, ValidationResult validationResult)
        {
            SetIndex(index);
            SetFormValues(formValues);
            AddErrors(validationResult);
            SetStatusCode();
        }

        public void AddErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var itemError = new TesteErrors(error.PropertyName, error.CustomState?.ToString() ?? error.AttemptedValue?.ToString() ?? "null", error.ErrorMessage);
                Errors.Add(itemError);
            }
            SetStatusCode();
        }

        public void AddError(string field, string msg, string value)
        {
            var itemError = new TesteErrors(field, value, msg);
            Errors.Add(itemError);
            SetStatusCode();
        }

        public void AddError(string field, string msg)
        {
            var itemError = new TesteErrors(field, msg);
            Errors.Add(itemError);
            SetStatusCode();
        }

        public void AddError(string field, string msg, object value)
        {
            var itemError = new TesteErrors(field, value, msg);
            Errors.Add(itemError);
            SetStatusCode();
        }

        public void SetStatusCode()
        {
            if (HasError())
                StatusCode = (int)HttpStatusCode.BadRequest;
            else
                StatusCode = (int)HttpStatusCode.Created;
        }

        public void ChangeStatusCode(int statusCode)
        {
            StatusCode = statusCode;
        }

        public void SetFormValues(T formValues)
        {
            FormValues = formValues;
        }

        public void SetIndex(int index)
        {
            Index = index;
        }

        public bool HasError() => Errors.Any();

        public bool NoExistError() => !Errors.Any();
    }

    public class TesteErrors
    {
        private string _propertyValue;

        public string PropertyName
        {
            get
            {
                return SetFirstLetterToLower(_propertyValue);
            }
            set
            {
                _propertyValue = value;
            }
        }

        public object PropertyValue { get; private set; }
        public string Message { get; private set; }

        [JsonConstructor]
        public TesteErrors(string propertyName, string propertyValue, string message)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Message = message;
        }

        public TesteErrors(string propertyName, object propertyValue, string message)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Message = message;
        }

        public TesteErrors(string propertyName, string message)
        {
            PropertyName = propertyName;
            PropertyValue = string.Empty;
            Message = message;
        }

        public void SetPropertyName(string propertyName)
        {
            PropertyName = propertyName;
        }

        public void SetPropertyValue(string propertyValue)
        {
            PropertyValue = propertyValue;
        }

        private string SetFirstLetterToLower(string valor)
        {
            return Regex.Replace(valor, @"\b[A-Z]", m => m.Value.ToLower());
        }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}

using System.Net;
using Newtonsoft.Json;
using FluentValidation.Results;

namespace SharedKernel.SharedObjects
{
    public class FormularioResponse<T>
    {
        public int Indice { get; private set; }
        public T? Formulario { get; private set; }
        public int StatusCode { get; private set; } = 201;
        public List<FormularioErros> Erros { get; private set; } = new List<FormularioErros>();

        [JsonConstructor]
        public FormularioResponse(int indice, T dado)
        {
            Indice = indice;
            Formulario = dado;
        }

        public FormularioResponse(int indice)
        {
            SetIndex(indice);
        }

        public FormularioResponse(int indice, string campo, string mensagem, string valor, HttpStatusCode statusCode)
        {
            SetIndex(indice);
            AddError(campo, mensagem, valor);
            SetStatusCode();
        }

        public FormularioResponse(int indice, string campo, string mensagem, object valor, HttpStatusCode statusCode)
        {
            SetIndex(indice);
            AddError(campo, mensagem, valor);
            SetStatusCode();
        }

        public FormularioResponse(ValidationResult validacaoResultado)
        {
            AddError(validacaoResultado);
            SetStatusCode();
        }

        public FormularioResponse(int indice, ValidationResult validacaoResultado)
        {
            SetIndex(indice);
            AddError(validacaoResultado);
            SetStatusCode();
        }

        public FormularioResponse(int indice, T formulario, ValidationResult validacaoResultado)
        {
            SetIndex(indice);
            SetFormulario(formulario);
            AddError(validacaoResultado);
            SetStatusCode();
        }

        public void AddError(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                var itemErro = new FormularioErros(erro.PropertyName, erro.CustomState?.ToString() ?? erro.AttemptedValue?.ToString() ?? "null", erro.ErrorMessage);
                Erros.Add(itemErro);
            }
            SetStatusCode();
        }

        public void AddError(string campo, string mensagem, string valor)
        {
            var itemErro = new FormularioErros(campo, valor, mensagem);
            Erros.Add(itemErro);
            SetStatusCode();
        }

        public void AddError(string campo, string mensagem)
        {
            var itemErro = new FormularioErros(campo, mensagem);
            Erros.Add(itemErro);
            SetStatusCode();
        }

        public void AddError(string campo, string mensagem, object valor)
        {
            var itemErro = new FormularioErros(campo, valor, mensagem);
            Erros.Add(itemErro);
            SetStatusCode();
        }

        public void SetStatusCode()
        {
            if (ExisteErro())
                StatusCode = (int)HttpStatusCode.BadRequest;
            else
                StatusCode = (int)HttpStatusCode.Created;
        }

        public void ChangeStatusCode(int statusCode)
        {
            StatusCode = statusCode;
        }

        public void SetFormulario(T formulario)
        {
            Formulario = formulario;
        }

        public void SetIndex(int indice)
        {
            Indice = indice;
        }

        public bool ExisteErro() => Erros.Any();

        public bool NaoExisteErro() => !Erros.Any();
    }
}

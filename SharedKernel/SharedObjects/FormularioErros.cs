using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SharedKernel.SharedObjects
{
    public class FormularioErros
    {
        private string _valorEnviado;

        public string NomePropriedade
        {
            get
            {
                return SetFirstLetterToLower(_valorEnviado);
            }
            set
            {
                _valorEnviado = value;
            }
        }

        public object ValorEnviado { get; private set; }
        public string Mensagem { get; private set; }

        [JsonConstructor]
        public FormularioErros(string nomePropriedade, string valorEnviado, string mensagem)
        {
            NomePropriedade = nomePropriedade;
            ValorEnviado = valorEnviado;
            Mensagem = mensagem;
        }

        public FormularioErros(string nomePropriedade, object valorEnviado, string mensagem)
        {
            NomePropriedade = nomePropriedade;
            ValorEnviado = valorEnviado;
            Mensagem = mensagem;
        }

        public FormularioErros(string nomePropriedade, string mensagem)
        {
            NomePropriedade = nomePropriedade;
            ValorEnviado = string.Empty;
            Mensagem = mensagem;
        }

        public void SetPropertyName(string nomePropriedade)
        {
            NomePropriedade = nomePropriedade;
        }

        public void SetPropertyValue(string valorEnviado)
        {
            ValorEnviado = valorEnviado;
        }

        private string SetFirstLetterToLower(string valor)
        {
            return Regex.Replace(valor, @"\b[A-Z]", m => m.Value.ToLower());
        }

        public void SetMessage(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}

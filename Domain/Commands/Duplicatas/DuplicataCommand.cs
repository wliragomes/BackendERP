using SharedKernel.MediatR;

namespace Domain.Commands.Duplicatas
{
    public abstract class DuplicataCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public bool Parcelado { get; set; }
        public string Numero { get; set; }
        public string Ano { get; set; }
        public decimal ValorTotal { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataEmissao { get; set; }
        public Guid IdSacado { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public Guid IdCidade { get; set; }
        public Guid IdEstado { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string CepCobranca { get; set; }
        public string EnderecoCobranca { get; set; }
        public Guid IdCidadeCobranca { get; set; }
        public Guid IdEstadoCobranca { get; set; }
        public string NumeroEnderecoCobranca { get; set; }
        public string ComplementoCobranca { get; set; }
        public string Observacao { get; set; }
        public int Parcela { get; set; }
        public decimal ValorDuplicata { get; set; }
        public string ValorDuplicataExtensao { get; set; }
        public DateTime DataVencimento { get; set; }

        public DuplicataCommand()
        {

        }

        public DuplicataCommand(Guid id, bool parcelado, string numero, string ano, decimal valorTotal, int qtdParcelas, DateTime dataEmissao,
                                  Guid idSacado, string cep, string endereco, Guid idCidade, Guid idEstado, string numeroEndereco, string complemento, 
                                  string cepCobranca, string enderecoCobranca, Guid idCidadeCobranca, Guid idEstadoCobranca, string numeroEnderecoCobranca, 
                                  string complementoCobranca, string observacao)
        {
            Id = id;
            Parcelado = parcelado;
            Numero = numero;
            Ano = ano;
            ValorTotal = valorTotal;
            QtdParcelas = qtdParcelas;
            DataEmissao = dataEmissao;
            IdSacado = idSacado;
            Cep = cep;
            Endereco = endereco;
            IdCidade = idCidade;
            IdEstado = idEstado;
            NumeroEndereco = numeroEndereco;
            Complemento = complemento;
            CepCobranca = cepCobranca;
            EnderecoCobranca = enderecoCobranca;
            IdCidadeCobranca = idCidadeCobranca;
            IdEstadoCobranca = idEstadoCobranca;
            NumeroEnderecoCobranca = numeroEnderecoCobranca;
            ComplementoCobranca = complementoCobranca;
            Observacao = observacao;            
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
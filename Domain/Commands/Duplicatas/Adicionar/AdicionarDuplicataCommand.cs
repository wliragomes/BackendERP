namespace Domain.Commands.Duplicatas.Adicionar
{
    public class AdicionarDuplicataCommand : DuplicataCommand<AdicionarDuplicataCommand>
    {
        public AdicionarDuplicataCommand()
        {

        }

        public AdicionarDuplicataCommand(Guid id, bool parcelado, string numero, string ano, decimal valorTotal, int qtdParcelas, DateTime dataEmissao,
                                  Guid idSacado, string cep, string endereco, Guid idCidade, Guid idEstado, string numeroEndereco, string complemento, 
                                  string cepCobranca, string enderecoCobranca, Guid idCidadeCobranca, Guid idEstadoCobranca, string numeroEnderecoCobranca, 
                                  string complementoCobranca, string observacao)
            : base(id, parcelado, numero, ano, valorTotal, qtdParcelas, dataEmissao, idSacado, cep, endereco, idCidade, idEstado, numeroEndereco, 
                   complemento, cepCobranca, enderecoCobranca, idCidadeCobranca, idEstadoCobranca, numeroEnderecoCobranca, complementoCobranca, observacao)
        {
        }
    }
}

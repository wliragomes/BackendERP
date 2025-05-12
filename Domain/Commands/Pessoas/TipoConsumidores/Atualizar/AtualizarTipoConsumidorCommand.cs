namespace Domain.Commands.Pessoas.TipoConsumidores.Atualizar
{
    public class AtualizarTipoConsumidorCommand : TipoConsumidorCommand<AtualizarTipoConsumidorCommand>
    {
        public AtualizarTipoConsumidorCommand(Guid id, string nome, string descricao, bool somaItens, bool somaDespesasBaseIcms, bool somaIpiBaseIcms,
                                              bool somaDespesasBaseSt, bool somaIpiBaseSt, bool somaStBaseIcms, bool difal, bool substituicaoIcms)
            : base(id, nome, descricao, somaItens, somaDespesasBaseIcms, somaIpiBaseIcms, somaDespesasBaseSt, somaIpiBaseSt, somaStBaseIcms, difal, substituicaoIcms)
        {
        }

        public AtualizarTipoConsumidorCommand()
        {

        }
    }
}

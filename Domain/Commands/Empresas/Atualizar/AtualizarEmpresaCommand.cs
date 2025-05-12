namespace Domain.Commands.Empresas.Atualizar
{
    public class AtualizarEmpresaCommand : EmpresaCommand<AtualizarEmpresaCommand>
    {
        public AtualizarEmpresaCommand(Guid id, string? cpfCnpj, string? inscricaoEstadual, string? inscricaoSuframa, string? razaoSocial, string? nomeFantasia,
                                       Guid? idRegimeTributario, Guid? idEndereco, Guid? idEmail, Guid? idTelefone)
            : base(id, cpfCnpj, inscricaoEstadual, inscricaoSuframa, razaoSocial, nomeFantasia, idRegimeTributario, idEndereco, idEmail, idTelefone)
        {
        }

        public AtualizarEmpresaCommand()
        {

        }
    }
}
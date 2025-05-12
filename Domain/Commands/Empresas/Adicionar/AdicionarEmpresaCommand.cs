namespace Domain.Commands.Empresas.Adicionar
{
    public class AdicionarEmpresaCommand : EmpresaCommand<AdicionarEmpresaCommand>
    {
        public AdicionarEmpresaCommand()
        {

        }

        public AdicionarEmpresaCommand(Guid id, string? cpfCnpj, string? inscricaoEstadual, string? inscricaoSuframa, string? razaoSocial, string? nomeFantasia,
                                       Guid? idRegimeTributario, Guid? idEndereco, Guid? idEmail, Guid? idTelefone)
            : base(id, cpfCnpj, inscricaoEstadual, inscricaoSuframa, razaoSocial, nomeFantasia, idRegimeTributario, idEndereco, idEmail, idTelefone)
        {
        }
    }
}
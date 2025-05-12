using SharedKernel.MediatR;

namespace Domain.Commands.Caminhoes
{
    public abstract class CaminhaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int CaminhaoCarreta { get; set; }
        public string Numero { get; set; }
        public string Placa { get; set; }
        public decimal Tara { get; set; }
        public decimal CapacidadeKg { get; set; }
        public decimal CapacidadeM3 { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid IdTipoRodado { get; set; }
        public Guid IdTipoCarroceria { get; set; }
        public Guid IdEstado { get; set; }
        public bool Inativo { get; set; }

        public CaminhaoCommand()
        {

        }

        public CaminhaoCommand(Guid id, string descricao, int caminhaoCarreta, string numero, string placa, decimal tara, decimal capacidadeKg, decimal capacidadeM3,
                               Guid idPessoa, Guid idTipoRodado, Guid idTipoCarroceria, Guid idEstado, bool inativo)
        {
            Id = id;
            Descricao = descricao;
            CaminhaoCarreta = caminhaoCarreta;
            Numero = numero;
            Placa = placa;
            Tara = tara;
            CapacidadeKg = capacidadeKg;
            CapacidadeM3 = capacidadeM3;
            IdPessoa = idPessoa;
            IdTipoRodado = idTipoRodado;
            IdTipoCarroceria = idTipoCarroceria;
            IdEstado = idEstado;
            Inativo = inativo;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
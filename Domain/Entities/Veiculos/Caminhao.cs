using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Caminhao : EntityIdDescricao
    {
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

        public Caminhao() { }

        public Caminhao(string descricao, int caminhaoCarreta, string numero, string placa, decimal tara, decimal capacidadeKg, decimal capacidadeM3,
                        Guid idPessoa, Guid idTipoRodado, Guid idTipoCarroceria, Guid idEstado, bool inativo)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
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

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao, int caminhaoCarreta, string numero, string placa, decimal tara, decimal capacidadeKg, decimal capacidadeM3,
                           Guid idPessoa, Guid idTipoRodado, Guid idTipoCarroceria, Guid idEstado, bool inativo)
        {
            SetDescricao(descricao);
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

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

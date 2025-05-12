using SharedKernel.MediatR;

namespace Domain.Commands.OrdensFabricacoes
{
    public  class OrdemFabricacaoItemCommand
    {
        public Guid Id { get; set; }
        public Guid IdOrdemFabricacao { get; set; }
        public int SqItem { get; set; }
        public int SqVendaItem { get; set; }
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal Espessura { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public int Quantidade { get; set; }
        public bool Aramado { get; set; }
        public bool Modelado { get; set; }
        public decimal ValorM2 { get; set; }
        public decimal ValorM { get; set; }
        public decimal ValorPeso { get; set; }
        public decimal ValorM2Real { get; set; }
        public decimal ValorMReal { get; set; }
        public decimal ValorPesoReal { get; set; }
        public decimal ValorAreaMinima { get; set; }
        public Guid IdSetorProduto { get; set; }
        public Guid IdProjeto { get; set; }
        public decimal AlturaLapidacao { get; set; }
        public decimal LarguraLapidacao { get; set; }
        public bool Manual { get; set; }
        public bool Cortado { get; set; }
        public bool Filete1 { get; set; }
        public bool Filete2 { get; set; }
        public bool Filete3 { get; set; }
        public bool Filete4 { get; set; }
        public bool Industrial1 { get; set; }
        public bool Industrial2 { get; set; }
        public bool Industrial3 { get; set; }
        public bool Industrial4 { get; set; }
        public bool Polida1 { get; set; }
        public bool Polida2 { get; set; }
        public bool Polida3 { get; set; }
        public bool Polida4 { get; set; }
        public bool QuebraCanto { get; set; }
        public bool Revenda { get; set; }
        public bool Instalacao { get; set; }
        public bool ManterEdgeDeletion { get; set; }
        public bool CancelarEdgeDeletion { get; set; }

        public OrdemFabricacaoItemCommand()
        {

        }

        public OrdemFabricacaoItemCommand(Guid Id, Guid idOrdemFabricacao, int sqItem, int sqVendaItem, Guid idProduto, string nomeProduto, string descricaoProduto, decimal espessura,
                                          decimal altura, decimal largura, int quantidade, bool aramado, bool modelado, decimal valorM2, decimal valorM, decimal valorPeso,
                                          decimal valorM2Real, decimal valorMReal, decimal valorPesoReal, decimal valorAreaMinima, Guid idSetorProduto, Guid idProjeto,
                                          decimal alturaLapidacao, decimal larguraLapidacao, bool manual, bool cortado, bool filete1, bool filete2, bool filete3, bool filete4,
                                          bool industrial1, bool industrial2, bool industrial3, bool industrial4, bool polida1, bool polida2, bool polida3, bool polida4,
                                          bool quebraCanto, bool revenda, bool instalacao, bool manterEdgeDeletion, bool cancelarEdgeDeletion)
        {
            IdOrdemFabricacao = idOrdemFabricacao;
            SqItem = sqItem;
            SqVendaItem = sqVendaItem;
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            Espessura = espessura;
            Altura = altura;
            Largura = largura;
            Quantidade = quantidade;
            Aramado = aramado;
            Modelado = modelado;
            ValorM2 = valorM2;
            ValorM = valorM;
            ValorPeso = valorPeso;
            ValorM2Real = valorM2Real;
            ValorMReal = valorMReal;
            ValorPesoReal = valorPesoReal;
            ValorAreaMinima = valorAreaMinima;
            IdSetorProduto = idSetorProduto;
            IdProjeto = idProjeto;
            AlturaLapidacao = alturaLapidacao;
            LarguraLapidacao = larguraLapidacao;
            Manual = manual;
            Cortado = cortado;
            Filete1 = filete1;
            Filete2 = filete2;
            Filete2 = filete3;
            Filete3 = filete4;
            Industrial1 = industrial1;
            Industrial2 = industrial2;
            Industrial3 = industrial3;
            Industrial4 = industrial4;
            Polida1 = polida1;
            Polida2 = polida2;  
            Polida3 = polida3;
            Polida4 = polida4;
            QuebraCanto = quebraCanto;
            Revenda = revenda;
            Instalacao = instalacao;
            ManterEdgeDeletion = manterEdgeDeletion;
            CancelarEdgeDeletion = cancelarEdgeDeletion;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
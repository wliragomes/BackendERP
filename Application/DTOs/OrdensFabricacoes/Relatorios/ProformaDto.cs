namespace Application.DTOs.OrdensFabricacoes.Relatorios
{
    public class ProformaDto
    {
        public Cliente Cliente { get; set; }
        public Endereco EnderecoCobranca { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public List<Produto> Produto { get; set; }
        public Proforma Proforma { get; set; }
        public Entrega Entrega { get; set; }
        public Totais Totais { get; set; }
    }

    public class Cliente
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Obra { get; set; }

    }

    public class Endereco
    {
        public Guid Id { get; set; }
        public Guid IdTipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Guid IdCidade { get; set; }
        public string Bairro { get; set; }
        public Guid IdUf { get; set; }
        public string Cep { get; set; }
    }

    public class Produto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Un { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string ValorIpi { get; set; }
        public string SubTotal { get; set; }
    }

    public class Proforma
    {
        public string Numero { get; set; }
        public string Pedido { get; set; }
        public string Of { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }

    public class Entrega
    {
        public string RazaoSocial { get; set; }
        public string PrevisaoEntrega { get; set; }
    }

    public class Totais
    {
        public string Produto { get; set; }
        public string Ipi { get; set; }
        public string OutrasDespesas { get; set; }
        public string ValorTotal { get; set; }
    }
}

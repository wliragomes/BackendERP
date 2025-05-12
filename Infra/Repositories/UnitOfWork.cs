using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
       
        private UserRepository? _userRepository;
        private FunctionUserRepository? _functionUserRepository;
        private CidadeRepository? _cidadeRepository;
        private EstadoRepository? _estadoRepository;
        private PaisRepository? _paisRepository;
        private BancoRepository? _bancoRepository;
        private TipoConsumidorRepository? _tipoconsumidorRepository;
        private CstIcmsRepository? _cst_icmsRepository;
        private CstIpiRepository? _cst_ipiRepository;        
        private FeriadoRepository? _feriadoRepository;
        private CentroCustoRepository? _centroCustoRepository;
        private CstIcmsOrigemMaterialRepository? _cst_icms_origem_materialRepository;
        private PessoaRepository? _pessoaRepository;
        private EnderecoRepository? _enderecoRepository;
        private TelefoneRepository? _telefoneRepository;
        private EmailRepository? _emailRepository;
        private ContatoRepository? _contatoRepository;
        private DadosCobrancaRepository? _dadosCobrancaRepository;
        private AnaliseCreditoRepository? _analiseCreditoRepository;
        private RelacionaPessoaEnderecoRepository? _relacionaPessoaEnderecoRepository;
        private RelacionaPessoaTelefoneRepository? _relacionaPessoaTelefoneRepository;
        private RelacionaPessoaEmailRepository? _relacionaPessoaEmailRepository;
        private RelacionaPessoaContatoEnderecoRepository? _relacionaPessoaContatoEnderecoRepository;
        private RelacionaPessoaContatoTelefoneRepository? _relacionaPessoaContatoTelefoneRepository;
        private RelacionaDadosCobrancaEnderecoRepository? _relacionaDadosCobrancaEnderecoRepository;
        private RelacionaDadosCobrancaTelefoneRepository? _relacionaDadosCobrancaTelefoneRepository;
        private RelacionaUsuarioFuncionalidadeNivelAcessoRepository? _relacionaUsuarioFuncionalidadeNivelRepositoryRepository;
        private RegiaoRepository? _regiaoRepository;
        private CargoRepository? _cargoRepository;
        private DepartamentoRepository? _departamentoRepository;
        private OrigemRepository? _origemRepository;
        private SegmentoClienteRepository? _segmentoClienteRepository;
        private SegmentoEstrategicoRepository? _segmentoEstrategicoRepository;
        private ProdutoRepository? _produtoRepository;
        private UnidadeMedidaRepository? _unidadeMedidaRepository;
        private SetorProdutoRepository? _setorProdutoRepository;
        private TipoProdutoRepository? _tipoProdutoRepository;
        private VendaRepository? _vendaRepository;
        private ImpressaoEspecialRepository? _impressaoEspecialRepository;
        private VendaOrdemParceiroRepository? _vendaOrdemParceiroRepository;
        private VendaItemRepository? _vendaItemRepository;
        private RelacionaFaturaVendaRecebimentoTipoRepository? _relacionaFaturaVendaRecebimentoTipoRepository;
        private GrupoRepository? _grupoRepository;
        private CodigoImportacaoRepository? _codigoimportacaoRepository;
        private SetorRepository? _setorRepository;
        private RuaRepository? _ruaRepository;
        private SubgrupoRepository? _subgrupoRepository;
        private PrateleiraRepository? _prateleiraRepository;
        private NcmRepository? _ncmRepository;
        private FamiliaRepository? _familiaRepository;
        private TipoPrecoRepository? _tipoprecoRepository;
        private OrigemMaterialRepository? _origemmaterialRepository;
        private FaturaRepository? _faturaRepository;
        private FaturaItemRepository? _faturaItemRepository;
        private CfopRepository? _cfopRepository;
        private FuncionalidadeRepository? _funcionalidadeRepository;
        private NivelAcessoRepository? _nivelacessoRepository;
        private PrecoTributacaoRepository? _precoTributacaoRepository;
        private ComposicaoRepository? _composicaoRepository;
        private RelacionaFuncionalidadeNivelAcessoRepository? _relacionaFuncionalidadeNivelAcessoRepository;
        private ClasseReajusteRepository? _classeReajusteRepository;
        private DesgastePolimentoRepository _desgastePolimentoRepository;
        private RelacionaProdutoFornecedorRepository _relacionaProdutoFornecedorRepository;
        private NormaAbntRepository _normaAbntRepository;
        private TipoFreteRepository _tipofreteRepository;
        private VendaRecebimentoParcelaRepository _vendaRecebimentoParcelaRepository;
        private VendaRecebimentoTipoRepository _vendaRecebimentoTipoRepository;
        private PisRepository _pisRepository;
        private CofinsRepository _cofinsRepository;
        private EmpresaRepository _empresaRepository;
        private RegimeTributarioRepository _regimeTributarioRepository;
        private FaturaParametroRepository _faturaParametroRepository;
        private ModalidadeRepository _modalidadeRepository;
        private AcabamentoRepository _acabamentoRepository;
        private CodigoDDIRepository _codigoDDIRepository;
        private MoedaRepository _moedaRepository;
        private ProjetoRepository _projetoRepository;
        private MotivoReposicaoRepository _motivoReposicaoRepository;
        private MotivoCancelamentoRepository _motivoCancelamentoRepository;
        private ObraFaseRepository _obraFaseRepository;
        private ObraOrigemRepository _obraOrigemRepository;
        private ObraPadraoRepository _obraPadraoRepository;
        private ObraProjetoRepository _obraProjetoRepository;
        private ParametroRepository _parametroRepository;
        private MedidaJumboRepository _medidaJumboRepository;
        private ClassificacaoRepository _classificacaoRepository;
        private DespesaRepository _despesaRepository;
        private OperacaoRepository _operacaoRepository;
        private ContaAPagarRepository _contaAPagarRepository;
        private PagarCentroCustoDespesaRepository _pagarCentroCustoDespesaRepository;
        private ContaPagarLoteRepository _contaPagarLoteRepository;
        private ContaPagarLoteItemRepository _contaPagarLoteItemRepository;
        private CartaoRepository _cartaoRepository;
        private ContaAPagarPagoRepository _contaAPagarPagoRepository;
        private CaminhaoRepository _caminhaoRepository;
        private TipoCarroceriaRepository _tipoCarroceriaRepository;
        private TipoRodadoRepository _tipoRodadoRepository;
        private FusoHorarioRepository _fusoHorarioRepository;
        private CepBloqueadoRepository _cepBloqueadoRepository;
        private ChapaRepository _chapaRepository;
        private ContaBancariaRepository _contaBancariaRepository;
        private MovimentoEstoqueRepository _movimentoEstoqueRepository;
        private MinimoCobrancaRepository _minimoCobrancaRepository;
        private MinimoCobrancaItemRepository _minimoCobrancaItemRepository;
        private RepresentanteRepository _representanteRepository;
        private ContaAReceberRepository _contaAReceberRepository;
        private FluxoCaixaRepository _fluxoCaixaRepository;
        private DuplicataRepository _duplicataRepository;
        private DuplicataParcelaRepository _duplicataParcelaRepository;
        private OrdemFabricacaoRepository _ordemFabricacaoRepository;
        private OrdemFabricacaoItemRepository _ordemFabricacaoItemRepository;
        private RomaneioRepository _romaneioRepository;
        private RomaneioItemRepository _romaneioItemRepository;
        private ComissaoRepository _comissaoRepository;
        private MedidaParametroRepository _medidaParametroRepository;
        private OrdemFabricacaoItemTemporariaRepository _ordemFabricacaoItemTemporariaRepository;
        private PlanoDeContasRepository _planoDeContasRepository;
        private FaturaTemporariaRepository _faturaTemporariaRepository;
        private FaturaTemporariaItemRepository _faturaTemporariaItemRepository;
        private DashBoardRepository _dashBoardRepository;
        private RelacionaEmpresaSocioRepository _relacionaEmpresaSocioRepository;
        private RelacionaEmpresaFaturaParametroRepository _relacionaEmpresaFaturaParametroRepository;
        private PlanejamentoProducaoRepository _planejamentoProducaoRepository;
        private ContaAReceberPagoRepository _contaAReceberPagoRepository;

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public ITipoProdutoRepository TipoProdutoRepository
        {
            get
            {
                return _tipoProdutoRepository = _tipoProdutoRepository ?? new TipoProdutoRepository(_context);
            }
        }

        public ISetorProdutoRepository SetorProdutoRepository
        {
            get
            {
                return _setorProdutoRepository = _setorProdutoRepository ?? new SetorProdutoRepository(_context);
            }
        }

        public IUnidadeMedidaRepository UnidadeMedidaRepository
        {
            get
            {
                return _unidadeMedidaRepository = _unidadeMedidaRepository ?? new UnidadeMedidaRepository(_context);
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICidadeRepository CidadeRepository
        {
            get
            {
                return _cidadeRepository = _cidadeRepository ?? new CidadeRepository(_context);
            }
        }

        public IEstadoRepository EstadoRepository
        {
            get
            {
                return _estadoRepository = _estadoRepository ?? new EstadoRepository(_context);
            }
        }

        public IPaisRepository PaisRepository
        {
            get
            {
                return _paisRepository = _paisRepository ?? new PaisRepository(_context);
            }
        }

        public IBancoRepository BancoRepository
        {
            get
            {
                return _bancoRepository = _bancoRepository ?? new BancoRepository(_context);
            }
        }
        public ITipoConsumidorRepository TipoConsumidorRepository
        {
            get
            {
                return _tipoconsumidorRepository = _tipoconsumidorRepository ?? new TipoConsumidorRepository(_context);
            }
        }
        public ICstIcmsRepository CST_ICMSRepository
        {
            get
            {
                return _cst_icmsRepository = _cst_icmsRepository ?? new CstIcmsRepository(_context);
            }
        }
        public ICstIpiRepository CST_IPIRepository
        {
            get
            {
                return _cst_ipiRepository = _cst_ipiRepository ?? new CstIpiRepository(_context);
            }
        }        
        public IFeriadoRepository FeriadoRepository
        {
            get
            {
                return _feriadoRepository = _feriadoRepository ?? new FeriadoRepository(_context);
            }
        }
        public ICentroCustoRepository CentroCustoRepository
        {
            get
            {
                return _centroCustoRepository = _centroCustoRepository ?? new CentroCustoRepository(_context);
            }
        }
        public ICstIcmsOrigemMaterialRepository CST_ICMS_Origem_MaterialRepository
        {
            get
            {
                return _cst_icms_origem_materialRepository = _cst_icms_origem_materialRepository ?? new CstIcmsOrigemMaterialRepository(_context);
            }
        }


        public IPessoaRepository PessoaRepository
        {
            get
            {
                return _pessoaRepository = _pessoaRepository ?? new PessoaRepository(_context);
            }
        }

        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                return _enderecoRepository = _enderecoRepository ?? new EnderecoRepository(_context);
            }
        }

        public ITelefoneRepository TelefoneRepository
        {
            get
            {
                return _telefoneRepository = _telefoneRepository ?? new TelefoneRepository(_context);
            }
        }

        public IEmailRepository EmailRepository
        {
            get
            {
                return _emailRepository = _emailRepository ?? new EmailRepository(_context);
            }
        }

        public IContatoRepository ContatoRepository
        {
            get
            {
                return _contatoRepository = _contatoRepository ?? new ContatoRepository(_context);
            }
        }

        public IDadosCobrancaRepository DadosCobrancaRepository
        {
            get
            {
                return _dadosCobrancaRepository = _dadosCobrancaRepository ?? new DadosCobrancaRepository(_context);
            }
        }

        public IAnaliseCreditoRepository AnaliseCreditoRepository
        {
            get
            {
                return _analiseCreditoRepository = _analiseCreditoRepository ?? new AnaliseCreditoRepository(_context);
            }
        }

        public IRelacionaPessoaEnderecoRepository RelacionaPessoaEnderecoRepository
        {
            get
            {
                return _relacionaPessoaEnderecoRepository = _relacionaPessoaEnderecoRepository ?? new RelacionaPessoaEnderecoRepository(_context);
            }
        }

        public IRelacionaPessoaTelefoneRepository RelacionaPessoaTelefoneRepository
        {
            get
            {
                return _relacionaPessoaTelefoneRepository = _relacionaPessoaTelefoneRepository ?? new RelacionaPessoaTelefoneRepository(_context);
            }
        }

        public IRelacionaPessoaEmailRepository RelacionaPessoaEmailRepository
        {
            get
            {
                return _relacionaPessoaEmailRepository = _relacionaPessoaEmailRepository ?? new RelacionaPessoaEmailRepository(_context);
            }
        }

        public IRelacionaPessoaContatoEnderecoRepository RelacionaPessoaContatoEnderecoRepository
        {
            get
            {
                return _relacionaPessoaContatoEnderecoRepository = _relacionaPessoaContatoEnderecoRepository ?? new RelacionaPessoaContatoEnderecoRepository(_context);
            }
        }

        public IRelacionaPessoaContatoTelefoneRepository RelacionaPessoaContatoTelefoneRepository
        {
            get
            {
                return _relacionaPessoaContatoTelefoneRepository = _relacionaPessoaContatoTelefoneRepository ?? new RelacionaPessoaContatoTelefoneRepository(_context);
            }
        }

        public IRelacionaDadosCobrancaEnderecoRepository RelacionaDadosCobrancaEnderecoRepository
        {
            get
            {
                return _relacionaDadosCobrancaEnderecoRepository = _relacionaDadosCobrancaEnderecoRepository ?? new RelacionaDadosCobrancaEnderecoRepository(_context);
            }
        }

        public IRelacionaDadosCobrancaTelefoneRepository RelacionaDadosCobrancaTelefoneRepository
        {
            get
            {
                return _relacionaDadosCobrancaTelefoneRepository = _relacionaDadosCobrancaTelefoneRepository ?? new RelacionaDadosCobrancaTelefoneRepository(_context);
            }
        }

        public IRegiaoRepository RegiaoRepository
        {
            get
            {
                return _regiaoRepository = _regiaoRepository ?? new RegiaoRepository(_context);
            }
        }
        public ICargoRepository CargoRepository
        {
            get
            {
                return _cargoRepository = _cargoRepository ?? new CargoRepository(_context);
            }
        }
        public IDepartamentoRepository DepartamentoRepository
        {
            get
            {
                return _departamentoRepository = _departamentoRepository ?? new DepartamentoRepository(_context);
            }
        }

        public IOrigemRepository OrigemRepository
        {
            get
            {
                return _origemRepository = _origemRepository ?? new OrigemRepository(_context);
            }
        }

        public ISegmentoClienteRepository SegmentoClienteRepository
        {
            get
            {
                return _segmentoClienteRepository = _segmentoClienteRepository ?? new SegmentoClienteRepository(_context);
            }
        }

        public ISegmentoEstrategicoRepository SegmentoEstrategicoRepository
        {
            get
            {
                return _segmentoEstrategicoRepository = _segmentoEstrategicoRepository ?? new SegmentoEstrategicoRepository(_context);
            }
        }

        public IFunctionUserRepository FunctionUserRepository
        {
            get
            {
                return _functionUserRepository = _functionUserRepository ?? new FunctionUserRepository(_context);
            }
        }

        public IGrupoRepository GrupoRepository
        {
            get
            {
                return _grupoRepository = _grupoRepository ?? new GrupoRepository(_context);
            }
        }

        public ICodigoImportacaoRepository CodigoImportacaoRepository
        {
            get
            {
                return _codigoimportacaoRepository = _codigoimportacaoRepository ?? new CodigoImportacaoRepository(_context);
            }
        }

        public ISetorRepository SetorRepository
        {
            get
            {
                return _setorRepository = _setorRepository ?? new SetorRepository(_context);
            }
        }

        public IRuaRepository RuaRepository
        {
            get
            {
                return _ruaRepository = _ruaRepository ?? new RuaRepository(_context);
            }
        }

        public IFaturaRepository FaturaRepository
        {
            get
            {
                return _faturaRepository = _faturaRepository ?? new FaturaRepository(_context);
            }
        }

        public IFaturaItemRepository FaturaItemRepository
        {
            get
            {
                return _faturaItemRepository = _faturaItemRepository ?? new FaturaItemRepository(_context);
            }
        }

        public ICfopRepository CfopRepository
        {
            get
            {
                return _cfopRepository = _cfopRepository ?? new CfopRepository(_context);
            }
        }

        public ISubgrupoRepository SubgrupoRepository
        {
            get
            {
                return _subgrupoRepository = _subgrupoRepository ?? new SubgrupoRepository(_context);
            }
        }

        public IPrateleiraRepository PrateleiraRepository
        {
            get
            {
                return _prateleiraRepository = _prateleiraRepository ?? new PrateleiraRepository(_context);
            }
        }

        public INcmRepository NcmRepository
        {
            get
            {
                return _ncmRepository = _ncmRepository ?? new NcmRepository(_context);
            }
        }

        public IFamiliaRepository FamiliaRepository
        {
            get
            {
                return _familiaRepository = _familiaRepository ?? new FamiliaRepository(_context);
            }
        }

        public IOrigemMaterialRepository OrigemMaterialRepository
        {
            get
            {
                return _origemmaterialRepository = _origemmaterialRepository ?? new OrigemMaterialRepository(_context);
            }
        }

        public ITipoPrecoRepository TipoPrecoRepository
        {
            get
            {
                return _tipoprecoRepository = _tipoprecoRepository ?? new TipoPrecoRepository(_context);
            }
        }

        public IFuncionalidadeRepository FuncionalidadeRepository
        {
            get
            {
                return _funcionalidadeRepository = _funcionalidadeRepository ?? new FuncionalidadeRepository(_context);
            }
        }

        public INivelAcessoRepository NivelAcessoRepository
        {
            get
            {
                return _nivelacessoRepository = _nivelacessoRepository ?? new NivelAcessoRepository(_context);
            }
        }

        public IRelacionaUsuarioFuncionalidadeNivelAcessoRepository RelacionaUsuarioFuncionalidadeNivelAcessoRepository
        {
            get
            {
                return _relacionaUsuarioFuncionalidadeNivelRepositoryRepository = _relacionaUsuarioFuncionalidadeNivelRepositoryRepository ?? new RelacionaUsuarioFuncionalidadeNivelAcessoRepository(_context);
            }
        }

        public IPrecoTributacaoRepository PrecoTributacaoRepository
        {
            get
            {
                return _precoTributacaoRepository = _precoTributacaoRepository ?? new PrecoTributacaoRepository(_context);
            }
        }

        public IComposicaoRepository ComposicaoRepository
        {
            get
            {
                return _composicaoRepository = _composicaoRepository ?? new ComposicaoRepository(_context);
            }

        } public IRelacionaFuncionalidadeNivelAcessoRepository RelacionaFuncionalidadeNivelAcessoRepository
        {
            get
            {
                return _relacionaFuncionalidadeNivelAcessoRepository = _relacionaFuncionalidadeNivelAcessoRepository ?? new RelacionaFuncionalidadeNivelAcessoRepository(_context);
            }
        }

        public IVendaRepository VendaRepository
        {
            get
            {
                return _vendaRepository = _vendaRepository ?? new VendaRepository(_context);
            }
        }

        public IImpressaoEspecialRepository ImpressaoEspecialRepository
        {
            get
            {
                return _impressaoEspecialRepository = _impressaoEspecialRepository ?? new ImpressaoEspecialRepository(_context);
            }
        }

        public IVendaOrdemParceiroRepository VendaOrdemParceiroRepository
        {
            get
            {
                return _vendaOrdemParceiroRepository = _vendaOrdemParceiroRepository ?? new VendaOrdemParceiroRepository(_context);
            }
        }

        public IVendaItemRepository VendaItemRepository
        {
            get
            {
                return _vendaItemRepository = _vendaItemRepository ?? new VendaItemRepository(_context);
            }
        }

        public IRelacionaFaturaVendaRecebimentoTipoRepository RelacionaFaturaVendaRecebimentoTipoRepository
        {
            get
            {
                return _relacionaFaturaVendaRecebimentoTipoRepository = _relacionaFaturaVendaRecebimentoTipoRepository ?? new RelacionaFaturaVendaRecebimentoTipoRepository(_context);
            }
        }

        public IClasseReajusteRepository ClasseReajusteRepository
        {
            get
            {
                return _classeReajusteRepository = _classeReajusteRepository ?? new ClasseReajusteRepository(_context);
            }
        }

        public IDesgastePolimentoRepository DesgastePolimentoRepository
        {
            get
            {
                return _desgastePolimentoRepository = _desgastePolimentoRepository ?? new DesgastePolimentoRepository(_context);
            }
        }
        
        public IRelacionaProdutoFornecedorRepository RelacionaProdutoFornecedorRepository
        {
            get
            {
                return _relacionaProdutoFornecedorRepository = _relacionaProdutoFornecedorRepository ?? new RelacionaProdutoFornecedorRepository(_context);
            }
        }

        public INormaAbntRepository NormaAbntRepository
        {
            get
            {
                return _normaAbntRepository = _normaAbntRepository ?? new NormaAbntRepository(_context);
            }
        }

        public ITipoFreteRepository TipoFreteRepository
        {
            get
            {
                return _tipofreteRepository = _tipofreteRepository ?? new TipoFreteRepository(_context);
            }
        }

        public IVendaRecebimentoParcelaRepository VendaRecebimentoParcelaRepository
        {
            get
            {
                return _vendaRecebimentoParcelaRepository = _vendaRecebimentoParcelaRepository ?? new VendaRecebimentoParcelaRepository(_context);
            }
        }

        public IVendaRecebimentoTipoRepository VendaRecebimentoTipoRepository
        {
            get
            {
                return _vendaRecebimentoTipoRepository = _vendaRecebimentoTipoRepository ?? new VendaRecebimentoTipoRepository(_context);
            }
        }

        public IPisRepository PisRepository
        {
            get
            {
                return _pisRepository = _pisRepository ?? new PisRepository(_context);
            }
        }

        public ICofinsRepository CofinsRepository
        {
            get
            {
                return _cofinsRepository = _cofinsRepository ?? new CofinsRepository(_context);
            }
        }

        public IEmpresaRepository EmpresaRepository
        {
            get
            {
                return _empresaRepository = _empresaRepository ?? new EmpresaRepository(_context);
            }
        }

        public IRegimeTributarioRepository RegimeTributarioRepository
        {
            get
            {
                return _regimeTributarioRepository = _regimeTributarioRepository ?? new RegimeTributarioRepository(_context);
            }
        }

        public IFaturaParametroRepository FaturaParametroRepository
        {
            get
            {
                return _faturaParametroRepository = _faturaParametroRepository ?? new FaturaParametroRepository(_context);
            }
        }

        public IModalidadeRepository ModalidadeRepository
        {
            get
            {
                return _modalidadeRepository = _modalidadeRepository ?? new ModalidadeRepository(_context);
            }
        }

        public IAcabamentoRepository AcabamentoRepository
        {
            get
            {
                return _acabamentoRepository = _acabamentoRepository ?? new AcabamentoRepository(_context);
            }
        }

        public ICodigoDDIRepository CodigoDDIRepository
        {
            get
            {
                return _codigoDDIRepository = _codigoDDIRepository ?? new CodigoDDIRepository(_context);
            }
        }

        public IMoedaRepository MoedaRepository
        {
            get
            {
                return _moedaRepository = _moedaRepository ?? new MoedaRepository(_context);
            }
        }

        public IProjetoRepository ProjetoRepository
        {
            get
            {
                return _projetoRepository = _projetoRepository ?? new ProjetoRepository(_context);
            }
        }

        public IMotivoReposicaoRepository MotivoReposicaoRepository
        {
            get
            {
                return _motivoReposicaoRepository = _motivoReposicaoRepository ?? new MotivoReposicaoRepository(_context);
            }
        }

        public IMotivoCancelamentoRepository MotivoCancelamentoRepository
        {
            get
            {
                return _motivoCancelamentoRepository = _motivoCancelamentoRepository ?? new MotivoCancelamentoRepository(_context);
            }
        }

        public IObraFaseRepository ObraFaseRepository
        {
            get
            {
                return _obraFaseRepository = _obraFaseRepository ?? new ObraFaseRepository(_context);
            }
        }

        public IObraOrigemRepository ObraOrigemRepository
        {
            get
            {
                return _obraOrigemRepository = _obraOrigemRepository ?? new ObraOrigemRepository(_context);
            }
        }

        public IObraPadraoRepository ObraPadraoRepository
        {
            get
            {
                return _obraPadraoRepository = _obraPadraoRepository ?? new ObraPadraoRepository(_context);
            }
        }

        public IObraProjetoRepository ObraProjetoRepository
        {
            get
            {
                return _obraProjetoRepository = _obraProjetoRepository ?? new ObraProjetoRepository(_context);
            }
        }

        public IParametroRepository ParametroRepository
        {
            get
            {
                return _parametroRepository = _parametroRepository ?? new ParametroRepository(_context);
            }
        }

        public IMedidaJumboRepository MedidaJumboRepository
        {
            get
            {
                return _medidaJumboRepository = _medidaJumboRepository ?? new MedidaJumboRepository(_context);
            }
        }

        public IClassificacaoRepository ClassificacaoRepository
        {
            get
            {
                return _classificacaoRepository = _classificacaoRepository ?? new ClassificacaoRepository(_context);
            }
        }

        public IDespesaRepository DespesaRepository
        {
            get
            {
                return _despesaRepository = _despesaRepository ?? new DespesaRepository(_context);
            }
        }

        public IOperacaoRepository OperacaoRepository
        {
            get
            {
                return _operacaoRepository = _operacaoRepository ?? new OperacaoRepository(_context);
            }
        }

        public IContaAPagarRepository ContaAPagarRepository
        {
            get
            {
                return _contaAPagarRepository = _contaAPagarRepository ?? new ContaAPagarRepository(_context);
            }
        }

        public IPagarCentroCustoDespesaRepository PagarCentroCustoDespesaRepository
        {
            get
            {
                return _pagarCentroCustoDespesaRepository = _pagarCentroCustoDespesaRepository ?? new PagarCentroCustoDespesaRepository(_context);
            }
        }

        public IContaPagarLoteRepository ContaPagarLoteRepository
        {
            get
            {
                return _contaPagarLoteRepository = _contaPagarLoteRepository ?? new ContaPagarLoteRepository(_context);
            }
        }

        public IContaPagarLoteItemRepository ContaPagarLoteItemRepository
        {
            get
            {
                return _contaPagarLoteItemRepository = _contaPagarLoteItemRepository ?? new ContaPagarLoteItemRepository(_context);
            }
        }

        public ICartaoRepository CartaoRepository
        {
            get
            {
                return _cartaoRepository = _cartaoRepository ?? new CartaoRepository(_context);
            }
        }

        public IContaAPagarPagoRepository ContaAPagarPagoRepository
        {
            get
            {
                return _contaAPagarPagoRepository = _contaAPagarPagoRepository ?? new ContaAPagarPagoRepository(_context);
            }
        }

        public ICaminhaoRepository CaminhaoRepository
        {
            get
            {
                return _caminhaoRepository = _caminhaoRepository ?? new CaminhaoRepository(_context);
            }
        }

        public ITipoCarroceriaRepository TipoCarroceriaRepository
        {
            get
            {
                return _tipoCarroceriaRepository = _tipoCarroceriaRepository ?? new TipoCarroceriaRepository(_context);
            }
        }

        public ITipoRodadoRepository TipoRodadoRepository
        {
            get
            {
                return _tipoRodadoRepository = _tipoRodadoRepository ?? new TipoRodadoRepository(_context);
            }
        }

        public IFusoHorarioRepository FusoHorarioRepository
        {
            get
            {
                return _fusoHorarioRepository = _fusoHorarioRepository ?? new FusoHorarioRepository(_context);
            }
        }

        public ICepBloqueadoRepository CepBloqueadoRepository
        {
            get
            {
                return _cepBloqueadoRepository = _cepBloqueadoRepository ?? new CepBloqueadoRepository(_context);
            }
        }

        public IChapaRepository ChapaRepository
        {
            get
            {
                return _chapaRepository = _chapaRepository ?? new ChapaRepository(_context);
            }
        }

        public IContaBancariaRepository ContaBancariaRepository
        {
            get
            {
                return _contaBancariaRepository = _contaBancariaRepository ?? new ContaBancariaRepository(_context);
            }
        }

        public IMovimentoEstoqueRepository MovimentoEstoqueRepository
        {
            get
            {
                return _movimentoEstoqueRepository = _movimentoEstoqueRepository ?? new MovimentoEstoqueRepository(_context);
            }
        }

        public IMinimoCobrancaRepository MinimoCobrancaRepository
        {
            get
            {
                return _minimoCobrancaRepository = _minimoCobrancaRepository ?? new MinimoCobrancaRepository(_context);
            }
        }

        public IMinimoCobrancaItemRepository MinimoCobrancaItemRepository
        {
            get
            {
                return _minimoCobrancaItemRepository = _minimoCobrancaItemRepository ?? new MinimoCobrancaItemRepository(_context);
            }
        }

        public IRepresentanteRepository RepresentanteRepository
        {
            get
            {
                return _representanteRepository = _representanteRepository ?? new RepresentanteRepository(_context);
            }
        }

        public IContaAReceberRepository ContaAReceberRepository
        {
            get
            {
                return _contaAReceberRepository = _contaAReceberRepository ?? new ContaAReceberRepository(_context);
            }
        }

        public IFluxoCaixaRepository FluxoCaixaRepository
        {
            get
            {
                return _fluxoCaixaRepository = _fluxoCaixaRepository ?? new FluxoCaixaRepository(_context);
            }
        }

        public IDuplicataRepository DuplicataRepository
        {
            get
            {
                return _duplicataRepository = _duplicataRepository ?? new DuplicataRepository(_context);
            }
        }

        public IDuplicataParcelaRepository DuplicataParcelaRepository
        {
            get
            {
                return _duplicataParcelaRepository = _duplicataParcelaRepository ?? new DuplicataParcelaRepository(_context);
            }
        }

        public IOrdemFabricacaoRepository OrdemFabricacaoRepository
        {
            get
            {
                return _ordemFabricacaoRepository = _ordemFabricacaoRepository ?? new OrdemFabricacaoRepository(_context);
            }
        }

        public IOrdemFabricacaoItemRepository OrdemFabricacaoItemRepository
        {
            get
            {
                return _ordemFabricacaoItemRepository = _ordemFabricacaoItemRepository ?? new OrdemFabricacaoItemRepository(_context);
            }
        }

        public IRomaneioRepository RomaneioRepository
        {
            get
            {
                return _romaneioRepository = _romaneioRepository ?? new RomaneioRepository(_context);
            }
        }

        public IRomaneioItemRepository RomaneioItemRepository
        {
            get
            {
                return _romaneioItemRepository = _romaneioItemRepository ?? new RomaneioItemRepository(_context);
            }
        }

        public IComissaoRepository ComissaoRepository
        {
            get
            {
                return _comissaoRepository = _comissaoRepository ?? new ComissaoRepository(_context);
            }
        }

        public IMedidaParametroRepository MedidaParametroRepository
        {
            get
            {
                return _medidaParametroRepository = _medidaParametroRepository ?? new MedidaParametroRepository(_context);
            }
        }

        public IOrdemFabricacaoItemTemporariaRepository OrdemFabricacaoItemTemporariaRepository
        {
            get
            {
                return _ordemFabricacaoItemTemporariaRepository = _ordemFabricacaoItemTemporariaRepository ?? new OrdemFabricacaoItemTemporariaRepository(_context);
            }
        }

        public IPlanoDeContasRepository PlanoDeContasRepository
        {
            get
            {
                return _planoDeContasRepository = _planoDeContasRepository ?? new PlanoDeContasRepository(_context);
            }
        }

        public IFaturaTemporariaRepository FaturaTemporariaRepository
        {
            get
            {
                return _faturaTemporariaRepository = _faturaTemporariaRepository ?? new FaturaTemporariaRepository(_context);
            }
        }

        public IFaturaTemporariaItemRepository FaturaTemporariaItemRepository
        {
            get
            {
                return _faturaTemporariaItemRepository = _faturaTemporariaItemRepository ?? new FaturaTemporariaItemRepository(_context);
            }
        }

        public IDashBoardRepository DashBoardRepository
        {
            get
            {
                return _dashBoardRepository = _dashBoardRepository ?? new DashBoardRepository(_context);
            }
        }

        public IRelacionaEmpresaSocioRepository RelacionaEmpresaSocioRepository
        {
            get
            {
                return _relacionaEmpresaSocioRepository = _relacionaEmpresaSocioRepository ?? new RelacionaEmpresaSocioRepository(_context);
            }
        }

        public IRelacionaEmpresaFaturaParametroRepository RelacionaEmpresaFaturaParametroRepository
        {
            get
            {
                return _relacionaEmpresaFaturaParametroRepository = _relacionaEmpresaFaturaParametroRepository ?? new RelacionaEmpresaFaturaParametroRepository(_context);
            }
        }  

        public IPlanejamentoProducaoRepository PlanejamentoProducaoRepository
        {
            get
            {
                return _planejamentoProducaoRepository = _planejamentoProducaoRepository ?? new PlanejamentoProducaoRepository(_context);
            }
        }   

        public IContaAReceberPagoRepository ContaAReceberPagoRepository
        {
            get
            {
                return _contaAReceberPagoRepository = _contaAReceberPagoRepository ?? new ContaAReceberPagoRepository(_context);
            }
        }       

        void IUnitOfWork.Commit()
        {
            _context.SaveChanges();
        }

        bool IUnitOfWork.NewCommit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken)
        {
            await _context.Database.ExecuteSqlRawAsync(sql, cancellationToken);
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

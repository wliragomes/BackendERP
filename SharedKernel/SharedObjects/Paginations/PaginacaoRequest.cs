using SharedKernel.Utils;
using SharedKernel.Utils.Constants;

namespace SharedKernel.SharedObjects.Paginations
{
    public class PaginacaoRequest
    {
        private int _numeroPagina;
        private int _tamanhoPagina;
        private string? _ids { get; set; }
        private string? _filtrarPor { get; set; }
        private string? _direcaoOrdenacao { get; set; }
        private string? _ordenarPor { get; set; }
        private string? _valorFiltro { get; set; }
        private string? _tipoSelecao { get; set; }

        public int? NumeroPagina
        {
            get { return _numeroPagina <= 0 ? SetAndReturnPageNumberDefaultValue() : _numeroPagina; }
            set => _numeroPagina = value ?? SetAndReturnPageNumberDefaultValue();
        }

        public int? TamanhoPagina
        {
            get { return _tamanhoPagina > ValoresPadroesPaginacao.TamanhoPaginaLimite ? SetAndReturnPageNumberDefaultValue() : _tamanhoPagina; }
            set => _tamanhoPagina = value ?? SetAndReturnPageNumberDefaultValue();
        }

        public string? FiltrarPor
        {
            get { return _filtrarPor; }
            set => _filtrarPor = value ?? SetAndReturnFilterByDefaultValue();
        }

        public string? Ids
        {
            get { return _ids; }
            set => _ids = value ?? "";
        }

        public string? DirecaoOrdenacao
        {
            get { return _direcaoOrdenacao!.ToLower(); }
            set
            {
                _direcaoOrdenacao = value ?? SetAndReturnDirectionDefaultValue();
                ValidateDirection();
            }
        }

        public string? OrdenarPor
        {
            get { return _ordenarPor!.ToLower(); }
            set => _ordenarPor = value ?? SetAndReturnOrderByDefaultValue();
        }

        public string? ValorFiltro
        {
            get { return _valorFiltro; }
            set
            {
                _valorFiltro = value ?? SetAndReturnFilterValueDefaultValue();
            }
        }

        public string? TipoSelecao
        {
            get { return _tipoSelecao!.ToLower(); }
            set
            {
                _tipoSelecao = value ?? SetAndReturnSelectionTypeDefaultValue();
                ValidateSelectionType();
            }
        }

        public PaginacaoRequest()
        {
            SetAndReturnPageNumberDefaultValue();
            SetAndReturnPageSizeDefaultValue();
            SetAndReturnFilterByDefaultValue();
            SetAndReturnDirectionDefaultValue();
            SetAndReturnOrderByDefaultValue();
            SetAndReturnFilterValueDefaultValue();
            SetAndReturnIdListDefaultValue();
            SetAndReturnSelectionTypeDefaultValue();
        }

        public PaginacaoRequest(int? pagina, int? tamanhoPagina, string? filtroPor, string? orientacao, string? ordenacaoPor, string? filtroValor, string? selecaoTipo)
        {
            _numeroPagina = pagina ?? SetAndReturnPageNumberDefaultValue();
            _tamanhoPagina = tamanhoPagina ?? SetAndReturnPageSizeDefaultValue();
            _filtrarPor = filtroPor ?? SetAndReturnFilterByDefaultValue();
            _direcaoOrdenacao = orientacao ?? SetAndReturnDirectionDefaultValue();
            _ordenarPor = ordenacaoPor ?? SetAndReturnOrderByDefaultValue();
            _valorFiltro = filtroValor ?? SetAndReturnFilterValueDefaultValue();
            _tipoSelecao = selecaoTipo ?? SetAndReturnSelectionTypeDefaultValue();
            ValidateDirection();
        }

        private int SetAndReturnPageNumberDefaultValue()
        {
            return _numeroPagina = ValoresPadroesPaginacao.NumeroPaginaPadrao;
        }

        private int SetAndReturnPageSizeDefaultValue()
        {
            return _tamanhoPagina = ValoresPadroesPaginacao.TamanhoPaginaPadrao;
        }

        private string SetAndReturnFilterByDefaultValue()
        {
            return _filtrarPor = ValoresPadroesPaginacao.FiltroPorPadrao;
        }

        private string SetAndReturnDirectionDefaultValue()
        {
            return _direcaoOrdenacao = ValoresPadroesPaginacao.DirecaoPadrao;
        }

        private string SetAndReturnOrderByDefaultValue()
        {
            return _ordenarPor = ValoresPadroesPaginacao.OrdenarPorPadrao;
        }

        private string SetAndReturnFilterValueDefaultValue()
        {
            return _valorFiltro = ValoresPadroesPaginacao.ValorFiltroPadrao;
        }

        private string SetAndReturnSelectionTypeDefaultValue()
        {
            return _tipoSelecao = ValoresPadroesPaginacao.TipoSelecaopadrao;
        }

        public int? ReturnSkip()
        {
            return _numeroPagina == 1 ? 0 : _numeroPagina > 1 ? (_numeroPagina - 1) * TamanhoPagina : SetAndReturnPageNumberDefaultValue();
        }

        private string SetAndReturnIdListDefaultValue()
        {
            return _ids = "";
        }

        private void ValidateDirection()
        {
            if (DirecaoOrdenacao != PaginacaoConstants.OrientacaoDesc && DirecaoOrdenacao != PaginacaoConstants.OrientacaoAsc)
            {
                throw new DomainException("Direction precisa ser 'Asc' ou 'Desc'");
            }
        }

        private void ValidateSelectionType()
        {
            if (TipoSelecao != PaginacaoConstants.SelecaoTipoTodos &&
                TipoSelecao != PaginacaoConstants.SelecaoTipoNenhum &&
                TipoSelecao != PaginacaoConstants.SelecaoTipoSelecionado &&
                TipoSelecao != PaginacaoConstants.SelecaoTipoExcecao)
            {
                throw new DomainException("TipoSelecao precisa ser 'Todos' ou 'vazio' ou 'Selecionado' ou 'Exceção'");
            }
        }
    }
}

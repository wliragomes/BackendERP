using SharedKernel.Configuration.Extensions;
using SharedKernel.Utils.Constants;

namespace SharedKernel.SharedObjects
{
    public class FiltroBase
    {
        private string? _filtrarPor;
        private string? _valorFiltro;
        private List<Guid>? _idsSelecionados;
        private List<Guid>? _IdsNaoSelecionados;

        public string? FiltrarPor
        {
            get => _filtrarPor;
            set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                    _filtrarPor = null;
                else
                    _filtrarPor = value.ToLower().CleanAndNormalize();
            }
        }

        public string? ValorFiltro
        {
            get => _valorFiltro;
            set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                    _valorFiltro = null;
                else
                    _valorFiltro = value.ToLower().CleanAndNormalize();
            }
        }

        public List<Guid>? IdsSelecionados
        {
            get
            {
                if (IdsNotNullAndNotEmpty())
                {
                    throw new DomainException(ConstantGeneral.SELECTED_AND_NOT_SELECTED_IDS);
                }
                return _idsSelecionados;
            }
            set
            {
                if (value is null)
                    new List<Guid>();
                else
                    _idsSelecionados = value;
            }
        }

        public List<Guid>? IdsNaoSelecionados
        {
            get
            {
                if (IdsNotNullAndNotEmpty())
                {
                    throw new DomainException(ConstantGeneral.SELECTED_AND_NOT_SELECTED_IDS);
                }
                return _IdsNaoSelecionados;
            }
            set
            {
                if (value is null)
                    new List<Guid>();
                else
                    _IdsNaoSelecionados = value;
            }
        }

        private bool IdsNotNullAndNotEmpty() => (_idsSelecionados is not null && _IdsNaoSelecionados is not null) && _idsSelecionados!.Any() && _IdsNaoSelecionados!.Any();

        private bool IdsAreNull() => _idsSelecionados is null && _IdsNaoSelecionados is null;

        private bool FiltersAreNull() => FiltrarPor is null && ValorFiltro is null;

        public bool PropriedadesValoresNulos() => IdsAreNull() && FiltersAreNull();
    }
}

using SharedKernel.Configuration.Extensions;
using SharedKernel.Utils.Constants;

namespace SharedKernel.SharedObjects
{
    public class FilterBulkBase
    {
        private string? _filterBy;
        private string? _filterValue;
        private List<Guid>? _selectedIds;
        private List<Guid>? _notSelectedIds;

        public string? FilterBy
        {
            get => _filterBy;
            set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                    _filterBy = null;
                else
                    _filterBy = value.ToLower().CleanAndNormalize();
            }
        }

        public string? FilterValue
        {
            get => _filterValue;
            set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                    _filterValue = null;
                else
                    _filterValue = value.ToLower().CleanAndNormalize();
            }
        }

        public List<Guid>? SelectedIds
        {
            get
            {
                if (IdsNotNullAndNotEmpty())
                {
                    throw new DomainException(ConstantGeneral.SELECTED_AND_NOT_SELECTED_IDS);
                }
                return _selectedIds;
            }
            set
            {
                if (value is null)
                    new List<Guid>();
                else
                    _selectedIds = value;
            }
        }

        public List<Guid>? NotSelectedIds
        {
            get
            {
                if (IdsNotNullAndNotEmpty())
                {
                    throw new DomainException(ConstantGeneral.SELECTED_AND_NOT_SELECTED_IDS);
                }
                return _notSelectedIds;
            }
            set
            {
                if (value is null)
                    new List<Guid>();
                else
                    _notSelectedIds = value;
            }
        }

        private bool IdsNotNullAndNotEmpty() => (_selectedIds is not null && _notSelectedIds is not null) && _selectedIds!.Any() && _notSelectedIds!.Any();

        private bool IdsAreNull() => _selectedIds is null && _notSelectedIds is null;

        private bool FiltersAreNull() => FilterBy is null && FilterValue is null;

        public bool PropertiesValuesAreNull() => IdsAreNull() && FiltersAreNull();
    }
}

using SharedKernel.Utils;
using SharedKernel.Utils.Constants;

namespace SharedKernel.SharedObjects.Paginations
{
    public class PaginationRequest
    {
        private int _pageNumber;
        private int _pageSize;
        private string? _idList { get; set; }
        private string? _filterBy { get; set; }
        private string? _direction { get; set; }
        private string? _orderBy { get; set; }
        private string? _filterValue { get; set; }
        private string? _selectionType { get; set; }

        public int? PageNumber
        {
            get { return _pageNumber <= 0 ? SetAndReturnPageNumberDefaultValue() : _pageNumber; }
            set => _pageNumber = value ?? SetAndReturnPageNumberDefaultValue();
        }

        public int? PageSize
        {
            get { return _pageSize > DefaultValuesPagination.PageSizelimit ? SetAndReturnPageSizeDefaultValue() : _pageSize; }
            set => _pageSize = value ?? SetAndReturnPageSizeDefaultValue();
        }

        public string? FilterBy
        {
            get { return _filterBy; }
            set => _filterBy = value ?? SetAndReturnFilterByDefaultValue();
        }

        public string? IdList
        {
            get { return _idList; }
            set => _idList = value ?? "";
        }

        public string? Direction
        {
            get { return _direction!.ToLower(); }
            set
            {
                _direction = value ?? SetAndReturnDirectionDefaultValue();
                ValidateDirection();
            }
        }

        public string? OrderBy
        {
            get { return _orderBy!.ToLower(); }
            set => _orderBy = value ?? SetAndReturnOrderByDefaultValue();
        }

        public string? FilterValue
        {
            get { return _filterValue; }
            set
            {
                _filterValue = value ?? SetAndReturnFilterValueDefaultValue();
            }
        }

        public string? SelectionType
        {
            get { return _selectionType!.ToLower(); }
            set
            {
                _selectionType = value ?? SetAndReturnSelectionTypeDefaultValue();
                ValidateSelectionType();
            }
        }

        public PaginationRequest()
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

        public PaginationRequest(int? pageNumber, int? pageSize, string? filterBy, string? direction, string? orderBy, string? filterValue, string? selectionType)
        {
            _pageNumber = pageNumber ?? SetAndReturnPageNumberDefaultValue();
            _pageSize = pageSize ?? SetAndReturnPageSizeDefaultValue();
            _filterBy = filterBy ?? SetAndReturnFilterByDefaultValue();
            _direction = direction ?? SetAndReturnDirectionDefaultValue();
            _orderBy = orderBy ?? SetAndReturnOrderByDefaultValue();
            _filterValue = filterValue ?? SetAndReturnFilterValueDefaultValue();
            _selectionType = selectionType ?? SetAndReturnSelectionTypeDefaultValue();
            ValidateDirection();
        }

        private int SetAndReturnPageNumberDefaultValue()
        {
            return _pageNumber = DefaultValuesPagination.DefaultPageNumber;
        }

        private int SetAndReturnPageSizeDefaultValue()
        {
            return _pageSize = DefaultValuesPagination.DefaultPageSize;
        }

        private string SetAndReturnFilterByDefaultValue()
        {
            return _filterBy = DefaultValuesPagination.DefaultFilterBy;
        }

        private string SetAndReturnDirectionDefaultValue()
        {
            return _direction = DefaultValuesPagination.DefaultDirection;
        }

        private string SetAndReturnOrderByDefaultValue()
        {
            return _orderBy = DefaultValuesPagination.DefaultOrderBy;
        }

        private string SetAndReturnFilterValueDefaultValue()
        {
            return _filterValue = DefaultValuesPagination.DefaultFilterValue;
        }

        private string SetAndReturnSelectionTypeDefaultValue()
        {
            return _selectionType = DefaultValuesPagination.DefaultSelectionTypeValue;
        }

        public int? ReturnSkip()
        {
            return _pageNumber == 1 ? 0 : _pageNumber > 1 ? (_pageNumber - 1) * PageSize : SetAndReturnPageNumberDefaultValue();
        }

        private string SetAndReturnIdListDefaultValue()
        {
            return _idList = "";
        }

        private void ValidateDirection()
        {
            if (Direction != ConstantPagination.DirectionDesc && Direction != ConstantPagination.DirectionAsc)
            {
                throw new DomainException("Direction precisa ser 'Asc' ou 'Desc'");
            }
        }

        private void ValidateSelectionType()
        {
            if (SelectionType != ConstantPagination.SelectionTypeAll &&
                SelectionType != ConstantPagination.SelectionTypeNone &&
                SelectionType != ConstantPagination.SelectionTypeSelected &&
                SelectionType != ConstantPagination.SelectionTypeException)
            {
                throw new DomainException("SelectionType precisa ser 'All' ou 'None' ou 'Selected' ou 'Exception'");
            }
        }
    }
}

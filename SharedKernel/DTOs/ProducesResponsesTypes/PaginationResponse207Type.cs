using SharedKernel.SharedObjects.Paginations;
using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class PaginationResponse207Type<T>
    {
        public PaginationResponseList<T>? Data { get; set; }

        [DefaultValue(null)]
        public Metadata? Meta { get; set; }

        [DefaultValue(207)]
        public int StatusCode { get; set; }
    }
}

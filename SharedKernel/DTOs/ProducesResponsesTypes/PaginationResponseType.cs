using SharedKernel.SharedObjects.Paginations;
using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class PaginationResponseType<T>
    {
        public PaginationResponseList<T>? Data { get; set; }

        [DefaultValue(null)]
        public Metadata? Meta { get; set; }

        [DefaultValue(200)]
        public int StatusCode { get; set; }
    }
}

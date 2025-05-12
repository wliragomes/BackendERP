using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error400OKType<T>
    {
        [DefaultValue(0)]
        public int Index { get; set; }

        [DefaultValue(null)]
        public T? FormValues { get; set; }

        [DefaultValue(400)]
        public string? StatusCode { get; set; }

        public ErrorListType[]? Errors { get; set; }
    }
}

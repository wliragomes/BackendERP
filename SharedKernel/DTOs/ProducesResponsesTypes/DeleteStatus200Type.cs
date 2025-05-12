using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class DeleteStatus200Type
    {
        [DefaultValue(0)]
        public int Index { get; set; }

        [DefaultValue(null)]
        public string? FormValues { get; set; }

        [DefaultValue(200)]
        public string? StatusCode { get; set; }

        public EmptyArray? Errors { get; set; }
    }
}

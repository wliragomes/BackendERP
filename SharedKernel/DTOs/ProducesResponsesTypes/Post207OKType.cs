using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Post207OKType<T>
    {
        [DefaultValue(0)]
        public int Index { get; set; }

        public T? FormValues { get; set; }

        [DefaultValue(207)]
        public string? StatusCode { get; set; }

        public EmptyArray? Errors { get; set; }
    }
}

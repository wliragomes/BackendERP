using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Post206OKType<T>
    {
        [DefaultValue(0)]
        public int Index { get; set; }

        public T? FormValues { get; set; }

        [DefaultValue(206)]
        public string? StatusCode { get; set; }

        public EmptyArray? Errors { get; set; }
    }
}

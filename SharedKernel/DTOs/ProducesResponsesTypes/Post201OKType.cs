using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Post201OKType<T>
    {
        [DefaultValue(0)]
        public int Index { get; set; }

        public T? FormValues { get; set; }

        [DefaultValue(201)]
        public string? StatusCode { get; set; }

        public EmptyArray? Errors { get; set; }
    }
}

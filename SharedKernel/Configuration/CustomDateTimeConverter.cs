using System.Text.Json.Serialization;
using System.Text.Json;

namespace SharedKernel.Configuration
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateTimeString = reader.GetString();

            if (string.IsNullOrWhiteSpace(dateTimeString))
            {
                return DateTime.MinValue;
            }

            var offset = DateTimeOffset.Parse(dateTimeString);

            return offset.DateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Utc));
        }
    }
}

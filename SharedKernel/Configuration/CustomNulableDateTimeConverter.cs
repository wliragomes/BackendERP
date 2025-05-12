using System.Text.Json.Serialization;
using System.Text.Json;

namespace SharedKernel.Configuration
{
    public class CustomNulableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateTimeString = reader.GetString();

            if (string.IsNullOrWhiteSpace(dateTimeString))
            {
                return null;
            }

            var offset = DateTimeOffset.Parse(dateTimeString);

            return offset.DateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(DateTime.SpecifyKind(value.Value, DateTimeKind.Utc));
        }
    }
}

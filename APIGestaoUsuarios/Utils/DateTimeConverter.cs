using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIGestaoUsuarios.Utils
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrEmpty(value))
                throw new JsonException("Data inválida ou nula no JSON.");

            if (DateTime.TryParse(value, out var date))
                return date;

            throw new JsonException($"Formato de data inválido: {value}");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}

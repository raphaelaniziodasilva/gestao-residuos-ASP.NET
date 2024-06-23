using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace gestao_residuos_ASP.NET.Converters
{
    public class BrazilianDateConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParseExact(reader.GetString(), _format, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            throw new JsonException($"Não foi possível converter \"{reader.GetString()}\" para DateTime usando formato {_format}.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}

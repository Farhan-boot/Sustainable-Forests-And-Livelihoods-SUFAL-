using System.Text.Json;
using System.Text.Json.Serialization;

namespace PTSL.GENERIC.Api.Helpers.JsonConverters;

public class NumberToStringConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}

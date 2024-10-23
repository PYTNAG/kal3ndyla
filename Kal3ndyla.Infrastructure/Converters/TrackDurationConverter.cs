using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Kal3ndyla.Infrastructure.Converters;

public partial class TrackDurationConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(TimeSpan))
        {
            throw new ArgumentOutOfRangeException(nameof(typeToConvert));
        }

        var timeSpanString = reader.GetString() ?? throw new NullReferenceException("Track duration can't be null");

        if (!TrackDurationRegex().IsMatch(timeSpanString))
        {
            throw new ArgumentException("Wrong track duration format. Use [H...:]MM:SS");
        }
        
        var tokens = timeSpanString.Split(":").Reverse().ToArray();

        var seconds = int.Parse(tokens[0]);
        var minutes = int.Parse(tokens[1]);

        var hours = 0;
        if (tokens.Length == 3)
        {
            hours = int.Parse(tokens[2]);
        }

        return new TimeSpan(hours, minutes, seconds);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    
    [GeneratedRegex(@"(\d*:)?\d{2}:\d{2}")]
    private static partial Regex TrackDurationRegex();
}
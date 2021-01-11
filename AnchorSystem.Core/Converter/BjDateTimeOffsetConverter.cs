using Newtonsoft.Json;
using System;
using TimeZoneConverter;

namespace AnchorSystem.Core.Converter
{
    /// <summary>
    /// DateTimeOffset转换为北京时间
    /// </summary>
    public class BjDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, DateTimeOffset value, JsonSerializer serializer)
        {
            var mdZone = TZConvert.GetTimeZoneInfo("Asia/Shanghai");
            value = TimeZoneInfo.ConvertTime(value, mdZone);
            writer.WriteValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override DateTimeOffset ReadJson(JsonReader reader, Type objectType, DateTimeOffset existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// DateTimeOffset转换为北京时间
    /// </summary>
    public class BjDateTimeOffsetNullConverter : JsonConverter<DateTimeOffset?>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, DateTimeOffset? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("");
            }
            else
            {
                var mdZone = TZConvert.GetTimeZoneInfo("Asia/Shanghai");
                value = TimeZoneInfo.ConvertTime(value.Value, mdZone);
                writer.WriteValue(value.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

        }

        public override DateTimeOffset? ReadJson(JsonReader reader, Type objectType, DateTimeOffset? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

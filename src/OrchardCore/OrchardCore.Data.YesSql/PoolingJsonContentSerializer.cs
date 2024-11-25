using System;
using Newtonsoft.Json;
using YesSql;

namespace OrchardCore.Data
{
    /// <summary>
    /// Custom YesSql content serializer which uses Newtonsoft.Json for serialization.
    /// </summary>
    internal sealed class PoolingJsonContentSerializer : IContentSerializer
    {
        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            CheckAdditionalContent = false
        };

        public object Deserialize(string content, Type type) => JsonConvert.DeserializeObject(content, type, _jsonSettings);

        public dynamic DeserializeDynamic(string content) => JsonConvert.DeserializeObject<dynamic>(content, _jsonSettings);

        public string Serialize(object item) => JsonConvert.SerializeObject(item, _jsonSettings);
    }
}
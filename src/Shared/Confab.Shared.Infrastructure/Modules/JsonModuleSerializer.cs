using System;
using System.Text;
using System.Text.Json;

namespace Confab.Shared.Infrastructure.Modules
{
    internal sealed class JsonModuleSerializer : IModuleSerializer
    {
        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public T Deserialize<T>(byte[] value)
            => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(value), _serializerOptions);

        public object Deserialize(byte[] value, Type type)
            => JsonSerializer.Deserialize(Encoding.UTF8.GetString(value), type, _serializerOptions);

        public byte[] Serialize<T>(T value)
            => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _serializerOptions));
    }
}
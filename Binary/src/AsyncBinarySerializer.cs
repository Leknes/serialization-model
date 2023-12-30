using MemoryPack;

namespace Senkel.Serialization.Binary;

public class AsyncBinarySerializer : IAsyncMarshal<Stream>
{
    public readonly MemoryPackSerializerOptions? Options;

    public AsyncBinarySerializer(MemoryPackSerializerOptions? options = null)
    {
        Options = options;
    }
 
    public ValueTask MarshalAsync(Stream stream, object? value, CancellationToken cancellationToken = default)
    {
        try
        {
            return MemoryPackSerializer.SerializeAsync(stream, value, Options, cancellationToken);
        }
        catch(MemoryPackSerializationException exception)
        {
            throw new SerializationException($"Async binary serialization of value '{value}' failed.", exception);
        }
    }
}
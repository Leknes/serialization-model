using MemoryPack;

namespace Senkel.Serialization.Binary;

public sealed class AsyncBinaryDeserializer : IAsyncDeserializer<Stream>
{
    public readonly MemoryPackSerializerOptions? Options;

    public AsyncBinaryDeserializer(MemoryPackSerializerOptions? options = null)
    {
        Options = options;
    }

    private SerializationException GetSerializationException(Type type, MemoryPackSerializationException exception)
    {
        return new SerializationException($"Async binary deserialization to type {type} failed.", exception);
    }

    public ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default)
    {
        try
        { 
            return MemoryPackSerializer.DeserializeAsync(type, stream, Options, cancellationToken);
        }
        catch (MemoryPackSerializationException exception)
        {
            throw GetSerializationException(type, exception);
        }
    }

    public ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default)
    { 
        try
        {
            return MemoryPackSerializer.DeserializeAsync<T>( stream, Options, cancellationToken);
        }
        catch (MemoryPackSerializationException exception)
        {
            throw GetSerializationException(typeof(T), exception);
        }
    }


}


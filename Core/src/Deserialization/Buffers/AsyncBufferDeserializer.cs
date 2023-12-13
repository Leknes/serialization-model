namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous deserializer capable of deserializing buffers which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that can be deserialized.</typeparam>
public interface IAsyncBufferDeserializer<T>
{
    /// <summary>
    /// Deserializes an object asynchronously based on the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to use for deserialization.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);
}
  
/// <summary>
/// Represents an asynchronous deserializer capable of deserializing buffers.
/// </summary>
public interface IAsyncBufferDeserializer
{
    /// <summary>
    /// Deserializes an object asynchronously based on the specified buffer.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="buffer">The buffer to use for deserialization.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync<T>(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deserializes an object asynchronously based on the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to use for deserialization.</param>
    /// <param name="type">The type to deserialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<object?> DeserializeAsync(ReadOnlyMemory<byte> buffer, Type type, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a deserializer class that can be used to treat a non-generic <see cref="IAsyncBufferDeserializer"/> like the <see cref="IAsyncBufferDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class AsyncBufferDeserializer<T> : IAsyncBufferDeserializer<T>
{
    private readonly IAsyncBufferDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="AsyncBufferDeserializer{T}"/> that wraps around the given <see cref="IAsyncBufferDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public AsyncBufferDeserializer(IAsyncBufferDeserializer deserializer)
    { 
        _deserializer = deserializer;
    }

    public ValueTask<T?> DeserializeAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return _deserializer.DeserializeAsync<T>(buffer, cancellationToken);
    }
}

/// <summary>
/// Represents an asynchronous deserializer class capable of deserializing streams and buffers.
/// </summary> 
public abstract class AsyncDeserializer : AsyncStreamDeserializer, IAsyncBufferDeserializer
{
    public virtual async ValueTask<T?> DeserializeAsync<T>(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default)
    {
        return (T?)await DeserializeAsync(buffer, typeof(T), cancellationToken);
    }

    public abstract ValueTask<object?> DeserializeAsync(ReadOnlyMemory<byte> buffer, Type type, CancellationToken cancellationToken = default);
     
}


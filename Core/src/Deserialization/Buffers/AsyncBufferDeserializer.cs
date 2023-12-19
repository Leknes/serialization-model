namespace Senkel.Serialization;
 
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


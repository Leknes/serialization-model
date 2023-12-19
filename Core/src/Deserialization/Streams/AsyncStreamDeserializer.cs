namespace Senkel.Serialization;
 
/// <summary>
/// Represents an asynchronous deserializer capable of deserializing streams.
/// </summary> 
public interface IAsyncStreamDeserializer
{
    /// <summary>
    /// Deserializes an object asynchronously based on the specified stream.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The stream to use for deserialization.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default);


    /// <summary>
    /// Deserializes an object asynchronously based on the specified stream.
    /// </summary>
    /// <param name="stream">The stream to use for deserialization.</param>
    /// <param name="type">The type to deserialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default);
}
 

/// <summary>
/// Represents an asynchronous deserializer class capable of deserializing streams.
/// </summary> 
public abstract class AsyncStreamDeserializer : IAsyncStreamDeserializer
{
    public virtual async ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default)
    {
        return (T?)await DeserializeAsync(stream, typeof(T), cancellationToken);
    }

    public abstract ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default);
}

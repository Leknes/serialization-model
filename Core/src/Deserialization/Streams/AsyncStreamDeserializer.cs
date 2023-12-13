namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous deserializer capable of deserializing streams which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that can be deserialized.</typeparam>
public interface IAsyncStreamDeserializer<T>
{
    /// <summary>
    /// Deserializes an object asynchronously based on the specified stream.
    /// </summary>
    /// <param name="stream">The stream to use for deserialization.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default);
}

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
/// Represents a deserializer class that can be used to treat a non-generic <see cref="IAsyncStreamDeserializer"/> like the <see cref="IAsyncStreamDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class AsyncStreamDeserializer<T> : IAsyncStreamDeserializer<T>
{
    private readonly IAsyncStreamDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="AsyncStreamDeserializer{T}"/> that wraps around the given <see cref="IAsyncStreamDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public AsyncStreamDeserializer(IAsyncStreamDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public ValueTask<T?> DeserializeAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        return _deserializer.DeserializeAsync<T>(stream, cancellationToken);
    }
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

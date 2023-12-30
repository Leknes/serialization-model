namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous deserializer that is capable of deserializing objects from a source of the type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the objects that can be deserialized.</typeparam>
public interface IAsyncDeserializer<in T>
{
    /// <summary>
    /// Deserializes an object of the specified type from the given source asynchronously.
    /// </summary>
    /// <param name="source">The source to deserialize from.</param>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<object?> DeserializeAsync(T source, Type type, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deserializes an object of the specified type from the given source asynchronously.
    /// </summary>
    /// <param name="source">The source to deserialize from.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <typeparam name="U">The type of the object to deserialize.</typeparam>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<U?> DeserializeAsync<U>(T source, CancellationToken cancellationToken = default);
}

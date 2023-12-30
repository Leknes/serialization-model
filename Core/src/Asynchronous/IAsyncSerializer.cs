namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous serializer that is capable of serializing to objects of the specified type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type that objects can be serialized to.</typeparam>
public interface IAsyncSerializer<T>
{
    /// <summary>
    /// Serializes the specified object to an instance of the type <typeparamref name="T"/> asynchronously.
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the serialized object.</returns>
    public ValueTask<T> SerializeAsync(object? value, CancellationToken cancellationToken = default);
}
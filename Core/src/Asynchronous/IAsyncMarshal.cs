namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous serializer that is capable of serializing an object and marshalling the serialized data to a destination of the type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of destination that serialized data can be marshalled to.</typeparam>
public interface IAsyncMarshal<in T>
{
    /// <summary>
    /// Serializes the specified object and marshals the serialized data to the given destination asynchronously.
    /// </summary>
    /// <param name="destination">The destination to marshal to.</param>
    /// <param name="value">The object to serialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>The task of the marshalling.</returns>
    public ValueTask MarshalAsync(T destination, object? value, CancellationToken cancellationToken = default);
}
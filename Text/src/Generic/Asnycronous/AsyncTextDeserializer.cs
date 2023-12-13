namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an asynchronous deserializer that is capable of deserializing text to the specified type.
/// </summary>
public interface IAsyncTextDeserializer<T>
{
    /// <summary>
    /// Deserializes the given text to an object of the specified type asynchronously.
    /// </summary> 
    /// <param name="text">The text containing the serialization data.</param> 
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync(string text, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a deserializer class that can be used to treat a non-generic <see cref="IAsyncTextDeserializer"/> like the <see cref="IAsyncTextDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class AsyncTextDeserializer<T> : IAsyncTextDeserializer<T>
{
    private readonly IAsyncTextDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="AsyncTextDeserializer{T}"/> that wraps around the given <see cref="IAsyncTextDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public AsyncTextDeserializer(IAsyncTextDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public ValueTask<T?> DeserializeAsync(string text, CancellationToken cancellationToken = default)
    {
        return _deserializer.DeserializeAsync<T>(text, cancellationToken);
    }
}

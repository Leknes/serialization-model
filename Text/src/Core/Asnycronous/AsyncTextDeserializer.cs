namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an asynchronous deserializer that is capable of deserializing text.
/// </summary>
public interface IAsyncTextDeserializer
{
    /// <summary>
    /// Deserializes the given text to an object of the specified type asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="text">The text containing the serialization data.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<T?> DeserializeAsync<T>(string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deserializes the given text to an object of the specified type asynchronously.
    /// </summary>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <param name="text">The text containing the serialization data.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public ValueTask<object?> DeserializeAsync(string text, Type type, CancellationToken cancellationToken = default);
} 
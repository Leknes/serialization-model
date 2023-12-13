namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an asynchronous serializer capable of serializing to a text.
/// </summary>
public interface IAsyncTextSerializer<in T>
{
    /// <summary>
    /// Serializes the given object to a text containing the serialized data.
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the text of the serialized object.</returns>
    public ValueTask<string> SerializeAsync(T? value, CancellationToken cancellationToken = default);
}
 
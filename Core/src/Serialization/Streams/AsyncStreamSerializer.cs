namespace Senkel.Serialization;

/// <summary>
/// Represents an asynchronous serializer capable of serializing to a stream.
/// </summary> 
public interface IAsyncStreamSerializer
{
    /// <summary>
    /// Serializes the given object asynchronously and writes the serialized data to a stream. 
    /// </summary>
    /// <param name="stream">The stream to serialize to.</param>
    /// <param name="value">The object to serialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>The task of the serialization.</returns>
    public ValueTask SerializeAsync(Stream stream, object? value, CancellationToken cancellationToken = default);
}
 
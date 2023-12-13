namespace Senkel.Serialization;



/// <summary>
/// Represents an asynchronous serializer capable of serializing to a buffer which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that the serializer can serialize.</typeparam>
public interface IAsyncBufferSerializer<in T>
{
    /// <summary>
    /// Serializes the given object asynchronously and writes the serialized data to a stream. 
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>The task of the serialization.</returns>
    public ValueTask<ReadOnlyMemory<byte>> SerializeAsync(T? value, CancellationToken cancellationToken = default);
}
 
/// <summary>
/// Represents an asynchronous serializer capable of serializing to a buffer.
/// </summary> 
public interface IAsyncBufferSerializer : IAsyncBufferSerializer<object> { }
 
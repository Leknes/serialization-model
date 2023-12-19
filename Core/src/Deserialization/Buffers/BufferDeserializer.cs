namespace Senkel.Serialization;
 
/// <summary>
/// Represents a deserializer capable of deserializing buffers.
/// </summary>
public interface IBufferDeserializer
{
    /// <summary>
    /// Deserializes an object based on the specified buffer.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="buffer">The buffer to use for deserialization.</param> 
    /// <returns>The deserialized object.</returns>
    public T? Deserialize<T>(ReadOnlySpan<byte> buffer);

    /// <summary>
    /// Deserializes an object based on the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to use for deserialization.</param>
    /// <param name="type">The type to deserialize.</param> 
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(ReadOnlySpan<byte> buffer, Type type);
}
 
/// <summary>
/// Represents a deserializer class capable of deserializing streams and buffers.
/// </summary> 
public abstract class Deserializer : StreamDeserializer, IBufferDeserializer
{
    /// <inheritdoc/>
    public virtual T? Deserialize<T>(ReadOnlySpan<byte> buffer)
    {
        return (T?)Deserialize(buffer, typeof(T));
    }

    public abstract object? Deserialize(ReadOnlySpan<byte> buffer, Type type);
    
}
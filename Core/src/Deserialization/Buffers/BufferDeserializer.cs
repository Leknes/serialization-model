namespace Senkel.Serialization;

/// <summary>
/// Represents a deserializer capable of deserializing buffers that is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that can be deserialized.</typeparam>
public interface IBufferDeserializer<out T>
{
    /// <summary>
    /// Deserializes an object based on the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to use for deserialization.</param> 
    /// <returns>The deserialized object.</returns>
    public T? Deserialize(ReadOnlySpan<byte> buffer);
}
 
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
/// Represents a deserializer class that can be used to treat a non-generic <see cref="IBufferDeserializer"/> like the <see cref="IBufferDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class BufferDeserializer<T> : IBufferDeserializer<T>
{
    private readonly IBufferDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="BufferDeserializer{T}"/> that wraps around the given <see cref="IBufferDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public BufferDeserializer(IBufferDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public T? Deserialize(ReadOnlySpan<byte> buffer)
    {
        return _deserializer.Deserialize<T>(buffer);
    }
}

/// <summary>
/// Represents a deserializer class capable of deserializing streams and buffers.
/// </summary> 
public abstract class Deserializer : StreamDeserializer, IBufferDeserializer
{
    public virtual T? Deserialize<T>(ReadOnlySpan<byte> buffer)
    {
        return (T?)Deserialize(buffer, typeof(T));
    }

    public abstract object? Deserialize(ReadOnlySpan<byte> buffer, Type type);
    
}
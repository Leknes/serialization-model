namespace Senkel.Serialization;

/// <summary>
/// Represents a deserializer capable of deserializing streams which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that can be deserialized.</typeparam>
public interface IStreamDeserializer<out T>
{
    /// <summary>
    /// Deserializes an object based on the specified stream.
    /// </summary>
    /// <param name="stream">The stream to use for deserialization.</param>
    /// <returns>The deserialized object.</returns>
    public T? Deserialize(Stream stream);
}
 
/// <summary>
/// Represents a deserializer capable of deserializing streams.
/// </summary> 
public interface IStreamDeserializer
{
    /// <summary>
    /// Deserializes an object based on the specified stream.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The stream to use for deserialization.</param> 
    /// <returns>The deserialized object.</returns>
    public T? Deserialize<T>(Stream stream);

    /// <summary>
    /// Deserializes an object based on the specified stream.
    /// </summary>
    /// <param name="stream">The stream to use for deserialization.</param>
    /// <param name="type">The type to deserialize.</param> 
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(Stream stream, Type type);
}


/// <summary>
/// Represents a deserializer class that can be used to treat a non-generic <see cref="IStreamDeserializer"/> like the <see cref="IStreamDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class StreamDeserializer<T> : IStreamDeserializer<T>
{
    private readonly IStreamDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="StreamDeserializer{T}"/> that wraps around the given <see cref="IStreamDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public StreamDeserializer(IStreamDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public T? Deserialize(Stream stream)
    {
        return _deserializer.Deserialize<T>(stream);
    }
}

/// <summary>
/// Represents a deserializer class capable of deserializing streams.
/// </summary> 
public abstract class StreamDeserializer : IStreamDeserializer
{
    public virtual T? Deserialize<T>(Stream stream)
    {
        return (T?)Deserialize(stream, typeof(T));
    }

    public abstract object? Deserialize(Stream stream, Type type);
}




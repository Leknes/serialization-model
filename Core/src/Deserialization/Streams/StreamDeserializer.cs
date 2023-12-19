namespace Senkel.Serialization;
 
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




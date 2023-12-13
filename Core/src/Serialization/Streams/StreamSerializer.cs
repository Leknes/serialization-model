namespace Senkel.Serialization;

/// <summary>
/// Represents a serializer capable of serializing to a stream which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that the serializer can serialize.</typeparam>
public interface IStreamSerializer<in T>
{
    /// <summary>
    /// Serializes the given object and writes the serialized data to a stream. 
    /// </summary>
    /// <param name="stream">The stream to serialize to.</param>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The task of the serialization.</returns>
    public void Serialize(Stream stream, T? value);
}


/// <summary>
/// Represents a serializer capable of serializing to a stream.
/// </summary> 
public interface IStreamSerializer : IStreamSerializer<object> { }
 
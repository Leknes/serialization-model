namespace Senkel.Serialization;



/// <summary>
/// Represents a serializer capable of serializing to a buffer which is bound to a specified type.
/// </summary>
/// <typeparam name="T">The type that the serializer can serialize.</typeparam>
public interface IBufferSerializer<in T>
{
    /// <summary>
    /// Serializes the given object and writes the serialized data to a stream. 
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The task of the serialization.</returns>{
    public ReadOnlySpan<byte> Serialize(T? value);
}
 
/// <summary>
/// Represents a serializer capable of serializing to a buffer.
/// </summary> 
public interface IBufferSerializer : IBufferSerializer<object> { }
 

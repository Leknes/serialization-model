namespace Senkel.Serialization;
 
/// <summary>
/// Represents a serializer capable of serializing to a buffer.
/// </summary> 
public interface IBufferSerializer
{
    /// <summary>
    /// Serializes the given object and writes the serialized data to a stream. 
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The task of the serialization.</returns>{
    public ReadOnlySpan<byte> Serialize(object? value);
}
  
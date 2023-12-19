namespace Senkel.Serialization;


/// <summary>
/// Represents an object that is capable of populating objects by reading from a buffer.
/// </summary> 
public interface IBufferPopulater
{
    /// <summary>
    /// Populates the given target by reading from the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(ReadOnlySpan<byte> buffer, object target);
}
 
namespace Senkel.Serialization;

/// <summary>
/// Represents an object that is capable of populating objects by reading from a stream.
/// </summary> 
public interface IStreamPopulater
{
    /// <summary>
    /// Populates the given target by reading from the specified stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(Stream stream, object target);
} 
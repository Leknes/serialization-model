namespace Senkel.Serialization;


/// <summary>
/// Represents an object that is capable of populating objects of a specified type by reading from a buffer.
/// </summary>
/// <typeparam name="T">The type of objects that can be populating.</typeparam>
public interface IBufferPopulater<in T>
{
    /// <summary>
    /// Populates the given target by reading from the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(ReadOnlySpan<byte> buffer, T target);
}

/// <summary>
/// Represents an object that is capable of populating objects by reading from a buffer.
/// </summary>
public interface IBufferPopulater : IBufferPopulater<object> { }

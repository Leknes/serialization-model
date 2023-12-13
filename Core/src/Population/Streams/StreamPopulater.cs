namespace Senkel.Serialization;

/// <summary>
/// Represents an object that is capable of populating objects of a specified type by reading from a stream.
/// </summary>
/// <typeparam name="T">The type of objects that can be populating.</typeparam>
public interface IStreamPopulater<in T>
{
    /// <summary>
    /// Populates the given target by reading from the specified stream.
    /// </summary>
    /// <param name="buffer">The stream to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(Stream stream, T target);
}

/// <summary>
/// Represents an object that is capable of populating objects by reading from a stream.
/// </summary>
public interface IStreamPopulater : IStreamPopulater<object> { }
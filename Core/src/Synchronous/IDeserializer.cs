namespace Senkel.Serialization;

/// <summary>
/// Represents a deserializer that is capable of deserializing objects from a source of the type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the objects that can be deserialized.</typeparam>
public interface IDeserializer<in T>
{
    /// <summary>
    /// Deserializes an object of the specified type from the given source.
    /// </summary>
    /// <param name="source">The source to deserialize from.</param>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(T source, Type type);

    /// <summary>
    /// Deserializes an object of the specified type from the given source.
    /// </summary>
    /// <param name="source">The source to deserialize from.</param>
    /// <typeparam name="U">The type of the object to deserialize.</typeparam>
    /// <returns>The deserialized object.</returns>
    public U? Deserialize<U>(T source);
}

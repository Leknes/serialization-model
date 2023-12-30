namespace Senkel.Serialization;
 
/// <summary>
/// Represents a serializer that is capable of serializing to objects of the specified type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type that objects can be serialized to.</typeparam>
public interface ISerializer<out T>
{
    /// <summary>
    /// Serializes the specified object to an instance of the type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    /// <returns>The serialized object.</returns>
    public T Serialize(object? value);
}
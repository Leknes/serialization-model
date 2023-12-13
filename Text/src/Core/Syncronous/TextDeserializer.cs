namespace Senkel.Serialization.Text;

/// <summary>
/// Represents a deserializer that is capable of deserializing text.
/// </summary>
public interface ITextDeserializer
{
    /// <summary>
    /// Deserializes the given text to an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="text">The text containing the serialization data.</param>
    /// <returns>The deserialized object.</returns>
    public T? Deserialize<T>(string text);

    /// <summary>
    /// Deserializes the given text to an object of the specified type.
    /// </summary>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <param name="text">The text containing the serialization data.</param>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(string text, Type type);
}
 
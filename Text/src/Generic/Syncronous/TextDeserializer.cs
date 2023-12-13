namespace Senkel.Serialization.Text;

/// <summary>
/// Represents a deserializer that is capable of deserializing text to the specified type.
/// </summary>
public interface ITextDeserializer<out T>
{
    /// <summary>
    /// Deserializes the given text to an object of the specified type.
    /// </summary> 
    /// <param name="text">The text containing the serialization data.</param>  
    /// <returns>The deserialized object.</returns>
    public T? Deserialize(string text);
}

/// <summary>
/// Represents a deserializer class that can be used to treat a non-generic <see cref="ITextDeserializer"/> like the <see cref="ITextDeserializer{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type that can be serialized.</typeparam>
public sealed class TextDeserializer<T> : ITextDeserializer<T>
{
    private readonly ITextDeserializer _deserializer;

    /// <summary>
    /// Creates a new instance of the <see cref="TextDeserializer{T}"/> that wraps around the given <see cref="ITextDeserializer"/> interface.
    /// </summary>
    /// <param name="deserializer">The non-generic serializer that this class is based on.</param>
    public TextDeserializer(ITextDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public T? Deserialize(string text)
    {
        return _deserializer.Deserialize<T>(text);
    }
} 
 
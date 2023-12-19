namespace Senkel.Serialization.Text;

/// <summary>
/// Represents a serializer capable of serializing to a text.
/// </summary>
public interface ITextSerializer
{
    /// <summary>
    /// Serializes the given object to a text containing the serialized data.
    /// </summary>
    /// <param name="value">The object to serialize.</param> 
    /// <returns>The text of the serialized object.</returns>
    public string Serialize(object? value);
}

namespace Senkel.Serialization;

/// <summary>
/// Represents a serializer that is capable of serializing an object and marshalling the serialized data to a destination of the type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of destination that serialized data can be marshalled to.</typeparam>
public interface IMarshal<in T>
{
    /// <summary>
    /// Serializes the specified object and marshals the serialized data to the given destination.
    /// </summary>
    /// <param name="destination">The destination to marshal to.</param>
    /// <param name="value">The object to serialize.</param>
    public void Marshal(T destination, object? value);
}
namespace Senkel.Serialization.Text;

/// <summary>
/// Contains various extensions for representing non-generic serializers as a generic counterpart.
/// </summary>
public static class DeserializationGenericExtensions
{
    /// <summary>
    /// Represents the non-generic <see cref="ITextDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="ITextDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static ITextDeserializer<T> As<T>(this ITextDeserializer deserializer)
    {
        return new TextDeserializer<T>(deserializer);
    }

    /// <summary>
    /// Represents the non-generic <see cref="IAsyncTextDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="IAsyncTextDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static IAsyncTextDeserializer<T> As<T>(this IAsyncTextDeserializer deserializer)
    {
        return new AsyncTextDeserializer<T>(deserializer);
    }
}
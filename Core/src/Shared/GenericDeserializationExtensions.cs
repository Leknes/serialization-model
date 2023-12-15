using System.Runtime.CompilerServices;

namespace Senkel.Serialization;

/// <summary>
/// Contains various extensions for representing non-generic serializers as a generic counterpart.
/// </summary>
public static class GenericDeserializationExtensions
{
    /// <summary>
    /// Represents the non-generic <see cref="IStreamDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="IStreamDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static IStreamDeserializer<T> As<T>(this IStreamDeserializer deserializer)
    {
        return new StreamDeserializer<T>(deserializer);
    }

    /// <summary>
    /// Represents the non-generic <see cref="IAsyncStreamDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="IAsyncStreamDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static IAsyncStreamDeserializer<T> As<T>(this IAsyncStreamDeserializer deserializer)
    {
        return new AsyncStreamDeserializer<T>(deserializer);
    }

    /// <summary>
    /// Represents the non-generic <see cref="IAsyncBufferDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="IAsyncBufferDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static IAsyncBufferDeserializer<T> As<T>(this IAsyncBufferDeserializer deserializer)
    {
        return new AsyncBufferDeserializer<T>(deserializer);
    }

    /// <summary>
    /// Represents the non-generic <see cref="IBufferDeserializer"/> as their generic counterpart using the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the deserializer to represent.</typeparam>
    /// <param name="deserializer">The deserializer that the <see cref="IBufferDeserializer{T}"/> is based on.</param>
    /// <returns>The generic deserializer representation.</returns>
    public static IBufferDeserializer<T> As<T>(this IBufferDeserializer deserializer)
    {
        return new BufferDeserializer<T>(deserializer);
    }
}
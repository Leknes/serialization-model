namespace Senkel.Serialization;

/// <summary>
/// Contains various deserialization extensions mainly regarding file deserialization.
/// </summary>
public static class FileDeserializationExtensions
{
    /// <summary>
    /// Deserializes an object based on the file of the given path.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <returns>The deserialized object.</returns>
    public static T? DeserializeFile<T>(this IStreamDeserializer<T> deserializer, string path)
    { 
        using var stream = File.OpenRead(path);

        return deserializer.Deserialize(stream);
    }

    /// <summary>
    /// Deserializes an object asynchronously based on the file of the given path.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public static ValueTask<T?> DeserializeFileAsync<T>(this IAsyncStreamDeserializer<T> deserializer, string path, CancellationToken cancellationToken = default)
    { 
        using var stream = File.OpenRead(path);

        return deserializer.DeserializeAsync(stream, cancellationToken);
    }

    /// <summary>
    /// Deserializes an object based on the file of the given path.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <returns>The deserialized object.</returns>
    public static T? DeserializeFile<T>(this IStreamDeserializer deserializer, string path)
    { 
        using var stream = File.OpenRead(path);

        return deserializer.Deserialize<T>(stream);
    }
     

    /// <summary>
    /// Deserializes an object asynchronously based on the file of the given path.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public static ValueTask<T?> DeserializeFileAsync<T>(this IAsyncStreamDeserializer deserializer, string path, CancellationToken cancellationToken = default)
    {  
        using var stream = File.OpenRead(path);

        return deserializer.DeserializeAsync<T>(stream, cancellationToken);
    }

    /// <summary>
    /// Deserializes an object based on the file of the given path.
    /// </summary>
    /// <param name="type">The type to deserialize.</param>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <returns>The deserialized object.</returns>
    public static object? DeserializeFile(this IStreamDeserializer deserializer, string path, Type type)
    { 
        using var stream = File.OpenRead(path);

        return deserializer.Deserialize(stream, type);
    }

    /// <summary>
    /// Deserializes an object asynchronously based on the file of the given path.
    /// </summary>
    /// <param name="type">The type to deserialize.</param>
    /// <param name="deserializer">The deserializer to use for deserialization.</param>
    /// <param name="path">The path to read the file from.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>A task containing the deserialized object.</returns>
    public static ValueTask<object?> DeserializeFileAsync(this IAsyncStreamDeserializer deserializer, string path, Type type, CancellationToken cancellationToken = default)
    { 
        using var stream = File.OpenRead(path);

        return deserializer.DeserializeAsync(stream, type, cancellationToken);
    }

   
}
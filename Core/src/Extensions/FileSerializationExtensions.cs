namespace Senkel.Serialization;

/// <summary>
/// Contains various serialization extensions mainly regarding file serialization.
/// </summary>
public static class FileSerializationExtensions
{
    private static void CreateDirectory(string filePath)
    {
        string? directoryPath = Path.GetDirectoryName(filePath);

        if(string.IsNullOrEmpty(directoryPath))
            return;

        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

        if(!directoryInfo.Exists)
            directoryInfo.Create();
    }

    private static FileStream GetFile(string path, bool createDirectory)
    {
        if(createDirectory)
            CreateDirectory(path);

        return File.OpenWrite(path);
    }

    /// <summary>
    /// Serializes an object to the file specified by the given path.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="serializer">The serializer to use for the serialization.</param>
    /// <param name="path">The path of the file to write the serialized object to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="createDirectory">If a directory will be created based on the specified path.</param>
    public static void SerializeFile<T>(this IStreamSerializer<T> serializer, string path, T? value, bool createDirectory = false)
    {  
        using var stream = GetFile(path, createDirectory);

        serializer.Serialize(stream, value);
    }

    /// <summary>
    /// Serializes an object to the file specified by the given path.
    /// </summary> 
    /// <param name="serializer">The serializer to use for the serialization.</param>
    /// <param name="path">The path of the file to write the serialized object to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="createDirectory">If a directory will be created based on the specified path.</param>
    public static void SerializeFile(this IStreamSerializer serializer,string path, object? value, bool createDirectory = false)
    { 
        using var stream = GetFile(path, createDirectory);

        serializer.Serialize(stream, value);
    }

    /// <summary>
    /// Serializes an object to the file specified by the given path asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="serializer">The serializer to use for the serialization.</param>
    /// <param name="path">The path of the file to write the serialized object to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="createDirectory">If a directory will be created based on the specified path.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <returns>The task of the serialization.</returns>
    public static ValueTask SerializeFileAsync<T>(this IAsyncStreamSerializer serializer, string path, object? value, bool createDirectory = false, CancellationToken cancellationToken = default)
    { 
        using var stream = GetFile(path, createDirectory);

        return serializer.SerializeAsync(stream, value, cancellationToken);
    }
    
    /// <summary>
    /// Serializes an object to the file specified by the given path asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="serializer">The serializer to use for the serialization.</param>
    /// <param name="path">The path of the file to write the serialized object to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="createDirectory">If a directory will be created based on the specified path.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <returns>The task of the serialization.</returns>
    public static ValueTask SerializeFileAsync<T>(this IAsyncStreamSerializer<T> serializer,string path, T? value,  bool createDirectory = false, CancellationToken cancellationToken = default)
    { 
        using var stream = GetFile(path, createDirectory);

        return serializer.SerializeAsync(stream, value, cancellationToken);
    }
}
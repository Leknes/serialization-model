namespace Senkel.Serialization;

/// <summary>
/// The exception that is thrown whenever serialization or deserialization has failed.
/// </summary>
public class SerializationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SerializationException"/> class with the specified message. 
    /// </summary>
    /// <param name="message">The message string of the exception.</param>
    public SerializationException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SerializationException"/>.
    /// </summary> 
    public SerializationException() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SerializationException"/> with the specified message and inner exception.
    /// </summary> 
    /// <param name="message">The message string of the exception.</param>
    /// <param name="innerException">The inner exception of the exception.</param>
    public SerializationException(string message, Exception innerException) : base(message, innerException) { }
} 
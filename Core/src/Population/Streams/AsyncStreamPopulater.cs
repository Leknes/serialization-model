namespace Senkel.Serialization;

/// <summary>
/// Represents an object that is capable of populating objects asynchronously by reading from a stream.
/// </summary> 
public interface IAsyncStreamPopulater
{
    /// <summary>
    /// Populates the given target asynchronously by reading from the specified stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="target">The target to populate.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    public Task Populate(Stream stream, object target, CancellationToken cancellationToken = default);
} 
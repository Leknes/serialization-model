using System.Diagnostics.CodeAnalysis;

namespace Senkel.Serialization;

/// <summary>
/// Represents an object that is capable of populating objects asynchronously by reading from a buffer.
/// </summary>
public interface IAsyncBufferPopulater
{
    /// <summary>
    /// Populates the given target asynchronously by reading from the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="target">The target to populate.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    public Task Populate(ReadOnlyMemory<byte> buffer, object target, CancellationToken cancellationToken = default);
}
 
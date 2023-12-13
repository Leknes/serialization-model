using System.Diagnostics.CodeAnalysis;

namespace Senkel.Serialization;

/// <summary>
/// Represents an object that is capable of populating objects of a specified type asynchronously by reading from a buffer.
/// </summary>
/// <typeparam name="T">The type of objects that can be populating.</typeparam>
public interface IAsyncBufferPopulater<in T>
{
    /// <summary>
    /// Populates the given target asynchronously by reading from the specified buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="target">The target to populate.</param>
    /// <param name="cancellationToken">The cancellation token of the task.</param>
    public Task Populate(ReadOnlyMemory<byte> buffer, T target, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents an object that is capable of populating objects asynchronously by reading from a buffer.
/// </summary> 
public interface IAsyncBufferPopulater : IAsyncBufferPopulater<object> { }
 
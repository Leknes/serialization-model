namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an object that is capable of populating objects asynchronously by reading from a text.
/// </summary> 
public interface IAsyncTextPopulater
{
    /// <summary>
    /// Populates the given target asynchronously by reading from the specified text.
    /// </summary>
    /// <param name="text">The text to read from.</param>
    /// <param name="target">The target to populate.</param>
    public Task Populate(string text, object target);
}
namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an object that is capable of populating objects of a specified type by reading from a text.
/// </summary>
/// <typeparam name="T">The type of objects that can be populating.</typeparam>
public interface ITextPopulater<in T>
{
    /// <summary>
    /// Populates the given target by reading from the specified text.
    /// </summary>
    /// <param name="text">The text to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(string text, T target);
}
namespace Senkel.Serialization.Text;

/// <summary>
/// Represents an object that is capable of populating objects by reading from a text.
/// </summary> 
public interface ITextPopulater
{
    /// <summary>
    /// Populates the given target by reading from the specified text.
    /// </summary>
    /// <param name="text">The text to read from.</param>
    /// <param name="target">The target to populate.</param>
    public void Populate(string text, object target);
}
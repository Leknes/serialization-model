namespace Senkel.Serialization;

/// <summary>
/// Represents a deserializer that is capable of populating objects using a source of the specified type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The typeof objects that can be used for populating.</typeparam>
public interface IPopulator<in T>
{
    /// <summary>
    /// Populates the specified target object using the given source.
    /// </summary>
    /// <param name="source">The source to populate the target from.</param>
    /// <param name="target">The object to populate.</param>
    public void Populate(T source, object target);
}
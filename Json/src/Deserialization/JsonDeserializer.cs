using Newtonsoft.Json;
using System.IO;
namespace Senkel.Serialization.Json;

/// <summary>
/// Represents a json deserializer that is capable of populating objects and deserializing objects from streams or text.
/// </summary> 
public class JsonDeserializer : IDeserializer<Stream>, IDeserializer<string>, IPopulator<Stream>, IPopulator<string>
{ 
    /// <summary>
    /// The inner json serializer from the <see cref="Newtonsoft.Json"/> package used by this deserializer.
    /// </summary>
    public readonly Newtonsoft.Json.JsonSerializer Serializer;

    /// <summary>
    /// Creates a new instance of the <see cref="JsonDeserializer"/> class with the specified serializer settings.
    /// </summary>
    /// <param name="settings">The serializer settings that the deserializer will use.</param>
    public JsonDeserializer(JsonSerializerSettings? settings)
    { 
        Serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonDeserializer"/> class with a new instance of the <see cref="JsonSerializerSettings"/> class.
    /// </summary> 
    public JsonDeserializer() : this(new JsonSerializerSettings()) { }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonDeserializer"/> class that wraps around the specified <see cref="Newtonsoft.Json.JsonSerializer"/> instance.
    /// </summary>
    /// <param name="serializer">The serializer that this instance will be based on.</param>
    public JsonDeserializer(Newtonsoft.Json.JsonSerializer serializer)
    {
        Serializer = serializer;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonDeserializer"/> class using the default settings from <see cref="JsonConvert.DefaultSettings"/>.
    /// </summary>
    /// <returns>The created instance of the <see cref="JsonDeserializer"/> class.</returns>
    public static JsonDeserializer CreateDefault()
    {
        if (JsonConvert.DefaultSettings == null)
            return new JsonDeserializer();

        return new JsonDeserializer(JsonConvert.DefaultSettings());
    }
      
    public void Populate(TextReader reader, object target)
    {
        try
        {
            Serializer.Populate(reader, target);
        }
        catch (JsonSerializationException exception)
        {
            throw new SerializationException($"Json population of target {target} has failed.", exception);
        }
    }

    public void Populate(string text, object target)
    { 
        Populate(new StringReader(text), target);
    }

    public void Populate(Stream stream, object target)
    {
        Populate(new StreamReader(stream), target);
    }

    public object? Deserialize(TextReader reader, Type type)
    {
        try
        {
            return Serializer.Deserialize(reader, type);
        }
        catch (JsonSerializationException exception)
        {
            throw new SerializationException($"Json deserialization of type {type} has failed.", exception);
        }
    }

    public object? Deserialize(string text, Type type)
    {
        return Deserialize(new StringReader(text), type);
    }

    public object? Deserialize(Stream stream, Type type)
    { 
        return Deserialize(new StreamReader(stream), type);
    }

    public T? Deserialize<T>(string text)
    {
        return (T?)Deserialize(text, typeof(T));
    }

    public T? Deserialize<T>(Stream source)
    {
        return (T?)(Deserialize(source, typeof(T)));
    }
}

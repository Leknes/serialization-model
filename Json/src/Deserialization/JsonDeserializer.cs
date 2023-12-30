using Newtonsoft.Json;
using System.IO;  

namespace Senkel.Serialization.Json;
  
/// <summary>
/// Represents a json deserializer that is capable of populating objects and deserializing objects from streams or text.
/// </summary> 
public class JsonDeserializer : IDeserializer<Stream>, IDeserializer<string>, IPopulator<Stream>, IPopulator<string>
{
    private readonly JsonSerializerSettings? _settings;

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
        _settings = settings;

        Serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonDeserializer"/> class with a new instance of the <see cref="JsonSerializerSettings"/> class.
    /// </summary> 
    public JsonDeserializer() : this(new JsonSerializerSettings()) { }

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

    private static SerializationException GetDeserializationException(Type type, JsonSerializationException exception)
    {
        return new SerializationException($"Json deserialization of type {type} has failed.", exception);
    }

    private static SerializationException GetPopulationException(object target, JsonSerializationException exception)
    {
        return new SerializationException($"Json population of target {target} has failed.", exception);
    }

    public void Populate(string text, object target)
    {
        try
        {
            JsonConvert.PopulateObject(text, target, _settings);
        }
        catch (JsonSerializationException exception)
        {
            throw GetPopulationException(target, exception);
        }
    }

    public void Populate(Stream stream, object target)
    {
        try
        {
            Serializer.Populate(new StreamReader(stream), target);
        }
        catch (JsonSerializationException exception)
        {
            throw GetPopulationException(target, exception);
        }
    }

    public object? Deserialize(string text, Type type)
    {
        try
        {
            return JsonConvert.DeserializeObject(text, type, _settings);
        }
        catch (JsonSerializationException exception)
        {
            throw GetDeserializationException(type, exception);
        }
    }

    public object? Deserialize(Stream stream, Type type)
    {
        try
        {
            return Serializer.Deserialize(new StreamReader(stream), type);
        }
        catch (JsonSerializationException exception)
        {
            throw GetDeserializationException(type, exception);
        }
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

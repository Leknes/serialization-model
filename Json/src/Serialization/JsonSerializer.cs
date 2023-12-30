using Newtonsoft.Json;
using Senkel.Serialization; 

namespace Senkel.Serialization.Json;
 
/// <summary>
/// Represents a json serializer class that is capable of serializing objects to text or to streams.
/// </summary> 
public class JsonSerializer : ISerializer<string>, IMarshal<Stream>
{
    private readonly JsonSerializerSettings? _settings;

    /// <summary>
    /// The inner json serializer from the <see cref="Newtonsoft.Json"/> package used by this serializer.
    /// </summary>
    public readonly Newtonsoft.Json.JsonSerializer Serializer;

    /// <summary>
    /// Creates a new instance of the <see cref="JsonSerializer"/> class with the specified serializer settings.
    /// </summary>
    /// <param name="settings">The serializer settings that the serializer will use.</param>
    public JsonSerializer(JsonSerializerSettings? settings)
    { 
        _settings = settings;

        Serializer = Newtonsoft.Json.JsonSerializer.Create(_settings);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonSerializer"/> class with a new instance of the <see cref="JsonSerializerSettings"/> class.
    /// </summary> 
    public JsonSerializer() : this(new JsonSerializerSettings()) { }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonSerializer"/> class using the default settings from <see cref="JsonConvert.DefaultSettings"/>.
    /// </summary>
    /// <returns>The created instance of the <see cref="JsonSerializer"/> class.</returns>
    public static JsonSerializer CreateDefault()
    {
        if(JsonConvert.DefaultSettings == null)
            return new JsonSerializer();

        return new JsonSerializer(JsonConvert.DefaultSettings());
    }

    private SerializationException GetSerializationException(object? value, JsonSerializationException exception)
    {
        return new SerializationException($"Json serialization of value {value} has failed.", exception);
    }
      
    public string Serialize(object? value)
    {
        try
        {
            return JsonConvert.SerializeObject(value, _settings);
        }
        catch (JsonSerializationException exception)
        {
            throw GetSerializationException(value, exception);
        }
    }
     
    public string Serialize(object? value, Formatting formatting)
    {
        try
        {  
            return JsonConvert.SerializeObject(value, formatting, _settings);
        }
        catch (JsonSerializationException exception)
        {
            throw GetSerializationException(value, exception);
        }
    }

    public void Marshal(Stream stream, object? value)
    {
        StreamWriter writer = new StreamWriter(stream);

        try
        {
           Serializer.Serialize(writer, value);
        }
        catch (JsonSerializationException exception)
        {
            throw GetSerializationException(value, exception);
        }

        writer.Flush();
    }
      

}


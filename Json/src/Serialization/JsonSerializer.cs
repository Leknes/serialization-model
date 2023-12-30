using Newtonsoft.Json;
using Senkel.Serialization;
using System.Globalization;
using System.Text;

namespace Senkel.Serialization.Json;
 
/// <summary>
/// Represents a json serializer class that is capable of serializing objects to text or to streams.
/// </summary> 
public class JsonSerializer : ISerializer<string>, IMarshal<Stream>
{ 
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
        Serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonSerializer"/> class that wraps around the specified <see cref="Newtonsoft.Json.JsonSerializer"/> instance.
    /// </summary>
    /// <param name="serializer">The serializer that this instance will be based on.</param>
    public JsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
    {  
        Serializer = serializer;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="JsonSerializer"/> class with a new instance of the <see cref="JsonSerializerSettings"/> class.
    /// </summary> 
    public JsonSerializer() : this(new Newtonsoft.Json.JsonSerializer()) { }

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
     
    private void Marshal(TextWriter writer, object? value)
    {
        try
        {
            Serializer.Serialize(writer, value);
        }
        catch (JsonSerializationException exception)
        {
            throw new SerializationException($"Json serialization of value {value} has failed.", exception);
        }
    }
      
    public string Serialize(object? value)
    {
        using StringWriter writer = new StringWriter(new StringBuilder(256), CultureInfo.InvariantCulture);
         
        Marshal(writer, value);

        return writer.ToString();
    }
      
    public void Marshal(Stream stream, object? value)
    {
        StreamWriter writer = new StreamWriter(stream);

        Marshal(writer, value);

        writer.Flush();
    }
      

}


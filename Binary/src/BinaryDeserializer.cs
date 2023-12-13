using MemoryPack;

namespace Senkel.Serialization.Binary;
  
public sealed class BinaryDeserializer : StreamDeserializer, IBufferDeserializer
{
    public readonly MemoryPackSerializerOptions? Options;
 
    public BinaryDeserializer(MemoryPackSerializerOptions? options = null)
    {  
        Options = options;
    }

    private SerializationException GetSerializationException(Type type, MemoryPackSerializationException exception)
    {
        return new SerializationException($"Binary deserialization to type {type} failed.", exception);
    }

    private ReadOnlySpan<byte> GetBuffer(Stream stream)
    {
        long length = stream.Length - stream.Position;

        Span<byte> buffer = new byte[length];

        stream.Read(buffer);

        return buffer;
    }

    public T? Deserialize<T>(ReadOnlySpan<byte> buffer)
    {
        try
        {
            return MemoryPackSerializer.Deserialize<T>(buffer, Options);
        }
        catch(MemoryPackSerializationException exception)
        {
            throw GetSerializationException( typeof(T), exception);
        }
    }

    public object? Deserialize(ReadOnlySpan<byte> buffer, Type type)
    {
        try
        {
            return MemoryPackSerializer.Deserialize(type, buffer, Options);
        }
        catch (MemoryPackSerializationException exception)
        {
            throw GetSerializationException(type, exception);
        }
    }

    

    public override object? Deserialize(Stream stream, Type type)
    {
        return Deserialize(GetBuffer(stream), type);
    }

    public override T? Deserialize<T>(Stream stream) where T : default
    { 
        return Deserialize<T>(GetBuffer(stream));
    }

}


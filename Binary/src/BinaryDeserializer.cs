using MemoryPack;

namespace Senkel.Serialization.Binary;
  
public sealed class BinaryDeserializer : IDeserializer<Stream>, IDeserializer<ReadOnlyMemory<byte>>
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

    private ReadOnlyMemory<byte> GetBuffer(Stream stream)
    {
        long length = stream.Length - stream.Position;

        Memory<byte> buffer = new byte[length];

        stream.Read(buffer.Span);

        return buffer;
    }

    public T? Deserialize<T>(ReadOnlyMemory<byte> buffer)
    {
        try
        {
            return MemoryPackSerializer.Deserialize<T>(buffer.Span, Options);
        }
        catch(MemoryPackSerializationException exception)
        {
            throw GetSerializationException( typeof(T), exception);
        }
    }

    public object? Deserialize(ReadOnlyMemory<byte> buffer, Type type)
    {
        try
        {
            return MemoryPackSerializer.Deserialize(type, buffer.Span, Options);
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


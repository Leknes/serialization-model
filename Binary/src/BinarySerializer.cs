using System.Buffers;
using MemoryPack;

namespace Senkel.Serialization.Binary;

public sealed class BinarySerializer : IMarshal<Stream>, ISerializer<ReadOnlyMemory<byte>>
{
    public readonly MemoryPackSerializerOptions? Options;

    public BinarySerializer(MemoryPackSerializerOptions? options = null)
    {
        Options = options;
    }

    public void Marshal(Stream stream, object? value)
    { 
        stream.Write(Serialize(value).Span);
    }
 
    public ReadOnlyMemory<byte> Serialize(object? value)
    {
        ArrayBufferWriter<byte> bufferWriter = new ArrayBufferWriter<byte>();
         
        try
        {
            MemoryPackSerializer.Serialize(bufferWriter, value, Options);
        }
        catch(MemoryPackSerializationException exception)
        {
            throw new SerializationException($"Binary serialization of value '{value}' failed.", exception);
        }
         
        return bufferWriter.WrittenMemory;
    }
}
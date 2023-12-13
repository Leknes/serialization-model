namespace Senkel.Serialization;

internal static class SerializationUtility
{
    internal static MemoryStream GetStream(ReadOnlySpan<byte> buffer)
    {
        return new MemoryStream(buffer.ToArray());
    }

    internal static MemoryStream GetStream(ReadOnlyMemory<byte> buffer)
    {
        return new MemoryStream(buffer.ToArray());
    }
}
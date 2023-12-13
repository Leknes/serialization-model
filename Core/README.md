# Serialization Framework
This framework may be used to generalize and simplify serialization as well as deserialization. It provides interfaces and convenient base classes both for 
object serialization and for serialization of types specified through the serializer. The interfaces are more fine-grained interfaces like `IStreamSerializer` or `IAsyncBufferDeserializer`.
There is also the `SerializationException` which can be used to get around the trouble of having to account for different exceptions of different libraries.

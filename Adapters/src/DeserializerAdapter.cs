using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senkel.Serialization.Adapters;

public class DeserializerAdapter<TTarget, TAdaptee> : IDeserializer<TTarget>
{
    private readonly IDeserializer<TAdaptee> _deserializerAdaptee;
    private readonly IConverter<TTarget, TAdaptee> _targetConverter;

    public DeserializerAdapter(IDeserializer<TAdaptee> deserializerAdaptee, IConverter<TTarget, TAdaptee> targetConverter)
    {
        _deserializerAdaptee = deserializerAdaptee;
        _targetConverter = targetConverter;
    }

    public object? Deserialize(TTarget source, Type type)
    {
       return _deserializerAdaptee.Deserialize(_targetConverter.Convert(source), type);
    }

    public T? Deserialize<T>(TTarget source)
    {
        return _deserializerAdaptee.Deserialize<T>(_targetConverter.Convert(source));
    }
}


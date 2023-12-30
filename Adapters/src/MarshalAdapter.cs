namespace Senkel.Serialization;

public class MarshalAdapter<TTarget, TAdaptee> : IMarshal<TTarget>
{
    private readonly IMarshal<TAdaptee> _marshalAdaptee;
    private readonly IConverter<TTarget, TAdaptee> _targetConverter;

    public MarshalAdapter(IMarshal<TAdaptee> marshalAdaptee, IConverter<TTarget, TAdaptee> targetConverter)
    {
        _marshalAdaptee = marshalAdaptee;
        _targetConverter = targetConverter;
    }

    public void Marshal(TTarget destination, object? value)
    {
        _marshalAdaptee.Marshal(_targetConverter.Convert(destination), value);
    }
}
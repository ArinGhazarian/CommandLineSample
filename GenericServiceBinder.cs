using System.CommandLine.Binding;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineSample;

public class GenericServiceBinder<TService> : BinderBase<TService> where TService : notnull
{
    private readonly ServiceProvider _sp;

    public GenericServiceBinder(ServiceProvider sp)
    {
        _sp = sp;
    }
    
    protected override TService GetBoundValue(BindingContext bindingContext) => _sp.GetRequiredService<TService>();
}
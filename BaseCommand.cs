using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineSample
{
    public abstract class BaseCommand<TArgs, THandler> : Command where TArgs : ICommandArgs where THandler : ICommandHandler<TArgs>
    {
        public BaseCommand(string name, string description = null) : base(name, description) { }

        public virtual THandler BuildHandler(TArgs args, ServiceProvider sp)
        {
            return sp.GetService<THandler>();
        }
    }
}

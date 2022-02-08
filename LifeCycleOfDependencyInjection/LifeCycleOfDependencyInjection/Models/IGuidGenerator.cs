using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCycleOfDependencyInjection.Models
{
    public interface IGuidGenerator
    {
        public Guid Guid { get; set; }
    }

    public interface IScopedGenerator : IGuidGenerator { }
    public interface ITransientGenerator : IGuidGenerator { }
    public interface ISingletonGenerator : IGuidGenerator { }


    public class ScopedGenerator : IScopedGenerator
    {
        public ScopedGenerator()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }
    }

    public class TransientGenerator : ITransientGenerator
    {
        public TransientGenerator()
        {
            Guid = Guid.NewGuid();

        }
        public Guid Guid { get ; set ; }
    }

    public class SingletonGenerator : ISingletonGenerator
    {
        public SingletonGenerator()
        {
            Guid = Guid.NewGuid();

        }
        public Guid Guid { get ; set; }
    }


}

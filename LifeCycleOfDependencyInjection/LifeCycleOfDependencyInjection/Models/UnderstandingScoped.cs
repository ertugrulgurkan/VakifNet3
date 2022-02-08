using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCycleOfDependencyInjection.Models
{
    public class UnderstandingScoped
    {
        private ITransientGenerator transient;
        private IScopedGenerator scoped;
        private ISingletonGenerator singleton;

        public UnderstandingScoped(ITransientGenerator transient, IScopedGenerator scoped, ISingletonGenerator singleton)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
        }

        public ITransientGenerator Transient { get => transient; set => transient = value; }
        public IScopedGenerator Scoped { get => scoped; set => scoped = value; }
        public ISingletonGenerator Singleton { get => singleton; set => singleton = value; }
    }
}

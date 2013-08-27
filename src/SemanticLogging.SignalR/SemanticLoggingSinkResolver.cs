using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SemanticLogging.SignalR
{
    public class SemanticLoggingSinkResolver : IDependencyResolver
    {
        private IDependencyResolver innerResolver;


        public SemanticLoggingSinkResolver(IDependencyResolver innerResolver)
        {
            this.innerResolver = innerResolver;
        }

        public void Dispose()
        {
            innerResolver.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return innerResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return innerResolver.GetServices(serviceType);
        }

        public void Register(Type serviceType, Func<object> activator)
        {
            if (serviceType == typeof (IAssemblyLocator))
            {
                innerResolver.Register(serviceType, () =>
                    {
                        IAssemblyLocator inner = (IAssemblyLocator)activator();
                        return new SemanticLoggingSinkAssemblyLocator(inner);
                    });
            }
            else
            {
                innerResolver.Register(serviceType, activator);    
            }
            
        }

        public void Register(Type serviceType, IEnumerable<Func<object>> activators)
        {
            innerResolver.Register(serviceType, activators);
        }
    }
}
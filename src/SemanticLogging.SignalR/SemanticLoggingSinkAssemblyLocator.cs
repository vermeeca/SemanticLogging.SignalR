using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNet.SignalR.Hubs;

namespace SemanticLogging.SignalR
{
    public class SemanticLoggingSinkAssemblyLocator : IAssemblyLocator
    {
        private IAssemblyLocator innerLocator;

        public SemanticLoggingSinkAssemblyLocator(IAssemblyLocator innerLocator)
        {
            this.innerLocator = innerLocator;
        }

        public IList<Assembly> GetAssemblies()
        {
            //var assemblies = innerLocator.GetAssemblies();
            //assemblies.Add(GetType().Assembly);
            //return assemblies;
            return new List<Assembly>(new[]{GetType().Assembly});
        }
    }
}
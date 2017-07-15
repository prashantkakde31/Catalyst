using System;
using System.Collections.Generic;

namespace Interpidians.Catalyst.Core.Common
{
    public interface IServiceLocator
    {
        object GetInstance(Type serviceType);
        IEnumerable<object> GetAllInstances(Type serviceType);
        TService GetInstance<TService>() where TService : class; // used for simple injector
        IEnumerable<TService> GetAllInstances<TService>() where TService : class; // used for simple injector
    }
}

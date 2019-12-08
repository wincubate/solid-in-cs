using System;
using Unity;

namespace Cinema.Domain.Test
{
    internal class DependencyInjectionTestConfig : IDisposable
    {
        public IUnityContainer Container { get; }

        public DependencyInjectionTestConfig()
        {
            Container = new UnityContainer();
        }

        public void Register( Action<IUnityContainer> registrationAction )
        {
            registrationAction(Container);
        }

        public T Resolve<T>() => Container.Resolve<T>();

        public void Dispose()
        {
            Container.Dispose();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Admin.UI.WpfApp
{
    public class SimpleAutoWireContainer
    {
        private readonly IDictionary<Type, Func<object>> _registrations;

        public SimpleAutoWireContainer()
        {
            _registrations = new Dictionary<Type, Func<object>>();
        }

        public void Register( Type abstractionType, Type implementationType )
        {
            Register( abstractionType, () => CreateNewInstance(implementationType)); 
        }

        public void Register(Type abstractionType, Func<object> factory )
        {
            _registrations[abstractionType] = factory;
        }

        public object Resolve(Type type)
        {
            if( _registrations.TryGetValue( type, out Func<object> factory ))
            {
                return factory.Invoke();
            }

            throw new InvalidOperationException($"Type {type} not registered");
        }

        private object CreateNewInstance(Type typeToCreate)
        {
            ConstructorInfo ctor = typeToCreate.GetConstructors().First();
            object[] resolvedParameters = ctor.GetParameters()
                .Select( p => Resolve( p.ParameterType ) )
                .ToArray()
                ;

            return Activator.CreateInstance( typeToCreate, resolvedParameters );
        }
    }
}

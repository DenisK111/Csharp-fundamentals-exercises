using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> dependencyContainer = new Dictionary<Type, Type>();
        public ServiceCollection()
        {

        }
        public void Add<TSource, TDestination>()
        {
            dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {

            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            var constructor = type.GetConstructors().OrderBy(x => x.GetParameters().Count()).FirstOrDefault();
            var parameterValues = new List<object>();
            var parameters = constructor!.GetParameters();

            foreach (var param in parameters)
            {
                var parameterInstance = CreateInstance(param.ParameterType);
                parameterValues.Add(parameterInstance);
            }

            var obj = constructor.Invoke(parameterValues.ToArray());
            return obj;
        }
    }
}

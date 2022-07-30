using Models;
using System.Diagnostics.CodeAnalysis;

namespace Services.Helpers.EqualityComparers
{
    internal class PropertyTypeComparer : IEqualityComparer<PropertyType>
    {
        public bool Equals(PropertyType? x, PropertyType? y)
        {
            return x!.Name.ToLower().Trim() == y!.Name.ToLower().Trim();
        }

        public int GetHashCode([DisallowNull] PropertyType obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
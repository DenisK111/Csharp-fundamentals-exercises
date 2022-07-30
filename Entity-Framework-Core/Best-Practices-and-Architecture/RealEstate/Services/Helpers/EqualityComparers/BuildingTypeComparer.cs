using Models;
using System.Diagnostics.CodeAnalysis;

namespace Services.Helpers.EqualityComparers
{
    internal class BuildingTypeComparer : IEqualityComparer<BuildingType>
    {
        public bool Equals(BuildingType? x, BuildingType? y)
        {
            return x!.Name.ToLower().Trim() == y!.Name.ToLower().Trim();
        }

        public int GetHashCode([DisallowNull] BuildingType obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
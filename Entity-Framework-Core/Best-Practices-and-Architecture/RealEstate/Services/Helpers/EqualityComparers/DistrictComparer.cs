using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers.EqualityComparers
{
    public class DistrictComparer : IEqualityComparer<District>
    {
        public bool Equals(District? x, District? y)
        {
            return x!.Name.ToLower().Trim() == y!.Name.ToLower().Trim();
        }

        public int GetHashCode(District obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}

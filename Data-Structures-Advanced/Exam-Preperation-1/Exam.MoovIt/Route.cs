using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Exam.MoovIt
{
    public class Route : IComparable<Route>
    {
        public string Id { get; set; }

        public double Distance { get; set; }

        public int Popularity { get; set; }

        public bool IsFavorite { get; set; }

        public List<string> LocationPoints { get; set; }

        public Route(string id, double distance, int popularity, bool isFavorite, List<string> locationPoints)
        {
            this.Id = id;
            this.Distance = distance;
            this.Popularity = popularity;
            this.IsFavorite = isFavorite;
            this.LocationPoints = locationPoints ?? new List<string>();
        }



        public int CompareTo(Route other)
        {
                var equal = this.Id == other.Id || (this.Distance == other.Distance && LocationPoints.FirstOrDefault() == other.LocationPoints.FirstOrDefault() && LocationPoints.LastOrDefault() == LocationPoints.LastOrDefault());

                if(equal) return 0;

            var result = other.Popularity.CompareTo(this.Popularity);
            return result == 0 ? -1 : result;          
        }

        public override bool Equals(object obj)
        {
            return obj is Route route &&
                   (Id == route.Id || (this.Distance == route.Distance && LocationPoints.FirstOrDefault() == route.LocationPoints.FirstOrDefault() && LocationPoints.LastOrDefault() == LocationPoints.LastOrDefault()));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Distance,LocationPoints.FirstOrDefault(),LocationPoints.LastOrDefault());
        }
    }
}

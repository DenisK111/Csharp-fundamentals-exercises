using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {

        private Dictionary<string, Route> _routesById = new Dictionary<string, Route>();
        private Dictionary<bool, SortedSet<Route>> _favouriteRoutes = new Dictionary<bool, SortedSet<Route>>();
        private SortedSet<Route> _routesSet = new SortedSet<Route>();
        private HashSet<Route> _routeHashSet = new HashSet<Route>();

        public int Count => _routesSet.Count;

        public void AddRoute(Route route)
        {
            if(Contains(route)) throw new ArgumentException();
            _routesById.Add(route.Id, route);
            _routesSet.Add(route);
            if (route.IsFavorite)
            {
                _favouriteRoutes.AppendValueToKey(route.IsFavorite, route);
            }
            _routeHashSet.Add(route);
        }

        public void ChooseRoute(string routeId)
        {
            var route = GetRoute(routeId);
            if (route == null) throw new ArgumentException();
            route.Popularity++;
        }

        public bool Contains(Route route)
        {
            return _routeHashSet.Contains(route);
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return _favouriteRoutes.GetValuesForKey(true)
                .Where(x => x.LocationPoints.IndexOf(destinationPoint) > 0)
                .OrderBy(s => s.Distance)
                .ThenByDescending(x => x.Popularity);
        }

        public Route GetRoute(string routeId) => _routesById.TryGetValue(routeId, out var route) ? route : throw new ArgumentException();


        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return _routesSet.Take(5).OrderByDescending(x=>x.Popularity).ThenBy(x => x.Distance).ThenBy(x => x.LocationPoints.Count);
        }

        public void RemoveRoute(string routeId)
        {
            var route = GetRoute(routeId);
            if (route == null) throw new ArgumentException();
            _routesById.Remove(routeId);
            if(route.IsFavorite) _favouriteRoutes[route.IsFavorite].Remove(route);
            _routesSet.Remove(route);
            _routeHashSet.Remove(route);
        }


        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            Predicate<Route> filter = (route) =>
            {
                var startIndex = route.LocationPoints.IndexOf(startPoint);
                var endIndex = route.LocationPoints.IndexOf(endPoint);
                return startIndex < endIndex && startIndex >= 0;
            };

            return _routesSet.Where(x=>filter(x)).OrderByDescending(x=>x.IsFavorite).ThenBy(x=>x.LocationPoints.IndexOf(endPoint) - x.LocationPoints.IndexOf(startPoint)).ThenByDescending(x=>x.Popularity);

            

        }
    }
}



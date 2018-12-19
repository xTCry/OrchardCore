using System;
using System.Linq;
using Lucene.Net.Search;
using Lucene.Net.Spatial.Prefix;
using Lucene.Net.Spatial.Prefix.Tree;
using Lucene.Net.Spatial.Queries;
using Newtonsoft.Json.Linq;
using Spatial4n.Core.Context;
using Spatial4n.Core.Distance;

namespace OrchardCore.Lucene.QueryProviders.Filters
{
    public class GeoDistanceFilterProvider : ILuceneBooleanFilterProvider
    {
        public FilteredQuery CreateFilteredQuery(ILuceneQueryService builder, LuceneQueryContext context, string type,
            JObject queryObj, Query toFilter)
        {
            if (type != "geo_distance")
                return null;

            if (queryObj.Properties().Count() != 2)
                return null;

            var ctx = SpatialContext.GEO;

            var maxLevels = 11; //results in sub-meter precision for geohash

            //  This can also be constructed from SpatialPrefixTreeFactory
            SpatialPrefixTree grid = new GeohashPrefixTree(ctx, maxLevels);

            JProperty distanceProperty = null;
            JProperty geoProperty = null;

            foreach (var jProperty in queryObj.Properties())
            {
                if (jProperty.Name.Equals("distance", StringComparison.Ordinal))
                    distanceProperty = jProperty;
                else
                    geoProperty = jProperty;
            }

            var strategy = new RecursivePrefixTreeStrategy(grid, geoProperty.Name);

            var geoPointProperty = (JObject) geoProperty.Value;

            if (geoPointProperty == null)
                return null;

            var lon = geoPointProperty["lon"];
            var lat = geoPointProperty["lat"];

            if (!TryParseDistance((string) distanceProperty.Value, out double distanceDegrees))
                return null;

            var circle = ctx.MakeCircle((double) lon, (double) lat, distanceDegrees);

            var args = new SpatialArgs(SpatialOperation.Intersects, circle);

            var filter = strategy.MakeFilter(args);

            return new FilteredQuery(toFilter, filter);
        }

        private static bool TryParseDistance(string distanceValue, out double distanceDegrees)
        {
            distanceDegrees = -1;
            if (distanceValue.EndsWith("km"))
            {
                if (double.TryParse(distanceValue.Substring(0, distanceValue.Length - 2), out double km))
                {
                    distanceDegrees = DistanceUtils.Dist2Degrees(km, DistanceUtils.EARTH_MEAN_RADIUS_KM);
                    return true;
                }
            }

            return false;
        }
    }
}
using UserCase1.Models;
using UserCase1.Models.Enums;

namespace UserCase1.Filters
{
    public static class CountryFilters
    {
        public static IEnumerable<Country> FilterByName(
            this IEnumerable<Country> countries,
            string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                countries = countries.Where(c => c.Name.Common.Trim().Contains(name.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            return countries;
        }
        public static IEnumerable<Country> FilterByPopulation(
            this IEnumerable<Country> countries,
            int? population)
        {
            if (population.HasValue)
            {
                countries = countries.Where(c => c.Population < population * 1000000);
            }

            return countries;
        }

        public static IEnumerable<Country> SortByName(
            this IEnumerable<Country> countries,
            string? sortBy)
        {
            if (!string.IsNullOrWhiteSpace(sortBy) && Enum.TryParse<SortBy>(sortBy.Trim(), true, out SortBy sortByValue))
            {
                switch (sortByValue)
                {
                    case SortBy.ascend:
                        countries = countries.OrderBy(c => c.Name.Common);
                        break;
                    case SortBy.descend:
                        countries = countries.OrderByDescending(c => c.Name.Common);
                        break;
                }
            }

            return countries;
        }

        public static IEnumerable<Country> FilterByLimit(
            this IEnumerable<Country> countries,
            int? limit)
        {
            if (limit.HasValue)
            {
                countries = countries.Take(limit.Value);
            }

            return countries;
        }
    }
}

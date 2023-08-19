using UserCase1.Models;

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
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.Trim().ToLower())
                {
                    case "name":
                        countries = countries.OrderBy(c => c.Name.Common);
                        break;
                    case "population":
                        countries = countries.OrderBy(c => c.Population);
                        break;
                        // Add more sort options if needed
                }
            }

            return countries;
        }
    }
}

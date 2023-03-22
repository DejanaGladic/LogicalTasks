using LogicalTasks.Data;
using LogicalTasks.Print;

namespace LogicalTasks.Filtering
{
    public class FilterClient
    {
        private IEnumerable<Weather> _weatherData;
        private IPrint _print;

        public FilterClient(IEnumerable<Weather> weatherData, IPrint _print)
        {
            this._weatherData = weatherData;
            this._print = _print;
        }

        public void FilterData() {

            FilterContext filterContext = new FilterContext();
            FilterStrategy filterStrategy;
            filterContext.SetListToFilter(_weatherData);

            Console.WriteLine("Sort by: 1. TEMPERATURE or 2. COUNTRY NAME");
            var sortBy = Console.ReadLine();
            var strategy = "";
            var valueForFiltering = "";
            Console.WriteLine("Choose the strategy");

            if (sortBy == "1") {
                Console.WriteLine("1. TEMP - EQUAL\n2. TEMP - GREAT THAN\n3. TEMP - LESS THAN");
                strategy = Console.ReadLine();
                Console.WriteLine("Insert value for filtering:");
                valueForFiltering = Console.ReadLine();
                switch (strategy)
                {
                    case "1":
                        filterStrategy = new FilterByTemperatureExactEqual();
                        filterContext.SetFilterStrategy(filterStrategy);
                        break;
                    case "2":
                        filterStrategy = new FilterByTemperatureGreatThan();
                        filterContext.SetFilterStrategy(filterStrategy);
                        break;
                    case "3":
                        filterStrategy = new FilterByTemperatureLessThan();
                        filterContext.SetFilterStrategy(filterStrategy);
                        break;
                    default:
                        break;

                }
            } else {
                Console.WriteLine("1. EXACT NAME\n2. START WITH");
                strategy = Console.ReadLine();
                Console.WriteLine("Insert value for filtering:");
                valueForFiltering = Console.ReadLine();
                switch (strategy)
                {
                    case "1":
                        filterStrategy = new FilterByExactCountryName();
                        filterContext.SetFilterStrategy(filterStrategy);
                        break;
                    case "2":
                        filterStrategy = new FilterByStartWithCountryName();
                        filterContext.SetFilterStrategy(filterStrategy);
                        break;
                    default:
                        break;
                }
            }

            filterContext.FilterByValue(valueForFiltering);
            _print.PrintList(filterContext.GetFilteredList());
        }      

    }
}

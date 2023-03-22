using LogicalTasks.Data;

namespace LogicalTasks.Filtering
{
    public class FilterContext
    {
        List<Weather> _filteredWeatherList = new List<Weather>();
        List<Weather> _listToFilter = new List<Weather>();
        FilterStrategy _filterStrategy;

        public void FilterByValue(string valueToFilter) {
            _filteredWeatherList = _filterStrategy.FilterByValue(_listToFilter, valueToFilter);
        }

        public void SetFilterStrategy(FilterStrategy filterStrategy) {
            _filterStrategy = filterStrategy;
        }

        public void SetListToFilter(IEnumerable<Weather> weatherList) {
            foreach (Weather weather in weatherList.ToList())
            {
                _listToFilter.Add(weather);
            }
        }

        public IEnumerable<Weather> GetFilteredList()
        {
            return _filteredWeatherList;
        }
    }
}

using LogicalTasks.Data;

namespace LogicalTasks.Filtering
{
    public class FilterByTemperatureGreatThan : FilterStrategy
    {
        public override List<Weather> FilterByValue(IEnumerable<Weather> weatherList, string filterBy)
        {
            List<Weather> _weatherList = weatherList.ToList();
            List<Weather> filteredWeatherList = new List<Weather>();

            foreach (var weather in _weatherList)
            {
                if (weather.CompareWithValue(filterBy, "Temperature") > 0)
                {
                    filteredWeatherList.Add(weather);
                }
            }
            return filteredWeatherList;
        }
    }
}

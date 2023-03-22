using LogicalTasks.Data;

namespace LogicalTasks.Filtering
{
    public abstract class FilterStrategy
    {
        public abstract List<Weather> FilterByValue(IEnumerable<Weather> weatherList, string filterBy);
    }
}

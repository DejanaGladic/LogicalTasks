namespace LogicalTasks.Task2
{
    public class WeatherRepository : IWeatherRepository
    {
        Database _database = new Database();
        public IEnumerable<Weather> GetAll()
        {
            return _database.weather;
        }
    }
}

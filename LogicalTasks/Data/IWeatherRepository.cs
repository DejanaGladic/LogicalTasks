namespace LogicalTasks.Data
{
    public interface IWeatherRepository
    {
        IEnumerable<Weather> GetAll();
    }
}

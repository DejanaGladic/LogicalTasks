namespace LogicalTasks.Task2
{
    public interface IWeatherRepository
    {
        IEnumerable<Weather> GetAll();   
    }
}

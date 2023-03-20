namespace LogicalTasks.Task2
{
    public class Task2
    {
        IWeatherRepository _weatherRepository;

        public Task2(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository; 
        }

        public void ExecutionOfTask()
        {
            List<Weather> data = _weatherRepository.GetAll().ToList();           
 
            QuickSort2(data, 0, data.Count() - 1);            

            foreach (Weather weather in data)
            {
                Console.WriteLine(weather.Temperature);
            }
        
        }

        public void QuickSort2(List<Weather> data, int start, int end) {
            if (start < end) {
                var pi = PartitionIndex(data, start, end);
                QuickSort2(data, start, pi-1);
                QuickSort2(data, pi + 1, end);
            }
        }

        public int PartitionIndex(List<Weather> data, int start, int end) {
            var pivot = data[data.Count() - 1];
            var indexOfSmaller = start - 1;

            for(int i = start; i < end; i++)
            {
                if (pivot.Temperature > data[i].Temperature)
                {
                    indexOfSmaller++;
                    Weather temporary1 = data[indexOfSmaller];
                    data[indexOfSmaller] = data[i];
                    data[i] = temporary1;
                }

            }
            Weather temporary2 = data[indexOfSmaller+1];
            data[indexOfSmaller+1] = data[end];
            data[end] = temporary2;
            return indexOfSmaller + 1;         
        }
    }
}

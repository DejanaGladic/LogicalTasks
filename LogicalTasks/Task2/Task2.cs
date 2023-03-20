namespace LogicalTasks.Task2
{
    public class Task2
    {
        IWeatherRepository _weatherRepository;
        List<Weather> data;

        public Task2(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
            data = _weatherRepository.GetAll().ToList();
        }

        public void SortByTemperature()
        {
            BeginningOfSorting("Temperature");
            Console.WriteLine("Sorted by temperature: ");
            printSortedList(data);
             
        }
        public void SortByCityName()
        {
            BeginningOfSorting("City");
            Console.WriteLine("Sorted by city name: ");
            printSortedList(data);

        }
        public void BeginningOfSorting(string sortByProperty)
        {
            int start = 0;
            int end = data.Count - 1;
            QuickSort(data, start, end, sortByProperty);
        }

        public void QuickSort(List<Weather> data, int start, int end,string sortByProperty) {
            if (start < end) {
                var pi = PartitionIndex(data, start, end, sortByProperty);
                QuickSort(data, start, pi-1, sortByProperty);
                QuickSort(data, pi + 1, end, sortByProperty);
            }
        }

        public int PartitionIndex(List<Weather> data, int start, int end, string sortByProperty) {
            var pivot = data[end];
            var indexOfSmaller = start - 1;
            Weather temporary;
            for (int i = start; i < end; i++)
            {
                if (CompareValue(pivot, data[i], sortByProperty) > 0)
                {
                    indexOfSmaller++;
                    temporary = data[indexOfSmaller];
                    data[indexOfSmaller] = data[i];
                    data[i] = temporary;
                }
            }
            indexOfSmaller++;
            temporary = data[indexOfSmaller];
            data[indexOfSmaller] = data[end];
            data[end] = temporary;

            return indexOfSmaller;         
        }

        public decimal CompareValue(Weather firstValueToCompare, Weather secondValueToCompare, string sortByProperty) {
            Object firstValue = firstValueToCompare.GetValueByPropertieName(sortByProperty);
            Object secondValue = secondValueToCompare.GetValueByPropertieName(sortByProperty);
            if(firstValue is decimal && secondValue is decimal)
            {
                return decimal.Parse(firstValue.ToString()) - decimal.Parse(secondValue.ToString());
            }
            return string.Compare(firstValue.ToString(), secondValue.ToString());
        } 

        public void printSortedList(List<Weather> weatherList) {
            foreach (Weather weather in weatherList)
            {
                Console.WriteLine(weather.ToString());
            }
        }
    }
}
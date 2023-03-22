using LogicalTasks.Data;
using LogicalTasks.Print;

namespace LogicalTasks.Task2
{
    public class Sorting
    {
        IWeatherRepository _weatherRepository;
        IPrint _print;
        List<Weather> data;
        IEnumerable<Weather> sortedList;

        public Sorting(IWeatherRepository weatherRepository, IPrint print)
        {
            _weatherRepository = weatherRepository;
            _print = print;
            data = _weatherRepository.GetAll().ToList();
        }

        public void SortBy(string sortBy)
        {
            BeginningOfSorting(sortBy);
        }

        public void PrintSortedList() {
            Console.WriteLine($"Sorted list: ");
            _print.PrintList(data);
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
                if (pivot.CompareWithValue(data[i], sortByProperty) > 0)
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

        public IEnumerable<Weather> GetSortedWeatherList() {
            sortedList = data;
            return sortedList;
        }
    }
}
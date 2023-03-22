using LogicalTasks.Data;

namespace LogicalTasks.Task3
{
    public class Searching
    {
        List<Weather> _listToSearch;
        string _searchType;

        public Searching(List<Weather> listToSearch, string searchType)
        {
            _listToSearch = listToSearch;
            _searchType = searchType;
        }

        public void Search(string itemToSearch)
        {
            int startSearching = 0;
            int endSearching = _listToSearch.Count() - 1;
            int indexOfSearchedItem = BinarySearch(itemToSearch, startSearching, endSearching);
            Console.WriteLine(_listToSearch[indexOfSearchedItem]);
        }

        private int BinarySearch(string itemToSearch, int startSearching, int endSearching)
        {
            if (startSearching > endSearching)
                return -1;
                        
            var midIndex = (startSearching + endSearching) / 2;
            var comparableResult = _listToSearch[midIndex].CompareWithValue(itemToSearch, _searchType);
            if (comparableResult < 0)
            {
                midIndex = BinarySearch(itemToSearch, midIndex + 1, endSearching);
            }
            else if (comparableResult > 0)
            {
                midIndex = BinarySearch(itemToSearch, startSearching, midIndex - 1);
            }

            return midIndex;
        }
    }
}

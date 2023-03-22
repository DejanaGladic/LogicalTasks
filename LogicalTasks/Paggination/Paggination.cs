using LogicalTasks.Data;
using LogicalTasks.Print;

namespace LogicalTasks.Task4
{
    public class Paggination
    {
        int _itemsPerPage;        
        List<Weather> _data;
        IPrint _print;

        Dictionary<int, List<Weather>> weatherDictionary = new Dictionary<int, List<Weather>>();
        int _numberOfPages;

        public Paggination(IPrint print,List<Weather> data, int itemsPerPage)
        {
            _print = print;
            _data = data;
            _itemsPerPage = itemsPerPage; 
        }

        public void Pagginate() {
            NumberOfPages();
            DivideElementsInPages();

            Console.WriteLine("First page");
            var currentNumberOfPage = 1;
            PrintElements(currentNumberOfPage);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("P for previous\nN for next page" +
                    "\nTF for first\nTL for last");
                Console.WriteLine();
                var userInsert = Console.ReadLine();

                switch (userInsert.ToLower())
                {
                    case "n":
                        currentNumberOfPage = NextPage(currentNumberOfPage);                        
                        break;
                    case "p":
                        currentNumberOfPage = PreviousPage(currentNumberOfPage);                       
                        break;
                    case "tf":
                        currentNumberOfPage = 1;
                        break;
                    case "tl":
                        currentNumberOfPage = _numberOfPages;
                        break;
                    default:
                        break;
                }
                
                PrintElements(currentNumberOfPage);
            }
        }

        private void NumberOfPages() {
            _numberOfPages = _data.Count() / _itemsPerPage;
            if (_data.Count() % _itemsPerPage > 0)
                _numberOfPages++;
        }

        private void DivideElementsInPages()
        {
            var fromItemIndex = 0;
            var toItemIndex = _itemsPerPage;
            for (int i = 1; i <= _numberOfPages; i++)
            {
                weatherDictionary.Add(i, new List<Weather>());
                for (int j = fromItemIndex; j < toItemIndex; j++)
                {
                    if (_data.Count() == j)
                        break;
                    weatherDictionary[i].Add(_data[j]);
                }
                fromItemIndex = toItemIndex;
                toItemIndex += _itemsPerPage;
            }
        }

        private int NextPage(int numberOfPage) {
            numberOfPage++;
            if (numberOfPage > _numberOfPages)
            {
                numberOfPage--;
                Console.WriteLine("Nothing new to show - this is the last page");
            }
            return numberOfPage;
        }

        private int PreviousPage(int numberOfPage) {
            numberOfPage--;
            if (numberOfPage < 1)
            {
                numberOfPage++;
                Console.WriteLine("Nothing new to show - this is the first page");
            }
            return numberOfPage;
        }

        private void PrintElements(int numberOfPage) {

            var listByKey = weatherDictionary[numberOfPage];

            Console.WriteLine("*********** Number of page is: " + numberOfPage);
            _print.PrintList(listByKey);

        }
    }
}

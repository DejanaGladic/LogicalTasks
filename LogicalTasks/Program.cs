using LogicalTasks.Data;
using LogicalTasks.Filtering;
using LogicalTasks.InterfaceImplementation;
using LogicalTasks.Print;
using LogicalTasks.Task1;
using LogicalTasks.Task2;
using LogicalTasks.Task3;
using LogicalTasks.Task4;

IWeatherRepository weatherRepository = new WeatherRepository();
List<Weather> allWeatherData = weatherRepository.GetAll().ToList();
IPrint print = new Print();

Sorting task2 = new Sorting(weatherRepository, print);

Console.WriteLine("Choose the task:\n1. STAR TREE\n2. SORTING\n" +
    "3. SEARCHING\n4. FILTRATION\n5. PAGGINATION");
var choose = Console.ReadLine();

if (choose == "1")
{
    Console.WriteLine("**********STAR TREE************");
    StarTree task1 = new StarTree();
    task1.ExecutionOfTask1();
}
else if (choose == "2")
{
    Console.WriteLine("**********SORTING************");
    Console.WriteLine("**********Temperature");
    task2.SortBy("Temperature");
    task2.PrintSortedList();
    Console.WriteLine("**********City");
    task2.SortBy("City");
    task2.PrintSortedList();
    Console.WriteLine("**********ZipCode");
    task2.SortBy("ZipCode");
    task2.PrintSortedList();
}
else if (choose == "3")
{
    Console.WriteLine("**********SEARCHING************");
    Console.WriteLine("Type zip code to search");

    task2.SortBy("ZipCode");
    List<Weather> listToSearch = task2.GetSortedWeatherList().ToList();
    Searching searching = new Searching(listToSearch,"ZipCode");

    string itemToSearch = Console.ReadLine();
    searching.Search(itemToSearch);
}
else if (choose == "4")
{
    Console.WriteLine("**********FILTRATION************");
    FilterClient filterClient = new FilterClient(allWeatherData, print);
    filterClient.FilterData();
}
else if (choose == "5")
{
    Console.WriteLine("**********PAGGINATION************");
    int itemsPerPage = 3;
    Paggination task4 = new Paggination(print, allWeatherData, itemsPerPage);
    task4.Pagginate();
}





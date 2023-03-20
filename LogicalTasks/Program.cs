using LogicalTasks.Task1;
using LogicalTasks.Task2;

Console.WriteLine("**********TASK 1************");
Task1 task1 = new Task1();
task1.ExecutionOfTask1();

Console.WriteLine();
Console.WriteLine("**********TASK 2************");
IWeatherRepository weatherRepository = new WeatherRepository();
Task2 task2 = new Task2(weatherRepository);
task2.SortByTemperature();
Console.WriteLine("**********");
task2.SortByCityName();
using LogicalTasks.Task1;
using LogicalTasks.Task2;

/*Task1 task1 = new Task1();
task1.ExecutionOfTask1();*/

IWeatherRepository weatherRepository = new WeatherRepository();
Task2 task2 = new Task2(weatherRepository);
task2.ExecutionOfTask();
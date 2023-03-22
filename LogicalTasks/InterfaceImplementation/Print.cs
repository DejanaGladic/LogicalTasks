using LogicalTasks.Data;
using LogicalTasks.Print;

namespace LogicalTasks.InterfaceImplementation
{
    public class Print : IPrint
    {
        public void PrintList(IEnumerable<Weather> listToPrint)
        {
            foreach (Weather weather in listToPrint)
            {
                Console.WriteLine(weather.ToString());
            }
        }
    }
}

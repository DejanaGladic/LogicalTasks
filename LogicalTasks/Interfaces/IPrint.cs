using LogicalTasks.Data;

namespace LogicalTasks.Print
{
    public interface IPrint
    {
        void PrintList(IEnumerable<Weather> listToPrint);
    }
}

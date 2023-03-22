using LogicalTasks.Data;

namespace LogicalTasks.Interfaces
{
    public interface ICompare
    {
        decimal CompareWithValue(Object valueToCompare, string compareProperty);
    }
}

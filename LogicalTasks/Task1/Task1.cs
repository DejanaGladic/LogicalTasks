namespace LogicalTasks.Task1
{
    public class Task1
    {
        public void ExecutionOfTask1() {
            Console.WriteLine("Enter number of lines");
            var numberOfLines = Console.ReadLine();
            for (int i = 0; i < Int32.Parse(numberOfLines); i++)
            {

                for (int j = Int32.Parse(numberOfLines) - i; j > 0; j--)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.Write(" ");

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

    }
}

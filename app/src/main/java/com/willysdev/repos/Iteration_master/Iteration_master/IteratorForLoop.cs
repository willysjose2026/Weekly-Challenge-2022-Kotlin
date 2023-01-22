namespace Iteration_master
{
    internal class IteratorForLoop : IteratorMaster, IteratorFactory
    {
        public override void IterateFromOneToHundred()
        {
            Console.WriteLine("\nPrinting with for loop");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            };
        }
    }
}

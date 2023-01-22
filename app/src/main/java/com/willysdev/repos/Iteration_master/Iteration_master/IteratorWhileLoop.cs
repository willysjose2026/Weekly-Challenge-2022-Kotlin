namespace Iteration_master
{
    internal class IteratorWhileLoop : IteratorMaster, IteratorFactory
    {
        public override void IterateFromOneToHundred()
        {
            Console.WriteLine("\nPrinting with while loop");

            int index = 0;
            while(index < 100)
            {
                Console.WriteLine(index + 1);
                index++;
            }
        }
    }
}

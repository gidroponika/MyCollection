namespace MyCollection
{
    internal class Program
    {
        static void Main()
        {
            MyCollection my = new MyCollection(1, 4, 89, 77, 45, 69, 10, 77, 34, 99, 89);

            foreach (uint i in my)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(new string('-', 10));

            Console.WriteLine(my.Remove(77));

            foreach (uint i in my)
            {
                Console.WriteLine(i);
            }
        }
    }
}
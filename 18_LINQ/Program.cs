using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _18_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-10, 11);
            }
            IEnumerable<int> query = from num in numbers where num > 0 orderby num select num;

            
            int[] numbers1 = new int[10];
            for (int i = 0; i < numbers1.Length; i++)
            {
                numbers1[i] = random.Next(-10, 11);
            }
            int twodigit = numbers1.Where(n => n >= 10 && n <100).Count();
            IEnumerable<int> query1 = from n in numbers where n >= 10 && n < 100 select n;
            int average = (int)query1.Average();

        }
    }
}

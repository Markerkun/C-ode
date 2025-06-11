using System.Security.Cryptography;

namespace _02_ArrayEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //1
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(10);
            }
            int even = 0;
            int odd = 0;
            int count = 0;
            int uniq = 0;
            foreach(int i in numbers)
            {
                if (i % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
                foreach (int j in numbers)
                {
                    if (i == j)
                    {
                        count++;
                        break;
                    }
                }
                if (count == 1)
                {
                    uniq++;
                }
            }
            Console.WriteLine($"Even: {even}, Odd: {odd}, Unique: {uniq}");
            //2
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            int found = 0;
            foreach (int i in numbers)
            {
                if (i < number)
                {
                    Console.WriteLine(i);
                    found++;
                    break;
                }
            }
            Console.WriteLine($"Found: {found} numbers less than {number}.");
            //3
            int[] A = new int[5];
            double[,] B = new double[4,3];
            double min = 0;
            double max = 0;
            double sum = 0;
            int EvenSum = 0;
            double multy = 1;
            double OddMulty = 1;


           
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Enter number {i + 1} for array A: ");
                A[i] = int.Parse(Console.ReadLine());
                Console.Write($"{A[i] + " "} ");
                sum += A[i];
                multy *= A[i];
                if (A[i] % 2 == 0)
                {
                    EvenSum += A[i];
                }
            }
            min = A[0];
            max = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < min) min = A[i];
                if (A[i] > max) max = A[i];
            }
            Console.WriteLine($"Array A\nMin: {min}, Max: {max}, Sum: {sum}, Multy: {multy}, Sum of even nums: {EvenSum}");
            sum = 0;
            multy = 1;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = Math.Round(random.NextDouble() + random.Next(10), 2);
                    Console.Write(B[i, j] + " ");
                    sum += A[i];
                    multy *= A[i];
                }
                Console.WriteLine();
            }
            min = B[0, 0];
            max = B[0, 0];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] < min) min = B[i, j];
                    if (B[i, j] > max) max = B[i, j];
                    if (j % 2 != 0) OddMulty *= B[i, j];
                }
                
            }
            Console.WriteLine($"Array B\nMin: {min}, Max: {max}, Sum: {sum}, Multy: {multy}, Multy of odd columns: {OddMulty}");
            //4
            int[,] C = new int[5, 5];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    C[i, j] = random.Next(-100, 100);
                    Console.Write(C[i, j] + " ");
                }
                Console.WriteLine();
            }   




        }
    }
}

namespace _01_FirstLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("It's easy to win forgiveness for being wrong;\r\nbeing right is what gets you into real trouble.\r\nBjarne Stroustrup");
            //2
            Console.Write("Enter a first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a fourth number: ");
            int fourthNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a fifth number: ");
            int fifthNumber = int.Parse(Console.ReadLine());
            int sum = firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber;
            int min = fifthNumber;
            if (firstNumber < min) min = firstNumber;
            if (secondNumber < min) min = secondNumber;
            if (thirdNumber < min) min = thirdNumber;
            if (fourthNumber < min) min = fourthNumber;
            int max = fifthNumber;
            if (firstNumber > max) max = firstNumber;
            if (secondNumber > max) max = secondNumber;
            if (thirdNumber > max) max = thirdNumber;
            if (fourthNumber > max) max = fourthNumber;
            int multy = firstNumber * secondNumber * thirdNumber * fourthNumber * fifthNumber;
            Console.WriteLine($"Sum: {sum}, Min: {min}, Max: {max}, Multy: {multy}");
            //3
            Console.Write("Enter a 6-digital num: ");
            int num = int.Parse(Console.ReadLine());
            int first = num / 100000;
            int second = (num / 10000) % 10;
            int third = (num / 1000) % 10;
            int fourth = (num / 100) % 10;
            int fifth = (num / 10) % 10;
            int sixth = num % 10;
            Console.WriteLine($"{sixth}{fifth}{fourth}{third}{second}{first}");
            //4
            int p = 0;
            int c = 1;
            int n = p + c;
            Console.WriteLine("Write a range: ");
            int range = int.Parse(Console.ReadLine());
            Console.Write("0, ");
            for (int i = 0; i < range; i = c)
            {
                Console.Write($"{c}, ");
                p = c;
                c = n;
                n = p + c;
            }
            //5
            Console.Write("Enter a number A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter a number B: ");
            int b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
            //6
            Console.WriteLine("Enter a lenght: ");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a simbol: ");
            char symbol = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter a direction[v,h]: ");
            char direction = char.Parse(Console.ReadLine().ToLower());
            if (direction == 'v')
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(symbol);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}

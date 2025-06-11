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
            Console.Write("Enter a first number: ");
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a first number: ");
            int fourthNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a first number: ");
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
            Console.Write("Enter a message: ");
            string message = Console.ReadLine();
            for (int i = message.Length-1; i >= 0; i++)
            {
                Console.Write(message[i]);
            }
            //4

        }
    }
}

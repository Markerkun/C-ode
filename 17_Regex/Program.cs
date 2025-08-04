using System.Text.RegularExpressions;

namespace _16_Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            string filePath = "input.txt";
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new[] { ' ', '\n', '\r', ',', ';', '.', '!', '?' });

            string pattern = @"\d+[.,]\d+";


            foreach (string word in words)
            {
                if (Regex.IsMatch(word, pattern))
                {
                    Console.WriteLine($"Знайдено дробове число: {word}");
                }
            }

            //2
            string Newpattern = @"\d+";
            int[] nums = {};
            foreach (string word in words)
            {
                if (Regex.IsMatch(word, Newpattern))
                {
                    nums = (int[])nums.Append(int.Parse(word));
                }
            }

            //3
            string password;
            string email;
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            email = Console.ReadLine();
            string emailpattern = @"^[\w\-\.]{4,}\@\w{2,}\.(com)$";
            string passwordpattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[-_])[a-zA-Z\d-_]{6,}$";

        }
    }
}

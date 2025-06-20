using System.Text;

namespace _03_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            string text = "Hello, World!";
            string MY = "My";
            string[] ARR = text.Split(' ');
            string full = String.Join(" ", ARR[0], MY, ARR[1]);
            Console.WriteLine(full);

            //2
            string reversed = new string(text.Reverse().ToArray());
            bool isPalindrome = false;
            if (text == reversed) isPalindrome = true;
            Console.WriteLine($"Reversed: {reversed}, Is Palindrome: {isPalindrome}");

            //3
            string text1 = "Hello WORLD!";
            double upper = text1.Count(char.IsUpper);
            double lower = text1.Count(char.IsLower);
            int total = text1.Length;
            double percentUpper = upper / total * 100;
            double percentLower = lower / total * 100;
            Console.WriteLine($"Uppercase: {percentUpper}%, Lowercase: {percentLower}%");

            //4
            string[] words = { "Hello", "world", "cat", "sunshine" };
            int targetLength = 5;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == targetLength && words[i].Length >= 3)
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
            }
            Console.WriteLine(string.Join(", ", words));

            //5
            string sentence = "The quick brown fox jumps";
            int wordNumber = 3;
            string[] wordArray = sentence.Split(' ');
            if (wordNumber > 0 && wordNumber <= wordArray.Length)
            {
                char firstChar = wordArray[wordNumber - 1][0];
                Console.WriteLine($"Word #{wordNumber}: {wordArray[wordNumber - 1]}, First letter: {firstChar}");
            }

            //6
            string messyText = "   Hello   world   again   ";
            string[] cleaned = messyText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string readyText = string.Join("*", cleaned);
            Console.WriteLine(readyText);

            //7
            StringBuilder sb = new StringBuilder();
            do
            {
                Console.Write("Enter word: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                sb.Append(input.TrimEnd('.'));

                if (input.EndsWith(".")) break;
                sb.Append(", ");


            } while (true);
            Console.WriteLine("Result: " + sb.ToString());
        }
    }
}
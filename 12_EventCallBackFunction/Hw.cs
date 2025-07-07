
namespace _12_EventCallBackFunction
{
    
    //////////////////////////
    
    static class StringExtensions
    {
        //1
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        //2
        public static string Cipher(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            char[] ciphered = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    ciphered[i] = (char)(str[i] - 3);
                }
                else
                {
                    ciphered[i] = str[i]; 
                }
            }
            return new string(ciphered);
        }
    }

    static class ArrayExtensions
    {
        //3
        public static int AmountOfSameChar(this string[] array, char sym)
        {
            int count = 0;
            foreach (string item in array)
            {
                foreach (var c in item)
                {
                    if (c == sym)
                    {
                        count++;
                    }
                }
                
            }
            return count;
        }
        public static int AmountOfSameInt(this int[] array, int sym)
        {
            int count = 0;
            foreach (int item in array)
            {
                    if (item == sym)
                    {
                        count++;
                    }
                
            }
            return count;
        }
        public static int AmountOfSameFloat(this float[] array, float sym)
        {
            int count = 0;
            foreach (float item in array)
            {
                    if (item == sym)
                    {
                        count++;
                    }
                
            }
            return count;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Enter a word to check if it's a palindrome:");
            string input = Console.ReadLine();
            if (input.IsPalindrome())
            {
                Console.WriteLine($"The word '{input}' is a palindrome.");
            }
            else
            {
                Console.WriteLine($"The word '{input}' is not a palindrome.");
            }
            ///////////////////
            //2
            Console.WriteLine("Enter a string to cipher:");
            string text = Console.ReadLine();
            string cipheredText = text.Cipher();
            Console.WriteLine($"Ciphered text: {cipheredText}");
            ///////////////////
            //3
            int[] intArray = { 1, 2, 3, 4, 5, 1, 2, 1 };
            Console.WriteLine("Enter an integer to count its occurrences in the array:");
            int intSym = int.Parse(Console.ReadLine());
            int intCount = intArray.AmountOfSameInt(intSym);
            Console.WriteLine($"The integer {intSym} occurs {intCount} times in the array.");
            Console.WriteLine();

            ///////////////////
            string[] stringArray = { "apple", "banana", "cherry", "apple" };
            Console.WriteLine("Enter a character to count its occurrences in the string array:");
            string charSym = Console.ReadLine();
            char character = charSym[0];
            int charCount = stringArray.AmountOfSameChar(character);
            Console.WriteLine();

            ///////////////////
            float[] floatArray = { 1.1f, 2.2f, 3.3f, 1.1f, 4.4f };
            Console.WriteLine("Enter a float to count its occurrences in the float array:");
            float floatSym = float.Parse(Console.ReadLine());
            int floatCount = floatArray.AmountOfSameFloat(floatSym);
            Console.WriteLine($"The float {floatSym} occurs {floatCount} times in the float array.");


        }

    }
}

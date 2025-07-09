using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _13_HwDictionary
{
    internal class Hw
    {
        static void Main(string[] args)
        {
            string text = "Ось будинок, який збудував Джек. А це пшениця, яка\r\nу темній коморі зберігається у будинку, який збудував\r\nДжек. А це веселий птах-синиця, який часто краде\r\nпшеницю, яка в темній коморі зберігається у будинку,\r\nякий збудував Джек.";
            string[] words = text.Split(new char[] { ' ', '!', '?', ',', '.', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                string lowerWord = word.ToLower();
                if (wordCount.ContainsKey(lowerWord))
                {
                    wordCount[lowerWord]++;
                }
                else
                {
                    wordCount[lowerWord] = 1;
                }
            }
            Console.WriteLine("Слово - Кількість входжень");
            foreach(KeyValuePair<string, int> word in wordCount )
            {
                    Console.WriteLine($"Key : {word.Key,10}\t Value : {word.Value,10}");
            }
        }
    }
}

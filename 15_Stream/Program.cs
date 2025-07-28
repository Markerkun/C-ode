using System.Text;
namespace _15_Stream
{
    internal class Program
    {
        public static void ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
                return;
            }

            using (StreamReader stream = new StreamReader(fileName))
            {

                while (!stream.EndOfStream)
                {
                        Console.WriteLine(stream.ReadLine());
                }
            }
        }
        public static void WriteFile<T>(string fileName, T[] content)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} already exists");
                return;
            }
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                foreach (T item in content)
                {
                    stream.WriteLine(item);
                }
            }
        }
        public static void AppendToFile<T>(string fileName, T content)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found, creating a new file.");
            }
            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(content);
            }
        }
        public static void ReadToArray<T>(string fileName, T[] arr)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
                return;
            }
            using (StreamReader stream = new StreamReader(fileName))
            {
                int i = 0;
                while (!stream.EndOfStream && i < arr.Length)
                {
                    string line = stream.ReadLine();
                    if (line != null)
                    {
                        arr[i] = (T)Convert.ChangeType(line, typeof(T));
                        i++;
                    }
                }
            }
        }
        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine($"File {fileName} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File {fileName} does not exist.");
            }
        }



        public static void FindWordInFile(string fileName, string word)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
                return;
            }
            using (StreamReader stream = new StreamReader(fileName))
            {
                int counter = 0;
                int lineNumber = 0;
                while (!stream.EndOfStream)
                {
                    lineNumber++;
                    string line = stream.ReadLine();
                    if (line != null && line.Contains(word))
                    {
                        Console.WriteLine($"Found '{word}' in line {lineNumber}: {line}");
                    }
                    counter++;
                }
            }
        }
        public static void FindRWordInFile(string fileName, string word)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
                return;
            }
            using (StreamReader stream = new StreamReader(fileName))
            {
                char[] chars = word.ToCharArray();
                Array.Reverse(chars);
                string Rword = new string(chars);

                int counter = 0;
                int lineNumber = 0;
                while (!stream.EndOfStream)
                {
                    lineNumber++;
                    string line = stream.ReadLine();
                    if (line != null && line.Contains(Rword))
                    {
                        Console.WriteLine($"Found '{Rword}' in line {lineNumber}: {line}");
                    }
                    counter++;
                }
            }
        }

        public static void StisticFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
                return;
            }
            FileInfo fileInfo = new FileInfo(fileName);
            int sentences = 0, capital_letters = 0, lowercase_letters = 0, vowels = 0, consonants = 0, numbers = 0;
            for (int i = 0; i < sentences; i++) {
                if (char.IsUpper(fileName[i]))
                {
                    capital_letters++;
                }
                else if (char.IsLower(fileName[i]))
                {
                    lowercase_letters++;
                }
                else if (char.IsDigit(fileName[i]))
                {
                    numbers++;
                }
                else if ("aeiouAEIOU".Contains(fileName[i]))
                {
                    vowels++;
                }
                else if ("qwrtpsdfghjklzxcvbnmQWRTPSDFGHJKLZXCVBNM".Contains(fileName[i]))
                {
                    consonants++;
                }
                else if (fileName[i]=='.')
                {
                    sentences++;
                }
            }
            Console.WriteLine($"File: {fileName}");
            Console.WriteLine($"Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Sentences: {sentences}");
            Console.WriteLine($"Capital Letters: {capital_letters}");
            Console.WriteLine($"Lowercase Letters: {lowercase_letters}");
            Console.WriteLine($"Vowels: {vowels}");
            Console.WriteLine($"Consonants: {consonants}");
            Console.WriteLine($"Numbers: {numbers}");
        }




        static void Main(string[] args)
        {
            //int[] arr = new int[10];
            //int[]pureArr = new int[10];

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"Enter element {i + 1}: ");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //WriteFile<int>("arr.txt", arr);
            //ReadFile("arr.txt");
            //ReadToArray<int>("arr.txt", pureArr);
            //DeleteFile("arr.txt");




            //Random random = new Random();

            //for (int i = 0; i < 1001; i++)
            //{
            //    int number = random.Next(1, 1001);
            //    if (number % 2 == 0)
            //    {
            //        AppendToFile<int>("even.txt", number);
            //    }
            //    else
            //    {
            //        AppendToFile<int>("odd.txt",  number );
            //    }
            //}
            
                
            string[] array = new string[4];
            array[0] = "Moon";
            array[1] = "moon";
            array[2] = "moon";
            array[3] = "Noom";
            array[4] = "noom";

            WriteFile<string>("words.txt", array);
            ReadFile("words.txt");
            FindWordInFile("words.txt", "moon");
            FindRWordInFile("words.txt", "moon");







        }
    }
}

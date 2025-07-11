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






        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int[]pureArr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            WriteFile<int>("arr.txt", arr);
            ReadFile("arr.txt");
            ReadToArray<int>("arr.txt", pureArr);
            DeleteFile("arr.txt");
        }
    }
}

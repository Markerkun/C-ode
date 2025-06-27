namespace _09_interface
{
    //1
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    partial class Array : IOutput
    {
        private int[] array;

        public Array(int size = 10)
        {
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i + 1;
            }
        }
        public void Show()
        {
            Console.WriteLine("Array elements:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }
    }
    

    /////////////////////////
    //2
    interface IMath
    {
        int Min();
        int Max();
        float Average();
        bool Search(int value);
    }
    partial class Array : IMath
    {
        public int Min()
        {
            return array.Length > 0 ? array.Min() : 0;
        }
        public int Max()
        {
            return array.Length > 0 ? array.Max() : 0;
        }
        public float Average()
        {
            return (float)(array.Length > 0 ? array.Average() : 0f);
        }
        public bool Search(int value)
        {
            return array.Contains(value);
        }
    }
    ///////////////////////////
    //3
    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    partial class Array : ISort
    {
        public void SortAsc()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void SortDesc()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }

        internal class Program
    {
        
        static void Main(string[] args)
        {
            //1
            Array array = new Array();
            array.Show(); 
            array.Show("Custom message: Here are the array elements:");
            ////////////////////////
            //2
            Console.WriteLine();
            Console.WriteLine($"Min: {array.Min()}");
            Console.WriteLine($"Max: {array.Max()}");
            Console.WriteLine($"Average: {array.Average()}");
            int searchValue = 5;
            Console.WriteLine($"Search {searchValue}: {array.Search(searchValue)}");
            /////////////////////////
            //3
            Console.WriteLine();
            Console.WriteLine("Sorting array in ascending order:");
            array.SortDesc();
            array.Show("Sorted Array (Descending):");
            array.SortAsc();
            array.Show("Sorted Array (Ascending):");
            array.SortByParam(false);
            array.Show("Sorted Array by parameter (Descending):");


        }
        
        
        
        
    }
}
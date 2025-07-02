namespace _11_Delegations
{
    public delegate int IntDelegate(int[] a);
    class CalculatingArray
    {
        public int AmountOfNegative(int[] array)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item < 0)
                {
                    count++;
                }
            }
            return count;
        }
        public int SumOfArray(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
        public int AmountOfSimple(int[] array)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item < 2) continue;
                else
                {
                   if(IssSimple(item))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public bool IssSimple(int item)
        {
            for (int i = 2; i < item/2; i++)
            {
                if (item % i == 0)
                {
                    return false;
                }
                
            }
            return true;
        }
    }
    public delegate void VoidDelegate(int[] a);
    class ChangeArray
    {
        public void ChangeToZero(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = 0;
                }
            }
        }
        public void SortArray(int[] array)
        {
            Array.Sort(array);
        }

    };
    public delegate void MenuDelegate(int[] arr);

    class Menus
    {
        
        public static void menu1(int[] arr)
        {
            Console.WriteLine();
            CalculatingArray calculatingArray = new CalculatingArray();
            IntDelegate AmountOfNegative = calculatingArray.AmountOfNegative;
            IntDelegate SumOfArray = calculatingArray.SumOfArray;
            IntDelegate AmountOfSimple = calculatingArray.AmountOfSimple;
            IntDelegate[] delegates =
            [
                AmountOfNegative,
                SumOfArray,
                AmountOfSimple
            ];

            Console.WriteLine("Write a num (0-2)");
            Console.WriteLine("0 - Amount of negative numbers in array");
            Console.WriteLine("1 - Sum of array");
            Console.WriteLine("2 - Amount of simple numbers in array");
            int user = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(delegates[user].Invoke(arr));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You entered an invalid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void menu2(int[] arr)
        {
            ChangeArray changeArray = new ChangeArray();
            VoidDelegate ChangeToZero = changeArray.ChangeToZero;
            VoidDelegate SortArray = changeArray.SortArray;
            VoidDelegate[] voidDelegates =
            [
                ChangeToZero,
                SortArray
            ];
            Console.WriteLine("Write a num (0-1)");
            Console.WriteLine("0 - Change negative numbers to zero");
            Console.WriteLine("1 - Sort array");
            int user2 = int.Parse(Console.ReadLine());
            try
            {
                voidDelegates[user2].Invoke(arr);
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You entered an invalid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    internal class Program
    {
        
        public static int[] CreateArray()
        {
            Random random = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-50, 50);
            }
            return array;
        }
        

        static void Main(string[] args)
        {
            int[] arr = CreateArray();
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            try
            {
                Console.WriteLine("\n\nChoose a menu:\n1 - Calculating array\n2 - Changing array");

                int menu = int.Parse(Console.ReadLine());

                MenuDelegate menu1 = Menus.menu1;
                MenuDelegate menu2 = Menus.menu2;
                MenuDelegate[] menus = [menu1, menu2];
                menus[menu-1].Invoke(arr);
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid number format.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You entered an invalid menu number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
       

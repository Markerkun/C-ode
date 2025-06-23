namespace _05_StructRefOut

{
    //1
    class Worker
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        private int age;
        public int Age//value
        {
            get { return age; }
            set
            {
                if (value < 80)
                    age = value;
                else
                {
                    throw new ArgumentOutOfRangeException("Age cannot be more than 80.");
                }
            }
        }

        DateTime started_working;
        public DateTime Started_Working
        {
            get { return started_working; }
            set
            {
                if (value < DateTime.Now)
                    started_working = value;
                else
                    throw new ArgumentOutOfRangeException("Start date cannot be in the future.");
            }
        }
        public void Print()
        {
            Console.WriteLine($"Surname: {Surname}, Name: {Name}, Lastname: {Lastname}, Age: {Age}, Started Working: {Started_Working.ToString("dd-MM-yyyy")}.");
        }

    }

    //2
    class Calculator
    {
        public static void Add(int a, int b, out int result)
        {
            result = a + b;
        }
        public static void Sub(int a, int b, out int result)
        {
            result = a - b;
        }
        public static void Mul(int a, int b, out int result)
        {
            result = a * b;
        }
        public static void Div(int a, int b, out double result)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            result = (double)a / b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Worker[] workers = new Worker[5];

            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();
                Console.Write("Enter surname: ");
                workers[i].Surname = Console.ReadLine();
                Console.Write("Enter name: ");
                workers[i].Name = Console.ReadLine();
                Console.Write("Enter lastname: ");
                workers[i].Lastname = Console.ReadLine();
                Console.Write("Enter age: ");
                workers[i].Age = int.Parse(Console.ReadLine());
                Console.Write("Enter date of accepting to work(dd-mm-yyyy): ");
                workers[i].Started_Working = Convert.ToDateTime(Console.ReadLine());
            }
            foreach(Worker i in workers)
            {
                i.Print();
            }

            //2
            int a, b, resultInt;
            double resultDouble;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            try
            {
                Calculator.Add(a, b, out resultInt);
                Console.WriteLine($"Addition result: {resultInt}");
                
                Calculator.Sub(a, b, out resultInt);
                Console.WriteLine($"Subtraction result: {resultInt}");
                
                Calculator.Mul(a, b, out resultInt);
                Console.WriteLine($"Multiplication result: {resultInt}");
                
                Calculator.Div(a, b, out resultDouble);
                Console.WriteLine($"Division result: {resultDouble}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
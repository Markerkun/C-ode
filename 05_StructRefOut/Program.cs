namespace _05_StructRefOut

{
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




    internal class Program
    {
        static void Main(string[] args)
        {
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


        }
    }
}
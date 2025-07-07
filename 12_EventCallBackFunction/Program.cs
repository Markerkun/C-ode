//using System;

//namespace _12_EventCallBackFunction
//{

//    class Trader
//    {
//        public string Name { get; set; }
//        public string Surname { get; set; }
//        public double BalanceDollar { get; set; }
//        public double BalanceRobux { get; set; }
//        private double TotalCourse = 42;
//        public Trader(double balanceDollar, double balanceRobux, string name, string surname)
//        {
//            BalanceDollar = balanceDollar;
//            BalanceRobux = balanceRobux;
//            Name = name;
//            Surname = surname;
//        }
//        public void Reaction(double Course)
//        {
//            TotalCourse = Course;
//            if (Course < 40)
//            {
//                Console.WriteLine($"I'm selling all robux");
//                ExchangeToDollar();
//                Console.WriteLine($"I have {Math.Round(BalanceDollar, 2)} dollars and {Math.Round(BalanceRobux, 2)} robux now");
//            }
//            else if (Course > 42)
//            {
//                Console.WriteLine($"I'm selling dollar");
//                ExchangeToRobux();
//                Console.WriteLine($"I have {Math.Round(BalanceDollar, 2)} dollars and {Math.Round(BalanceRobux, 2)} robux now");
//            }
//            else
//            {
//                Console.WriteLine($"I don't care about dollar course");
//            }
//        }
//        public void ExchangeToRobux()
//        { 
//            this.BalanceRobux = this.BalanceDollar * TotalCourse;
//            BalanceDollar = 0;
//        }
//        public void ExchangeToDollar()
//        {
//            this.BalanceDollar = this.BalanceRobux / TotalCourse;
//            BalanceRobux = 0;
//        }
//    }




//    public delegate void ReactDelegate(double course);
//    class Exchange
//    {
//        public double DollarCourse { get; set; } = 42.0;

//        public event ReactDelegate Reaction;

//        public void ChangeCurrency()
//        {
//            Random random = new Random();
//            DollarCourse = random.Next(30, 50);
//            Console.WriteLine($"Dollar course changed to {DollarCourse}");
//            Reaction?.Invoke(DollarCourse);
//        }
//        public string ToString()
//        {
//            return $"Dollar course: {DollarCourse}";
//        }
//    }
//    internal class Program
//    {
//        static void Main()
//        {
//            List<Trader> traders = new List<Trader>() {
//                new Trader(100,1000, "Mukola", "Oliunuk"),
//                new Trader(50,1500, "Ira", "Oliunuk"),
//                new Trader(200,500, "Nikita", "Oliunuk"),
//                new Trader(100,2000, "Petro", "Oliunuk"),
//                new Trader(10,10000, "Olga", "Oliunuk")
//            };
//            Exchange exchange = new Exchange();
//            foreach (Trader trader in traders)
//            {
//                exchange.Reaction += trader.Reaction;
//            }
//            Console.WriteLine(exchange.ToString());
//            exchange.ChangeCurrency();
//            Console.WriteLine();
//            exchange.ChangeCurrency();
//            Console.WriteLine();
//            exchange.ChangeCurrency();
//            Console.WriteLine();
//            exchange.ChangeCurrency();
//            Console.WriteLine();

//        }
//    }
//}
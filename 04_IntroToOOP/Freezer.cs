namespace _04_IntroToOOP
{

    partial class Freezer
    {
        public double Temperature { get; set; }
        public int Capacity { get; set; }
        public string Brand { get; set; }
        public bool IsVertical { get; set; }
        public DateTime ManufactureDate { get; set; }

        public static string EnergyClass;
        public static int WarrantyYears;

        static Freezer()
        {
            EnergyClass = "A++";
            WarrantyYears = 2;
        }
        public Freezer() : this("Unknown", 0, -18.0, true, DateTime.Now) { }
        public Freezer(string brand, int capacity, double temperature, bool isVertical, DateTime manufactureDate)
        {
            Brand = brand;
            Capacity = capacity;
            Temperature = temperature;
            IsVertical = isVertical;
            ManufactureDate = manufactureDate;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}, Capacity: {Capacity}L, Temperature: {Temperature}°C, Vertical: {IsVertical}, Manufacture Date: {ManufactureDate.ToString("dd-MM-yyyy")}, Energy Class: {EnergyClass}, Warranty: {WarrantyYears} years";
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                Freezer[] freezers = new Freezer[5];
                freezers[0] = new Freezer("Samsung", 300, -20.0, true, new DateTime(2022, 1, 15));
                freezers[1] = new Freezer("LG", 250, -18.0, false, new DateTime(2021, 6, 10));
                freezers[2] = new Freezer("Whirlpool", 400, -22.0, true, new DateTime(2023, 3, 5));
                freezers[3] = new Freezer("Bosch", 350, -19.0, false, new DateTime(2020, 11, 20));
                freezers[4] = new Freezer("Electrolux", 200, -17.0, true, new DateTime(2022, 8, 30));
                foreach (Freezer i in freezers)
                {
                    Console.WriteLine(i.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}

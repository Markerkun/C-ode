namespace _16_Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password;
            string email;
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            email = Console.ReadLine();
            string emailpattern = @"^[\w\-\.]{4,}\@\w{2,}\.(com)$";
            string passwordpattern = @"^[\w\-]{6,}$";

        }
    }
}

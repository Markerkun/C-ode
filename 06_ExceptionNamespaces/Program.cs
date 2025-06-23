using System;
using System.Linq.Expressions;
using static System.Console;

//2
class CreditCard
{
    private string cardNumber;

    public string CardNumber
    {
        get { return cardNumber; }
        set
        {

                if (value.Length == 16)
                    cardNumber = value;
                else
                    throw new ArgumentException("Card number must be 16 digits long.");
          
        }
    }
    private int cvc;
    public int Cvc
    {
        get { return cvc; }
        set
        {
            
            if(value/100 > 0 && value/100 < 10)
            cvc = value;
            else
                throw new ArgumentException("CVC must be 3 digits long.");
        }
        
        
    }
    public DateTime expiryDate;
    public DateTime ExpiryDate
    {
        get { return expiryDate; }
        set
        {
            
                if (value > DateTime.Now)
                    expiryDate = value;
                else
                    throw new ArgumentException("Your card is expired.");
            
            
        }
    }

    private string pib;
    public string Pib
    { 
        
        get { return pib; }

        set
        {
            
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("PIB cannot be empty.");
                }
                else
                {
                    pib = value;

                }
            
        }
    }

    public CreditCard(string cardNumber, int cvc, DateTime expiryDate, string pib)
    {
        CardNumber = cardNumber;
        Cvc = cvc;
        ExpiryDate = expiryDate;
        Pib = pib;
    }
}

namespace _06_ExceptionNamespaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            try
            {
                WriteLine("Enter number: ");

                int num = checked(int.Parse(ReadLine()));
            }
            catch (OverflowException)
            {
                WriteLine("Your number is too big or too small for int type.");
            }
            catch (FormatException)
            {
                WriteLine("You entered an invalid number format.");
            }
            catch (Exception ex)
            {
               WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            //2

            DateTime RightDate = new DateTime(2029, 10, 5);
            try
            {
                
                CreditCard _15dig = new CreditCard("144423546529102", 432, RightDate, "geawe ytb asdd");
              
            }
            catch (FormatException)
            {
                throw new ArgumentException("Card number must contain only digits.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                CreditCard _4dig = new CreditCard("1444235465291029", 1234, RightDate, "geawe ytb asdd");
            }
            catch (FormatException)
            {
                throw new ArgumentException("Card number must contain only digits.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            //////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                DateTime FalseDate = new DateTime(2023, 10, 5);
                CreditCard Date = new CreditCard("1444235465291029", 432, FalseDate, "geawe ytb asdd");
            }
            catch (FormatException)
            {
                throw new ArgumentException("Card number must contain only digits.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            //////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                CreditCard WhiteSpaces = new CreditCard("1444235465291029", 432, RightDate, "    ");
                
            }
            catch (FormatException)
            {
                throw new ArgumentException("Card number must contain only digits.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            //////////////////////////////////////////////////////////////////////////////////////////
            CreditCard Allright = new CreditCard("1444235465291029", 432, RightDate, "geawe ytb asdd");


            //3
        }
    }
}
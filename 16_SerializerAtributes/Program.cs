﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Serialization;

namespace _16_SerializerAtributes
{
    class User
    {
        [Required]
        [Range(1000, 9999, ErrorMessage = "Wrong Id")]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        [Phone]
        public string Phone { get; set; }

        public User() {
            Id = 0;
            Login = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Email = string.Empty;
            CreditCard = string.Empty;
            Phone = string.Empty;
        }
        public User(int id, string login, string password, string confirmPassword, string email, string creditCard, string phone)
        {
            Id = id;
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
            CreditCard = creditCard;
            Phone = phone;
        }

        public void CreateUser(string filename)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter age");
            int age = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter Login");
            string login = Console.ReadLine()!;

            Console.WriteLine("Enter password");
            string password = Console.ReadLine()!;

            Console.WriteLine("Confirm password");
            string confirmPassword = Console.ReadLine()!;

            Console.WriteLine("Enter email");
            string email = Console.ReadLine()!;

            Console.WriteLine("Enter credit card");
            string creditCard = Console.ReadLine()!;

            Console.WriteLine("Enter phone");
            string phone = Console.ReadLine()!;


            Id = 1;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
            Phone = phone;
            CreditCard = creditCard;
            Login = login;

            if (!(File.Exists(filename)))
            {
                


            }

        }
        public void DisplayUser()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Login: {Login}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Credit Card: {CreditCard}");
            Console.WriteLine($"Phone: {Phone}");
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, User> users = new Dictionary<int, User>();
            User user = new User(0, "Nebula1", "1234567", "1234567", "nebula1@gmail.com", "1234567890123456", "13235325123");
            users.Add(user.Id, user);
            string fileName = "users.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                users = JsonSerializer.Deserialize<Dictionary<int, User>>(json);
            }
            else
            {
                Console.WriteLine($"File {fileName} not found, creating a new one.");
            }

            char c = ' ';
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create user");
                Console.WriteLine("2. Read users");
                Console.WriteLine("3. Update user");
                Console.WriteLine("4. Delete user");
                switch(c)
                {
                    case '1':
                        Console.WriteLine("Creating a new user...");
                        user.CreateUser(fileName);

                        break;
                    case '2':
                        // Call method to deserialize an object
                        break;
                    case '3':
                        // Call method to display serialized data
                        break;
                    case '4':
                        // Call method to exit the program
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            } while (c != '0');
        }
    }
}

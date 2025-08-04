using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace _16_SerializerAtributes
{
    [Serializable]
    public class User
    {
        [Required]
        [Range(1000, 9999, ErrorMessage = "Wrong Id")]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Login must contain only letters and digits")]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Password must contain only letters and digits")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [CreditCard(ErrorMessage = "Invalid credit card")]
        public string CreditCard { get; set; }

        private string phone;

        [Required]
        public string Phone
        {
            get { return phone; }
            set
            {
                string phonePattern = @"^\+38-0\d{2}-\d{3}-\d{2}-\d{2}$";
                if (Regex.IsMatch(value, phonePattern))
                    phone = value;
                else
                    throw new ValidationException("Phone must be in format +38-0XX-XXX-XX-XX");
            }
        }

        public void DisplayUser()
        {
            Console.WriteLine($"Id: {Id}\nLogin: {Login}\nPassword: {Password}\nEmail: {Email}\nCredit Card: {CreditCard}\nPhone: {Phone}");
        }
    }

    class Program
    {
        static Dictionary<int, User> users = new();
        const string fileName = "users.json";

        static void Main()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                users = JsonSerializer.Deserialize<Dictionary<int, User>>(json) ?? new();
            }

            while (true)
            {
                Console.WriteLine("\n1. Create user\n2. Read users\n3. Update user\n4. Delete user\n5. Save & Exit");
                char choice = Console.ReadKey(true).KeyChar;
                switch (choice)
                {
                    case '1': CreateUser(); break;
                    case '2': ReadUsers(); break;
                    case '3': UpdateUser(); break;
                    case '4': DeleteUser(); break;
                    case '5': Save(); return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void CreateUser()
        {
            var user = new User();
            while (true)
            {
                try
                {
                    Console.Write("Id: "); user.Id = int.Parse(Console.ReadLine());
                    Console.Write("Login: "); user.Login = Console.ReadLine();
                    Console.Write("Password: "); user.Password = Console.ReadLine();
                    Console.Write("Confirm Password: "); user.ConfirmPassword = Console.ReadLine();
                    Console.Write("Email: "); user.Email = Console.ReadLine();
                    Console.Write("Credit Card: "); user.CreditCard = Console.ReadLine();
                    Console.Write("Phone: "); user.Phone = Console.ReadLine();

                    var context = new ValidationContext(user);
                    Validator.ValidateObject(user, context, true);

                    if (!users.ContainsKey(user.Id))
                        users[user.Id] = user;
                    else
                        Console.WriteLine("User with this ID already exists.");
                    break;
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine("Validation error: " + ex.Message);
                }
            }
        }

        static void ReadUsers()
        {
            foreach (var user in users.Values)
                user.DisplayUser();
        }

        static void UpdateUser()
        {
            Console.Write("Enter Id to update: ");
            if (int.TryParse(Console.ReadLine(), out int id) && users.ContainsKey(id))
            {
                CreateUser();
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void DeleteUser()
        {
            Console.Write("Enter Id to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id) && users.Remove(id))
            {
                Console.WriteLine("User deleted.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void Save()
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
            Console.WriteLine("Data saved to file.");
        }
    }
}

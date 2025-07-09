//namespace _13_GBDictionary
//{
//    class Person
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }
//        public string Address { get; set; }
//        public Person(string name, int age, string address)
//        {
//            Name = name;
//            Age = age;
//            Address = address;
//        }
//        public override string ToString()
//        {
//            return $"{Name}, {Age}, {Address}";
//        }
//    }
//    class Phonebook
//    {
//        string PhoneNumber { get; set; }

//        Dictionary<string, Person> phonebook = new Dictionary<string, Person>();

//        public void Add(Person p, string phone)
//        {
//            phonebook.Add(phone, p);
//        }
//        public void Remove(string phone)
//        {
//            phonebook.Remove(phone);
//        }
//        public void ChangePhone(string p, string p1)
//        {
//            Console.WriteLine();
//            if (phonebook.ContainsKey(p))
//            {
//                Console.WriteLine($"Changing to {p1}");
//                Person person = phonebook[p];
//                phonebook.Remove(p);
//                phonebook.Add(p1, person);
//            }
//            else
//            {
//                Console.WriteLine($"Phone number {p} not found.");
//            }
//        }
//        public void ChangePerson(string p, Person p1)
//        {
//            Console.WriteLine();
//            if (phonebook.ContainsKey(p))
//            {
//                Console.WriteLine($"Changing to {p1}");
//                phonebook[p] = new Person(p1.Name, p1.Age, p1.Address);

//            }
//            else
//            {
//                Console.WriteLine($"Phone number {p} not found.");
//            }
//        }
//        public void Find(string phone)
//        {
//            Console.WriteLine();
//            if (phonebook.ContainsKey(phone))
//            {
//                Console.WriteLine($"Found: {phonebook[phone]}");
//            }
//            else
//            {
//                Console.WriteLine($"Phone number {phone} not found.");
//            }
//        }
//        public void PrintAll()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Phonebook contents:");
//            foreach (var item in phonebook)
//            {
//                Console.WriteLine($"{item.Key}: {item.Value}");
//            }
//            Console.WriteLine();
//        }

//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Person person1 = new Person("Alice", 30, "123 Main St");
//            Person person2 = new Person("Bob", 25, "456 Elm St");
//            Phonebook phonebook = new Phonebook();
//            phonebook.Add(person1, "555-1234");
//            phonebook.Add(person2, "555-5678");
//            phonebook.PrintAll();
//            phonebook.Find("555-1234");
//            phonebook.ChangePhone("555-1234", "555-0000");
//            phonebook.PrintAll();
//            phonebook.ChangePerson("555-0000", new Person("Alice Smith", 31, "789 Oak St"));
//            phonebook.PrintAll();
//            phonebook.Remove("555-5678");
//            phonebook.PrintAll();
//        }
//    }
//}

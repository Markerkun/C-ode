using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// ===== Абстрактний користувач =====
public abstract class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Score { get; set; } = 0;

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public abstract void PlayQuiz(List<Question> questions);
}

// ===== Гравець =====
public class Player : User
{
    public Player(string username, string password) : base(username, password) { }

    public override void PlayQuiz(List<Question> questions)
    {
        foreach (var q in questions)
        {
            Console.WriteLine(q.Text);
            for (int i = 0; i < q.Answers.Length; i++)
                Console.WriteLine($"{i + 1}. {q.Answers[i]}");

            Console.Write("Ваша відповідь: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int ans))
            {
                if (ans - 1 == q.CorrectAnswer)
                {
                    Console.WriteLine("✅ Правильно!");
                    Score++;
                }
                else
                {
                    Console.WriteLine($"❌ Неправильно! Правильна відповідь: {q.Answers[q.CorrectAnswer]}");
                }
            }
            else
            {
                Console.WriteLine("❌ Ви ввели не число!");
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Гра завершена! Ваш рахунок: {Score}/{questions.Count}");
    }
}

// ===== Менеджер =====
public class Manager : User
{
    private const string QuestionsFile = "questions.json";

    public Manager(string username, string password) : base(username, password) { }

    public override void PlayQuiz(List<Question> questions)
    {
        Console.WriteLine("Менеджер не грає у вікторину.");
    }

    public List<Question> LoadQuestions()
    {
        if (!File.Exists(QuestionsFile)) return new List<Question>();
        string json = File.ReadAllText(QuestionsFile);
        return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
    }

    public void SaveQuestions(List<Question> questions)
    {
        string json = JsonSerializer.Serialize(questions, new JsonSerializerOptions { WriteIndented = true });
        //WriteIndented = true означає: «Записати JSON красиво відформатованим із відступами і новими рядками»
        File.WriteAllText(QuestionsFile, json);
    }

    public void AddQuestion(List<Question> questions)
    {
        Console.Write("Текст питання: ");
        string text = Console.ReadLine();

        Console.Write("Кількість варіантів: ");
        int count = int.Parse(Console.ReadLine());

        string[] answers = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Варіант {i + 1}: ");
            answers[i] = Console.ReadLine();
        }

        Console.Write("Номер правильної відповіді: ");
        int correct = int.Parse(Console.ReadLine()) - 1;

        questions.Add(new Question(text, answers, correct));
        SaveQuestions(questions);
        Console.WriteLine("✅ Питання додано!");
    }

    public void ShowQuestions(List<Question> questions)
    {
        for (int i = 0; i < questions.Count; i++)
            Console.WriteLine($"{i + 1}. {questions[i].Text}");
    }
}

// ===== Клас користувачів для JSON =====
public class UserAccount
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// ===== Клас питання =====
public class Question
{
    public string Text { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }

    public Question() { }

    public Question(string text, string[] answers, int correctAnswer)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }
}

// ===== Основна програма =====
class Program
{
    private const string UsersFile = "users.json";

    static void Main()
    {
        Console.Write("Логін: ");
        string login = Console.ReadLine();
        Console.Write("Пароль: ");
        string password = Console.ReadLine();

        var users = LoadUsers();

        var existingUser = users.Find(u => u.Username == login);

        if (existingUser != null)
        {
            if (existingUser.Password != password)
            {
                Console.WriteLine("❌ Невірний пароль!");
                return;
            }
            Console.WriteLine("✅ Авторизація успішна!");
        }
        else
        {
            users.Add(new UserAccount { Username = login, Password = password });
            SaveUsers(users);
            Console.WriteLine("✅ Новий користувач зареєстрований!");
        }

        Console.Write("Виберіть роль (player/manager): ");
        string role = Console.ReadLine().ToLower();

        Manager manager = new Manager(login, password);
        List<Question> questions = manager.LoadQuestions();

        if (role == "player")
        {
            Player player = new Player(login, password);
            if (questions.Count == 0)
            {
                Console.WriteLine("❌ Питання ще не додані. Зверніться до менеджера.");
                return;
            }
            player.PlayQuiz(questions);
        }
        else if (role == "manager")
        {
            while (true)
            {
                Console.WriteLine("\n=== Меню менеджера ===");
                Console.WriteLine("1. Додати питання");
                Console.WriteLine("2. Переглянути питання");
                Console.WriteLine("3. Вихід");
                Console.Write("Вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": manager.AddQuestion(questions); break;
                    case "2": manager.ShowQuestions(questions); break;
                    case "3": return;
                    default: Console.WriteLine("❌ Невірний вибір."); break;
                }
            }
        }
    }

    static List<UserAccount> LoadUsers()
    {
        if (!File.Exists(UsersFile)) return new List<UserAccount>();
        string json = File.ReadAllText(UsersFile);
        return JsonSerializer.Deserialize<List<UserAccount>>(json) ?? new List<UserAccount>();
    }

    static void SaveUsers(List<UserAccount> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(UsersFile, json);
    }
}

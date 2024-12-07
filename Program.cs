using System;
using PasswordManager.Services;
using PasswordManager.Models;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordManager = new PasswordManagerService();
            
            while (true)
            {
                Console.WriteLine("\nМенеджер паролей");
                Console.WriteLine("1. Добавить пароль");
                Console.WriteLine("2. Показать все пароли");
                Console.WriteLine("3. Удалить пароль");
                Console.WriteLine("4. Выход");
                
                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewPassword(passwordManager);
                        break;
                    case "2":
                        ShowAllPasswords(passwordManager);
                        break;
                    case "3":
                        DeletePassword(passwordManager);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        private static void AddNewPassword(PasswordManagerService manager)
        {
            Console.Write("Введите название сервиса: ");
            string service = Console.ReadLine();
            Console.Write("Введите логин: ");
            string username = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            manager.AddPassword(new PasswordEntry(service, username, password));
            Console.WriteLine("Пароль успешно добавлен!");
        }

        private static void ShowAllPasswords(PasswordManagerService manager)
        {
            var entries = manager.GetAllPasswords();
            if (!entries.Any())
            {
                Console.WriteLine("Нет сохраненных паролей.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine($"\nСервис: {entry.Service}");
                Console.WriteLine($"Логин: {entry.Username}");
                Console.WriteLine($"Пароль: {entry.DecryptedPassword}");
            }
        }

        private static void DeletePassword(PasswordManagerService manager)
        {
            Console.Write("Введите название сервиса для удаления: ");
            string service = Console.ReadLine();
            if (manager.DeletePassword(service))
            {
                Console.WriteLine("Пароль успешно удален!");
            }
            else
            {
                Console.WriteLine("Пароль не найден!");
            }
        }
    }
} 
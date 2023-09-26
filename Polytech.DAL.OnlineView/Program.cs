using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polytech.DAL.model;
using polytech.DAL;
using Polytech.BLL;
using System.Configuration;
using System.Threading;

namespace Polytech.DAL.OnlineView
{
    internal class Program
    {
        static string path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static void Main(string[] args)
        {
            FirstMenu();
        }
        public static void FirstMenu()
        {
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            Console.WriteLine("3. Выход");
            Console.WriteLine("(Введите 1, 2 или 3)");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Authorization();
                    break;
                case 2:
                    Registration();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void Authorization()
        {
            Client client = new Client();
            Console.WriteLine("Введите email:");
            client.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            client.Password = Console.ReadLine();

            ServiceClient service = new ServiceClient(path);
            client = service.AuthorizationClient(client);
            if (client != null)
            {
                Console.WriteLine("С возвращением, " + client.Fname);
            }
            else
            {
                Console.WriteLine("Такой пользователь не зарегистрирован.");
                Thread.Sleep(2000);
                FirstMenu();
            }
        }
        public static void Registration()
        {
            Client client = new Client();
            Console.WriteLine("Введите email:");
            client.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            client.Password = Console.ReadLine();

            Console.WriteLine("Введите номер телефона:");
            client.Phone = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            client.Sname = Console.ReadLine();

            Console.WriteLine("Введите имя:");
            client.Fname = Console.ReadLine();

            Console.WriteLine("Введите отчество:");
            client.Lname = Console.ReadLine();

            ServiceClient service = new ServiceClient(path);
            var result = service.RegisterClient(client);

            if (result.IsError)
            {
                Console.WriteLine("возникла ошибка: {0} при создании клиента");
            }
            else
            {
                Console.WriteLine("Пользователь успешно зарегистрирован!");
            }
        }
    }
}

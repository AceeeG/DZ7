using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab
{
    internal class Program
    {
        static void DoExercise1()
        {
            Console.WriteLine("Задание 1\n");

            BankType type = BankType.Сберегательный;
            BankAccount account = new BankAccount(type);
            BankAccount account1 = new BankAccount(type);
            account.Print();
            Console.WriteLine("Команды:\n<Внести> - если хотите пополнить счёт\n<Снять> - если хотите снять деньги со счёта\n" +
                    "<Баланс> - если хотите посмотреть баланс\n<Перевести> - если хотите перевести\n<Выход> - если хотите выйти\n");

            string command;
            do
            {
                Console.WriteLine("Введите команду");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "внести":

                        Console.WriteLine("Введите сумму, которую хотите внести\n");
                        bool dep_money_flag = double.TryParse(Console.ReadLine(), out double dep_money);
                        if (!dep_money_flag)
                        {
                            do
                            {
                                Console.WriteLine("Вы не ввели число, повторите");
                                dep_money_flag = double.TryParse(Console.ReadLine(), out dep_money);
                            } while (!dep_money_flag);
                        }
                        account.DepositMoney(dep_money);
                        break;
                    case "снять":
                        Console.WriteLine("Введите сумму, которую хотите снять\n");
                        bool take_money_flag = double.TryParse(Console.ReadLine(), out double take_money);
                        if (!take_money_flag)
                        {
                            Console.WriteLine("Вы не ввели число");
                            do
                            {
                                take_money_flag = double.TryParse(Console.ReadLine(), out take_money);
                            } while (!take_money_flag);
                        }
                        account.WithdrawMoney(take_money);
                        break;
                    case "баланс":
                        account.Balance();
                        break;
                    case "перевести":
                        Console.WriteLine("Введите id пользователя\n");
                        bool id_flag = uint.TryParse(Console.ReadLine(), out uint id);
                        if (!id_flag)
                        {
                            do
                            {
                                Console.WriteLine("Вы не ввели число");
                                id_flag = uint.TryParse(Console.ReadLine(), out id);
                            } while (!id_flag);
                        }
                        Console.WriteLine("Введите сумму\n");
                        bool money_flag = double.TryParse(Console.ReadLine(), out double money);
                        if (!money_flag)
                        {
                            do
                            {
                                Console.WriteLine("Вы не ввели число");
                                money_flag = double.TryParse(Console.ReadLine(), out money);
                            } while (!money_flag);
                        }
                        account.TransferMoney(account, money, account1);
                        break;
                    case "выход":
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверную команду\n");
                        break;
                }

            } while (!command.Equals("выход"));
        }

        static string ReverseString(string text)
        {
            char[] char_arr = text.ToCharArray();
            Array.Reverse(char_arr);
            return new string(char_arr);
        }

        static void DoExercise2()
        {
            Console.WriteLine("Задание 2 - введите текст а прога его перевернет\n");
            string text = Console.ReadLine();
            Console.WriteLine($"Ваша строка: {ReverseString(text)}");
        }

        static void DoExercise3(string[] link)
        {
            string output_file = "output_file.txt";

            Console.Write("Введите название входного файла: ");
            string input_file = Console.ReadLine();

            if (File.Exists(input_file))
            {
                File.WriteAllText(output_file, File.ReadAllText(input_file).ToUpper());
                Console.WriteLine($"Текст записан заглавными буквами в файл\n{output_file}\n");
            }
            else
            {
                Console.WriteLine($"Файл {input_file} не найден!");
            }

            Console.ReadKey();
        }
        static void Main(string[] link)
        {
            Console.WriteLine("Лабораторная работа 7\n");

            //DoExercise1();
            //DoExercise2();
            //DoExercise3(link);

            Console.ReadKey();
        }
    }
}

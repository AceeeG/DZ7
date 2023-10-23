using System;
using System.Collections.Generic;
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

        static void DoExercise3()
        {
            string output_file = "output_file.txt";

            Console.Write("Введите название входного файла без .txt на конце: ");
            string input_file = Console.ReadLine() + ".txt";

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

        static void CheckIFormatable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattable_obj = obj as IFormattable;
                if (formattable_obj != null)
                {
                    Console.WriteLine("Обьект совмещается с данным типом\n");
                }
            }
            else
            {
                Console.WriteLine("Обьект не совмещается с данным типом\n");
            }
        }

        static void DoExercise4()
        {
            Console.WriteLine("Упражнение 4\n");

            object num = 34;
            CheckIFormatable(num);
        }

        static void DoHomework1()
        {
            Console.WriteLine("Домашнее задание 1\n");

            string input_file = "People.txt";
            string output_file = "Email.txt";
            List<string> file_lines = File.ReadAllLines(input_file).ToList();
            if(File.Exists(input_file))
            {
                foreach (var file_line in file_lines)
                {
                    var splitFileLine = file_line.Split(new[] { "#" }, StringSplitOptions.None);

                    string fio = splitFileLine[0];
                    string mail = splitFileLine[1];
                    using (var str1 = new StreamWriter(output_file, true))
                    {
                        str1.WriteLine(mail);
                    }
                }
                Console.WriteLine("Всё чики-пуки перенеслось\n");
            }
            else
            {
                Console.WriteLine("Ничего не получилось\n");
            }

        }

        static void DoHomework2()
        {
            Console.WriteLine("Домашнее задание 2 - заполняем плейлист и сравниваем две первые песнив");

            Song song1 = new Song();
            Song song2 = new Song();
            Song song3 = new Song();
            Song song4 = new Song();
            List<Song> list = new List<Song>() {song1, song2, song3, song4};
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FillName();
                list[i].FillAuthor();
                if (i != 0)
                {
                    list[i].previous = list[i - 1];
                }
                list[i].PrintTitle();

            }

            if (list[1].Equals(list[0]))
            {
                Console.WriteLine("Это одна песня");
            }
            else
            {
                Console.WriteLine("Это разные песни");
            }
        }

        static void Main(string[] link)
        {
            Console.WriteLine("Лабораторная работа 7\n");

            DoExercise1();
            DoExercise2();
            DoExercise3();
            DoExercise4();
            DoHomework1();
            DoHomework2();

            Console.ReadKey();
        }
    }
}

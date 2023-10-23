using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class Program
    {
        static void Answer(Task task, List<Person> employees)
        {
            task.Print();
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].name == task.GetEmployeeName())
                {
                    if (employees[i].boss.name == task.GetBossName ()) Console.WriteLine("Он будет ее делать");
                    else Console.WriteLine("Он не будет ее делать");
                }
            }
        }

        static void Main(string[] args)
        {
            Person semen = new Person("Сёмен", Department.Начальство);
            Person rashid = new Person("Рашид", Department.Начальство, semen);
            Person ilham = new Person("Ильхам", Department.Начальство, semen);
            Person lukas = new Person("Лукас", Department.Начальство, rashid);
            Person arkadiy = new Person("Аркадий", Department.Начальство, ilham);
            Person volodya = new Person("Володя", Department.Начальство, arkadiy);
            Person ilshat = new Person("Ильшат", Department.Системщик, volodya);
            Person sergey = new Person("Сергей", Department.Разработчик, volodya);
            Person ivanich = new Person("Иваныч", Department.Системщик, ilshat);
            Person ilya = new Person("Илья", Department.Системщик, ivanich);
            Person vitya = new Person("Витя", Department.Системщик, ivanich);
            Person zhenya = new Person("Витя", Department.Системщик, ivanich);
            Person laysan = new Person("Ляйсан", Department.Разработчик, sergey);
            Person marat = new Person("Марат", Department.Разработчик, laysan);
            Person dina = new Person("Дина", Department.Разработчик, laysan);
            Person ildar = new Person("Ильдар", Department.Разработчик, laysan);
            Person anton = new Person("Антон", Department.Разработчик, laysan);

            List<Person> Boss = new List<Person>() {semen, rashid, ilham, lukas, ilham, arkadiy};
            List <Person> System = new List<Person>() {ilshat, ivanich, ilya, vitya, zhenya};
            List<Person> Developement = new List<Person>() {sergey, laysan, marat, dina, ildar, anton}; 

            Task task1 = new Task(ivanich.name, Department.Системщик, "Настроить систему", zhenya.name);
            Task task2 = new Task(ilshat.name, Department.Системщик, "Устранение неполадок", ivanich.name);
            Task task3 = new Task(laysan.name, Department.Разработчик, "Подключить базу данных", anton.name);
            Task task4 = new Task(sergey.name, Department.Разработчик, "Разработать приложение", laysan.name);
            Console.WriteLine("Выберите задание\n" +
            "<Настроить систему> - нажмите 1\n" +
            "<Устранение неполадок> - нажмите 2\n" +
            "<Подключить базу данных> - нажмите 3\n" +
            "<Разработать приложение> - нажмите 4\n" +
            "<Выйти> - нажмите 5\n");
            string choise;
            do
            {
                Console.WriteLine("Выберите команду\n");
                choise = Console.ReadLine().ToLower();
                switch(choise)
                {
                    case "1":
                        Answer(task1, System);
                        break; 
                    case "2":
                        Answer(task2, System);
                        break; 
                    case "3":
                        Answer(task3, Developement);
                        break; 
                    case "4":
                        Answer(task4, Developement);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Нет такой команды\n");
                        break;

                }
            } while (choise != "5");
        }
    }
}

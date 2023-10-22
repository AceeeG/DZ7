using System;

namespace Lab
{
    enum BankType
    {
        Сберегательный,
        Зарплатный,
        Кредитный,
    }

    internal class BankAccount
    {
        private static uint id_counter = 1;
        private uint id;
        private double balance;
        private BankType type;



        /// <summary>
        /// Конструктор - создаёт банковский счёт
        /// </summary>
        /// <param name="type"></param>
        public BankAccount(BankType type)
        {
            id = id_counter;
            id_counter++;
            balance = 0.0;
            this.type = type;
        }

        /// <summary>
        /// Вносит деньги на счёт
        /// </summary>
        /// <param name="money"></param>
        public void DepositMoney(double money)
        {
            if (money > 0)
            {
                balance += money;
                Console.WriteLine($"Счёт пополнен на {money} рублей, текущий баланс {balance}\n");
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной\n");
            }
        }

        /// <summary>
        /// Снимает деньги со счёта
        /// </summary>
        /// <param name="money"></param>
        public void WithdrawMoney(double money)
        {
            if (money <= balance)
            {
                balance -= money;
                Console.WriteLine($"Со счёта снято {money} рублей, текущий баланс {balance}\n");
            }
            else
            {
                Console.WriteLine("На счёте недостаточно средств\n");
            }
        }

        public void Balance()
        {
            Console.WriteLine($"Ваш баланс {balance}\n");
        }

        /// <summary>
        /// Выводит информацию о счёте
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Номер вашего счёта: {id}\nБаланс: {balance}\nТип: {type}\n");
        }

        public void TransferMoney(BankAccount account1, double money, BankAccount account2)
        {
            account1.balance -= money;
            account2.balance += money;
            Console.WriteLine($"Вы перевели {money} рублей на счет {account2.id}, ваш баланс {account1.balance}");
        }

    }
    
}

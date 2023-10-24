using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    enum Department
    {
        Начальство,
        Системщик,
        Разработчик,
        Бухгалтер
    }

    internal class Person
    {
        private string name { get; set; }
        private Department post { get; set; }
        private Person boss { get; set; }

        public Person(string name, Department post, Person boss)
        {
            this.name = name;
            this.post = post;
            this.boss = boss;
        }

        public Person(string name, Department post)
        {
            this.name = name;
            this.post = post;
        }

        public string Name()
        { 
            return name;
        }
        public string BossName()
        {
            return boss.name;
        }
    }
}

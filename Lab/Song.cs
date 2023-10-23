using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Song
    {
        private string name;
        private string author;
        public Song previous;

        public void FillName()
        {
            Console.WriteLine("Введите название песни: ");
            name = Console.ReadLine();
            Console.WriteLine("Песня добавлена");
        }
        public void FillAuthor()
        {
            Console.WriteLine("Введите автора песни: ");
            author = Console.ReadLine();
            Console.WriteLine("Автор добавлен");
        }

        public void Previous(List<Song> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FillName();
                list[i].FillAuthor();
                if (i != 0)
                {
                    list[i].previous = list[i - 1];
                }
                else
                {
                    Console.WriteLine("Предыдущей песни нет - это первая в списке\n");
                }
                list[i].PrintTitle();

            }
        }

        public string PrintTitle()
        {
            string info = name + "" + author;
            return info;
        }

        public override bool Equals(object d)
        {
            Song song = d as Song;
            if (song != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

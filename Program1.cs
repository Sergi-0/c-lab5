using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_2
{
    class MyList<T>
    {
        private T[] list;
        public MyList(params T[] Arg)
        {
            list = new T[Arg.Length];
            for(int i = 0; i<Arg.Length; i++)
            {
                list[i] = Arg[i];
            }
        }

        public void Add(T el)
        {
            T[] new_list = new T[list.Length + 1];
            for(int i = 0; i < list.Length; i++)
            {
                new_list[i] = list[i];
            }

            new_list[list.Length] = el;
            list = new_list;
        }

        public T this[int index]
        {
            get { return list[index]; }
        }

        public int Length() => list.Length;
    }
    internal class Program1
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>(1,3,2,0,5,10,7,22);
            for (int i = 0; i < list1.Length(); i++)
            {
                Console.WriteLine(list1[i]);
            }
            Console.WriteLine($"Длинна списка равна - {list1.Length()}");
            list1.Add(33);
            for (int i = 0; i < list1.Length(); i++)
            {
                Console.WriteLine(list1[i]);
            }
            Console.WriteLine($"Длинна списка равна - {list1.Length()}");
        }
    }
}

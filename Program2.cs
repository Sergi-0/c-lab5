using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab5_3
{
    public class MyDictionary<Tkey, Tvalue>: IEnumerable<KeyValuePair<Tkey,Tvalue>>
    {
        private Tkey[] ar_k;
        private Tvalue[] ar_v;
        private int size; // количество занятых элементов. Может быть меньше размеров массивов выше.
        public MyDictionary()
        {
            ar_k = new Tkey[4]; // вначале 4, каждый раз когда мы будем доходить до конца массива, его размер будет увеличиваться вдвое. Делать это будет метод resize
            ar_v = new Tvalue[4];
            size = 0;
        }

        private void Resize()
        {
            Tkey[] new_ark_k = new Tkey[2 * size];
            Tvalue[] new_ark_v = new Tvalue[2 * size];

            for (int i = 0; i < size; i++)
            {
                new_ark_k[i] = ar_k[i];
                new_ark_v[i] = ar_v[i];
            }

            ar_k = new_ark_k;
            ar_v = new_ark_v;
        }

        public void Add(Tkey key, Tvalue val)
        {

            if (ar_k.Length == size) Resize();
            ar_k[size] = key;
            ar_v[size] = val;
            size++;
        }

        public Tvalue this[Tkey key]
        {
            get
            {
                int index = FindKey(key);
                if (index == -1) throw new IndexOutOfRangeException();
                return ar_v[index];
            }
        }

        private int FindKey(Tkey key)
        {
            for (int i = 0; i < size; i++)
            {
                if (ar_k[i].Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Size
        {
            get { return size; }
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            for(int i = 0; i < size; ++i)
            {
                yield return new KeyValuePair<Tkey, Tvalue>(ar_k[i], ar_v[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Program2
    {
        static void Main(string[] args)
        {
            MyDictionary<string, Int64> dic = new MyDictionary<string, Int64>();
            dic.Add("Пять", 5);
            dic.Add("Два", 2);
            dic.Add("Номер моей банковской карточки", 122321637234444);
            dic.Add("Пин-код к банковской карточке", 2781);
            Console.WriteLine($"Длинна словаря = {dic.Size}") ;
            dic.Add("Два + ln(1)", 2);
            Console.WriteLine($"Длинна словаря = {dic.Size}");
            Console.WriteLine(dic["Два + ln(1)"]);
            foreach (object o in dic)
            {
                Console.WriteLine(o);
            }
        }
    }

    }

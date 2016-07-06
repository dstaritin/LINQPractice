using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    public class ClientList<T>: List<T> where T: Client
    {
        public delegate int WhenAandBAreNeededToSwap(T a, T b);

        public void Print(bool permission)
        {
            Console.WriteLine("".PadRight(40, '_'));
            foreach (var obj in this)
                Console.WriteLine(obj.ClientInfo(permission));
            Console.WriteLine("".PadRight(40, '_') + "\n");
        }

        public void Swap(int index1, int index2)
        {
            T temp = this[index1];
            this[index1] = this[index2];
            this[index2] = temp;
        }


      //public void BubleSorting(Func<object, object, bool> NeedToSwap) //Better style of coding 
        public void BubbleSorting(WhenAandBAreNeededToSwap needToSwap)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < Count - 1; i++)
                {
                    if (needToSwap(this[i], this[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public static ClientList<T> CopyToClientList(IEnumerable<T> obj)
        {
            var temp = new ClientList<T>();
            foreach (var o in obj)
            {
                temp.Add(o);
            }
            return temp;
        }
    }
}

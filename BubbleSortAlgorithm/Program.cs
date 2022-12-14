using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 11, 93, 45, 98, 13, 55 };
            Order(arr);
        }
        //buradaki mantık , birbirine ardışık olan iki eleman kıyaslanır ve bu kıyasa göre yerleri
        //değiştirilir. En sonunda ortaya sıralanmış bir liste çıkar.
        public static void Order(int[] list)
        {
            int temporary = 0;
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 1; j < list.Length; j++)
                {
                    if (list[j - 1] > list[j])
                    {
                        temporary = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temporary;
                    }
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadKey();
        }
    }
}

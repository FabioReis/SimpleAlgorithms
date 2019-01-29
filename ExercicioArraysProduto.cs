using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteExercicios
{
    public class ExercicioArraysProduto
    {
        //Exemplo de inputs
        //24
        //[17 8 25 30 2 6 12 4 3]
        //Complexidade O(n*log n)
        static void Main(string[] args)
        {
            List<int[]> resultList = new List<int[]>();

            Console.WriteLine("Digite o valor final do produto:");

            int productValue = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite os valores do array separados por espaço:");

            List<int> list = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp)));
            
            GetProductArrayList(list.OrderBy(x => x).ToList(), productValue, resultList);

            PrintList(resultList);

            Console.ReadKey();
        }

        public static void GetProductArrayList(List<int> list, int value, List<int[]> resultList)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] * list[i + 1] <= value)
                {
                    GetProductArrayList(list, i + 1, list.Count - 1, i, value, resultList);
                }
            }
        }

        public static void GetProductArrayList(List<int> list, int start, int end,
            int firstIndex, int resultValue, List<int[]> resultList)
        {
            if (start <= end)
            {
                int mid = start + ((end - start) / 2);

                var product = list[mid] * list[firstIndex];

                if (product == resultValue)
                {
                    resultList.Add(new int[] { list[firstIndex], list[mid] });
                }
                else if (product > resultValue)
                {
                    GetProductArrayList(list, start, mid - 1, firstIndex, resultValue, resultList);
                }
                else
                {
                    GetProductArrayList(list, mid + 1, end, firstIndex, resultValue, resultList);
                }
            }
        }

        public static void PrintList(List<int[]> list)
        {
            foreach (var item in list)
            {
                foreach (var value in item)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine("");
            }
        }
    }
}

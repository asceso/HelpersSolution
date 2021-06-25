using System;
using System.Collections.Generic;
using System.Linq;

namespace SnilsCNC
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Считываем число

            Console.WriteLine("Enter SNILS Number (9 nums with - separator)");
            string snils = Console.ReadLine();
            string[] parts = snils.Split('-');

            #endregion
            #region Создаем список из всех чисел

            List<int> snils_nums = new List<int>();
            foreach (var item in parts)
            {
                foreach (var ch in item)
                {
                    snils_nums.Add(int.Parse(ch.ToString()));
                }
            }

            #endregion
            #region Умножаем на позицию (обратный порядок)

            List<int> snils_multiples = new List<int>();
            int position = 1;
            for (int i = snils_nums.Count - 1; i >= 0; i--)
            {
                snils_multiples.Add(snils_nums[i] * position++);
            }

            #endregion
            #region Заводим локальную переменную для расчета и считаем сумму произведений

            int snils_cnc = 0;
            int sum = snils_multiples.Sum();

            #endregion
            #region Проводим сверку числа по правилам

        checking:
            if (sum < 100)
            {
                snils_cnc = sum;
            }
            else if (sum == 100 || sum == 101)
            {
                snils_cnc = 00;
            }
            else if (sum > 101)
            {
                sum -= 101;
                goto checking;
            }

            #endregion
            #region Выводим CNC. Profit!

            Console.WriteLine("CNC is :" + snils_cnc);
            Console.ReadKey(); 

            #endregion
        }
    }
}

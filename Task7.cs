using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task7
    {
        /*
         7 Канзас сити шафл. 6 баллов.
            Реализуйте метод Shuffle, который перемешивает элементы массива в случайном порядке.
         */

        static void ShowArray(int[] array, string devider = " ")
        {
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                if (argNumber == array.Length - 1)
                {
                    devider = "\n";
                }
                Console.Write(array[argNumber] + devider);
            }
        }
        static int[] Shuffle(int[] array)
        {
            Random random = new Random();
            int[] shuffleArray = new int[array.Length];
            int nextArg;
            for (int i = 0; i < shuffleArray.Length; i++)
            {
                nextArg = array[random.Next(0, array.Length)];
                if (shuffleArray.Contains(nextArg))
                {
                    i--;
                }
                else
                {
                    shuffleArray[i] = nextArg;
                }
            }
            return shuffleArray;
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            ShowArray(array);
            ShowArray(Shuffle(array));

        }
    }
}

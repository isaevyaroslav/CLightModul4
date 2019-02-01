using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task6
    {
        /*
         6 Арсенал. 5 баллов.
            Сделайте 3 метода:
            Удаление элемента из массива.
            
            Добавление элемента в массив.
            
            Перенос одного массива в другой.
            Не используйте готовые методы!
         */
        static int[] copyArray(int[] array)
        {
            int[] arrayCopy = new int[array.Length];
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                arrayCopy[argNumber] = array[argNumber];
            }
            return arrayCopy;
        }
        static void addArrayArg(ref int[] array, int addArg)
        {
            int[] rezultArray = new int[array.Length+1];
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                rezultArray[argNumber] = array[argNumber];
            }
            rezultArray[rezultArray.Length-1] = addArg;
            array = rezultArray;
        }
        static void delArrayArg(ref int[] array, int delArgNumber)
        {
            int[] rezultArray = new int[array.Length-1];
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                if(argNumber < delArgNumber)
                {
                    rezultArray[argNumber] = array[argNumber];
                }
                else if (argNumber > delArgNumber)
                {
                    rezultArray[argNumber-1] = array[argNumber];
                }
            }
            array = rezultArray;
        }
        static void showArray(int[] array)
        {
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                Console.Write(array[argNumber]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = {1,2,3,4,5};
            showArray(array);
            Console.WriteLine("Переносим один массив в другой.");
            int[] array2 = copyArray(array);
            Console.WriteLine("Удаляем третий элемент из первого массива.");
            delArrayArg(ref array, 3);
            showArray(array);
            Console.WriteLine("Дабавляем элемент в первый массив.");
            addArrayArg(ref array, 6);
            showArray(array);
            Console.WriteLine("Второй массив:");
            showArray(array2);

        }
    }
}

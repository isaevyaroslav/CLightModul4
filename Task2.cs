using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task2
    {
        /*
         2 UIElement. 6 баллов
            Разработайте функцию, которая рисует healthbar в определённой позиции. Она также
            принимает некий закрашенный процент.
            При 40% healthbar выглядит так:
            [####_____]
         */

        static void Main(string[] args)
        {
            Console.WriteLine(getStatLine(4, 10));
        }
        static string getStatLine(int statValue, int maxValue)
        {
            return "["+string.Empty.PadLeft(statValue, '#').PadRight(maxValue, '_')+ "]";
        }
    }
}

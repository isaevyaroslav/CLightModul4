using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task3
    {
        /*
         3 ReadInt. 5 баллов.
            Написать метод который запрашивает число у пользователя (с помощью метода
            Console.ReadLine() ) и пытается сконвертировать его в тип int (с помощью int.TryParse())
            Если конвертация не удалась у пользователя запрашивается число повторно до тех пор, пока
            не будет введено верно. После ввода, который удалось преобразовать в число, число
            возвращается.
            P.S Задача решается с помощью циклов
            P.S Также в TryParse используется модфикатор параметра out
             */
        static void Main(string[] args)
        {
            WrightNumber();
        }
        static void WrightNumber()
        {
            string userString;
            int userNumber = 0;
            do
            {
                Console.Write("Введите число: ");
                userString = Console.ReadLine();
            } while (!int.TryParse(userString, out userNumber));
            Console.WriteLine("Вы ввели число: "+userNumber);
        }
    }
}

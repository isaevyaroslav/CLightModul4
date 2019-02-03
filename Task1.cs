using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task1
    {
        /*
         1 Кадровый учет. 8 баллов.
            Описать функцию заполнения массивов – досье, функцию форматированного вывода и
            функцию удаления досье. (+6 баллов за систему поиска по !фамилии!)
            Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
            Будет 2 массива: 1) фио 2) должность.
            Программа должна быть с меню, которое содержит пункты:
            1) добавить досье.
            2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в
            начале)
            3) удалить досье
            4) выход
         */
        private static string[,] namesArray = new string[0, 3];
        private static string[] positionsArray = new string[0];
        private static readonly string[,] commandsArray = 
        {
            {"add", "Добавить нового сотрудника." },
            {"del", "Удалить сотрудника." },
            {"showAll", "Показать всех сотрудников." },
            {"find", "Найти сотрудника по фамилии." },
            {"exit", "Выйти из программы." },
        };
        private static bool exit = false;
        static void Main(string[] args)
        {
            string commandName = "";
            Console.WriteLine("Добро пожаловать в базу данных сотрудников.\n");
            while (!exit)
            {
                ShowCommands();
                SetCommand(ref commandName);
                Console.Clear();
                RealizeCommand(commandName);
            }
        }
        static void RealizeCommand(string commandName)
        {
            int commandNumber;
            if(commandName != "")
            {
                commandNumber = MatrixFindRow(commandsArray, 0, commandName);
                if(commandNumber < commandsArray.GetLength(0))
                {
                    switch (commandNumber)
                    {
                        case 0:
                            SetNewWorker();
                            break;
                        case 1:
                            DelWorker();
                            break;
                        case 2:
                            ShowAllWorkers();
                            break;
                        case 3:
                            FindWorkerBySename();
                            break;
                        case 4:
                            exit = true;
                            Console.WriteLine("До свидания.\n");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        static int MatrixFindRow(string[,] matrix, int colNumber, string value)
        {
            value = value.ToLower();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if(matrix[row, colNumber].ToLower() == value)
                {
                    return row;
                }
            }
            return matrix.GetLength(0);
        }
        static void DelWorker()
        {
            Console.Write("\nВведите номер записи о сотруднике, которую хотите удалить: ");
            int workerNumber = GetRightNumber();
            ShowWorker(workerNumber);
            Console.Write("\nВы действительно хотите удалить эту запись? (y/n): ");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    DelMatrixRow(ref namesArray, workerNumber);
                    Console.WriteLine("\nЗапись удалена.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nЗапись не удалена.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            } 
        }

        static int GetRightNumber()
        {
            string userString;
            int userNumber = 0;
            do
            {
                userString = Console.ReadLine();
                if(!int.TryParse(userString, out userNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Вы ввели не число. Введите число: ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!int.TryParse(userString, out userNumber));
            return userNumber;
        }
        static void DelMatrixRow(ref string[,] matrix, int rowNumber)
        {
            string[,] newMatrix = new string[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row < rowNumber)
                    {
                        newMatrix[row, col] = matrix[row, col];
                    }
                    else if (row > rowNumber)
                    {
                        newMatrix[row-1, col] = matrix[row, col];
                    }
                    
                }
            }
            matrix = newMatrix;
        }
        static void SetNewWorker()
        {
            string[] newWorker = new string[4];
            newWorker[0] = getUserString("Введите фамилию нового сотрудника: ");
            newWorker[1] = getUserString("Введите имя нового сотрудника: ");
            newWorker[2] = getUserString("Введите отчество нового сотрудника: ");
            newWorker[3] = getUserString("Введите должность нового сотрудника: ");
            SetNewName(newWorker);
            SetNewPosition(newWorker[3]);
            Console.WriteLine("Вы добавили сотрудника: ");
            ShowWorker(namesArray.GetLength(0)-1);
        }
        static string getUserString(string task)
        {
            Console.Write(task);
            return Console.ReadLine();
        }
        static void SetNewName(string[] newWorker)
        {
            AddMatrixRow(ref namesArray, newWorker);
        }
        static void AddMatrixRow(ref string[,] matrix, string[] newRow)
        {
            if(newRow.Length >= matrix.GetLength(1))
            {
                string[,] newMatrix = new string[matrix.GetLength(0) + 1, matrix.GetLength(1)];
                for (int row = 0; row < newMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < newMatrix.GetLength(1); col++)
                    {
                        if (row >= matrix.GetLength(0))
                        {
                            newMatrix[row, col] = newRow[col];
                        }
                        else
                        {
                            newMatrix[row, col] = matrix[row, col];
                        }
                        
                    }
                }
                matrix = newMatrix;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("New row is lower then matrix. \nNew row is not added.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void SetNewPosition(string position)
        {
            AddArrayArg(ref positionsArray, position);
        }

        static void ShowWorker(int workerNumber)
        {
            Console.WriteLine(
                workerNumber+") "
                +namesArray[workerNumber, 0]+" "
                +namesArray[workerNumber, 1]+" "
                +namesArray[workerNumber, 2]+" - "
                +positionsArray[workerNumber]
            );
        }

        static void ShowAllWorkers()
        {
            for (int row = 0; row < namesArray.GetLength(0); row++)
            {
                ShowWorker(row);
            }
        }
        static void FindWorkerBySename()
        {
            Console.Write("Введите фамилию сотрудника, запись о котором хотите найти: ");
            string workersSename = Console.ReadLine();
            int workersNumber = MatrixFindRow(namesArray, 0, workersSename);
            if(workersNumber < namesArray.GetLength(0))
            {
                ShowWorker(workersNumber);
            }
            else
            {
                Console.WriteLine("Запись о сотруднике с такой фамилией не найдена.");
            }
        }

        static void ShowCommands()
        {
            Console.WriteLine("\nДоступные команды:");
            for (int commandLine = 0; commandLine < commandsArray.GetLength(0); commandLine++)
            {
                Console.WriteLine("{0} - {1}", commandsArray[commandLine, 0], commandsArray[commandLine, 1]);
            }
        }
        static void SetCommand(ref string commanndName)
        {
            Console.Write("\nВведите команду: ");
            commanndName = Console.ReadLine().ToLower();
        }
        static void AddArrayArg(ref string[] array, string addArg)
        {
            string[] rezultArray = new string[array.Length + 1];
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                rezultArray[argNumber] = array[argNumber];
            }
            rezultArray[rezultArray.Length - 1] = addArg;
            array = rezultArray;
        }
        static void DelArrayArg(ref string[] array, int delArgNumber)
        {
            string[] rezultArray = new string[array.Length - 1];
            for (int argNumber = 0; argNumber < array.Length; argNumber++)
            {
                if (argNumber < delArgNumber)
                {
                    rezultArray[argNumber] = array[argNumber];
                }
                else if (argNumber > delArgNumber)
                {
                    rezultArray[argNumber - 1] = array[argNumber];
                }
            }
            array = rezultArray;
        }
    }
}

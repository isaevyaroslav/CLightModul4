using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task8
    {
        static string getStatLine(int statValue)
        {
            return string.Empty.PadLeft(statValue, '#').PadRight(10, '_');
        }
        static void setPointsToStat(string operation, int operandPoints, ref int statValue, ref int points)
        {
            if (operation == "+")
            {
                int overhead = operandPoints - (10 - statValue);
                overhead = overhead < 0 ? 0 : overhead;
                operandPoints -= overhead;
            }
            else
            {
                int overhead = statValue - operandPoints;
                overhead = overhead < 0 ? overhead : 0;
                operandPoints += overhead;
            }

            statValue = operation == "+" ? statValue + operandPoints : statValue - operandPoints;
            points = operation == "+" ? points - operandPoints : points + operandPoints;
        }

        static int RightNumber()
        {
            string numberRaw;
            int userNumber = 0;
            do
            {
                numberRaw = Console.ReadLine();
            } while (!int.TryParse(numberRaw, out userNumber));
            return userNumber;
        }
        static void Main(string[] args)
        {
            int age = 0, strength = 0, agility = 0, intelligence = 0, points = 25;
            string strengthVisual = string.Empty, agilityVisual = string.Empty, intelligenceVisual = string.Empty;

            Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
            Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();

            while (points > 0)
            {
                Console.Clear();
                strengthVisual = string.Empty;
                agilityVisual = string.Empty;
                intelligenceVisual = string.Empty;
                strengthVisual = getStatLine(strength);
                agilityVisual = getStatLine(agility);
                intelligenceVisual = getStatLine(intelligence);
                Console.WriteLine("Поинтов - {0}", points);
                Console.WriteLine("Возраст - {0}\nСила - [{1}]\nЛовкость - [{2}]\nИнтелект - [{3}]", age, strengthVisual, agilityVisual, intelligenceVisual);

                Console.WriteLine("Какую характеристику вы хотите изменить?");
                string subject = Console.ReadLine();

                Console.WriteLine(@"Что вы хотите сделать? +\-");
                string operation = Console.ReadLine();

                Console.WriteLine(@"Колличество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");

                string operandPointsRaw = string.Empty;
                int operandPoints = RightNumber();
                switch (subject.ToLower())
                {
                    case "сила":
                        setPointsToStat(operation, operandPoints, ref strength, ref points);
                        break;
                    case "ловкость":
                        setPointsToStat(operation, operandPoints, ref agility, ref points);
                        break;
                    case "интелект":
                        setPointsToStat(operation, operandPoints, ref intelligence, ref points);
                        break;
                }
            }

            Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
            age = RightNumber();


            Console.Clear();
            strengthVisual = string.Empty;
            agilityVisual = string.Empty;
            intelligenceVisual = string.Empty;
            strengthVisual = getStatLine(strength);
            agilityVisual = getStatLine(agility);
            intelligenceVisual = getStatLine(intelligence);
            Console.WriteLine("Возраст - {0}\nСила - [{1}]\nЛовкость - [{2}]\nИнтелект - [{3}]", age, strengthVisual, agilityVisual, intelligenceVisual);
        }
    }
}

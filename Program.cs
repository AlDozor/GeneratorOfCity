using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace City_Course
{
    class Program
    {
        //static DateTime NewDate()
        //{
          
        //    Random rand = new Random();
        //    int randyear = rand.Next(1960,2015);
        //    int randmonth = rand.Next(1, 12);
        //    DateTime date = new DateTime(randyear,randmonth,rand.Next(1, DateTime.DaysInMonth(randyear, randmonth)));
        //    return date;
        //}
        //static string NewName()
        //{
        //    Random rand = new Random();
        //    Dictionary<int, string> pattern_names = new Dictionary<int, string>();
        //    Dictionary<int, string> pattern_lnames= new Dictionary<int, string>();
        //    var Names = File.ReadAllLines("names.txt",Encoding.Default);
        //    var LNames = File.ReadAllLines("lnames.txt", Encoding.Default);
        //    foreach (string e in Names)
        //    {
        //        pattern_names.Add(pattern_names.Count, e);
        //    }
        //    Names = null;
        //    foreach (string e in LNames)
        //    {
        //        pattern_lnames.Add(pattern_lnames.Count, e);
        //    }
        //    LNames = null;

        //    return pattern_names[rand.Next(0, pattern_names.Count - 1)] + ' ' + pattern_lnames[rand.Next(0, pattern_lnames.Count - 1)];

        
        static bool baseExist()
        {
            if (File.Exists("database.txt"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Person[] startMenu()
        {
            Console.WriteLine("\n\tДобрый день! Вас приветствует приложение 'Город!'\n");
            Console.WriteLine("\tВерсия программы в данный момент: 0.01\n");
            Console.WriteLine("\tРеализованный функционал: \n\t:::Генерация базы данных\n\t:::Вменяемая работа с числами до 100 000\n");
            if (baseExist())
            {
                Console.WriteLine("База уже сгенерирована! \nЖелаете создать новую? (y/n)");
                if (Misc.keyGet())
                {
                    Console.WriteLine("Укажите размер базы: ");
                    int citySize = 0;
                    while (!int.TryParse(Console.ReadLine(), out citySize) && citySize > 0){}
                    var generator = new SocialGen("names.txt", "lnames.txt");
                    Person[] dataBase = generator.GetPersons(citySize);
                    File_Work.BaseRecording(dataBase);
                    return dataBase;
                }
                else
                {
                    Person[] dataBase = File_Work.read_base();
                    return dataBase;
                }
            }
            else
            {
                Console.WriteLine("Требуется создать новую базу!");
                Console.WriteLine("Укажите размер базы: ");
                int citySize = 0;
                while (citySize == 0)
                {
                    try
                    {
                        citySize = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите правильное значение!");
                    }
                }
                var generator = new SocialGen("names.txt", "lnames.txt");
                Person[] dataBase = generator.GetPersons(citySize);
                File_Work.BaseRecording(dataBase);
                return dataBase;
            }
        }

        static void Main(string[] args)
        {
           
            Person[] dataBase;
            dataBase = startMenu();
            FormOut.Form1 example = new FormOut.Form1(dataBase);
            example.ShowDialog();
        }
    }
}

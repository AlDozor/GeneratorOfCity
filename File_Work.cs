using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace City_Course
{
    class File_Work
    {
        public static void BaseRecording(Person[] dataBase)
        {
            StreamWriter filewr = new StreamWriter("database.txt");
            foreach (var a in dataBase)
            {
                string towrite = a.FName + ' ' + a.LName + ' ' + a.birthDate.ToShortDateString();
                filewr.WriteLine(towrite);
            }
            filewr.Close();
        }
        public static Person[] read_base()
        {
            var record = File.ReadAllLines("database.txt");
            var persons = new Person[record.Length];
            
            for (int i = 0; i < record.Length; i++)
            {
                persons[i] = Person.FromString(record[i]);
            }

            return persons;
        }
    }
}

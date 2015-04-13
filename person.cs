using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace City_Course
{
    class Person
    {
        public string FName {get; private set;}
        public string LName { get; private set; }
        public DateTime birthDate { get; private set; }

        public Person(string name, string lname, DateTime date)
        {
            FName = name;
            LName = lname;
            birthDate = date;
        }

        public static Person FromString(string record)
        {
            
            var fields = record.Split(' ');
            var f_name = fields[0];
            var l_name = fields[1];
            var b_date = DateTime.Parse(fields[2]);
             
            return new Person(f_name, l_name, b_date);
        }

    }
}

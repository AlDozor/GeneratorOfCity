using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace City_Course
{
    class SocialGen
    {

        public List<string> fnames;
        public List<string> lnames;
        public Random rnd;

        public SocialGen(string fileNames, string fileLnames)
        {
            fnames = File.ReadAllLines(fileNames).Distinct().ToList();
            lnames = File.ReadAllLines(fileLnames).Distinct().ToList();
            rnd = new Random((int)DateTime.Now.Ticks);
        }
        
        public Person[] GetPersons(int count)
        {
           return Enumerable.Range(0, count).AsParallel()
                            .Select(x => new Person(fnames[rnd.Next(fnames.Count)], 
                                                    lnames[rnd.Next(lnames.Count)], 
                                                    NewDate())
                                    ).ToArray();
        }

        
        
        DateTime NewDate()
        {
            int randyear = rnd.Next(1960, 2015);
            int randmonth = rnd.Next(1, 12);
            return new DateTime(randyear, randmonth, rnd.Next(1, DateTime.DaysInMonth(randyear, randmonth)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Course
{
    class Misc
    {
        public static bool keyGet()
        {
            char key;
            key = Console.ReadKey(true).KeyChar;
            if (key == 'y' || key == 'н')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

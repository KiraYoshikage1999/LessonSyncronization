using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSyncronization
{
    public class CoffeeCup
    {
        int Temperature {  get; set; }

        string name { get; set; }

        public CoffeeCup(string otherName, int otherTemp)
        {
            name = otherName;
            Temperature = otherTemp;
        }
    }
}

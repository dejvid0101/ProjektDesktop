using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class APIAccess : IAccess
    {
        

        public static string readCountries()
        {
            
            string m = "https://world-cup-json-2018.herokuapp.com/teams/results";
            string z = "http://worldcup.sfg.io/teams/results";
            string n;
            StreamReader sw = new StreamReader("Initial.txt");
            string f = sw.ReadLine();
            string[] l = f.Split(':');

            if (l[1] == "Muško nogometno")
            {
                n = "Odabir muške reprezentacije:";

                
            }
            else
            {
                n = "Odabir ženske reprezentacije:";
                
            }
            return n;
        }

    }
}

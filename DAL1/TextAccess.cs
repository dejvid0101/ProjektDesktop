using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class TextAccess : IAccess
    {
        
        public static void writeToFile(string line)
        {
            StreamWriter sw = new StreamWriter("Initial.txt");
            using (sw)
            {


                sw.WriteLine(line);
            }

        }

        public static string fillLabel()
        {
            
            string[] l = Split(':');
            string h;
            if (l[0] == "Muško nogometno")
            {

                h = "Odabir muške reprezentacije:";

            }
            else
            {
                h = "Odabir ženske reprezentacije:";
            }
            return h;
        }

        public static IList<Team> readCountries()
        {
            IList<Team> teams=new List<Team>();
            string m = "https://world-cup-json-2018.herokuapp.com/teams/results";
            string z = "http://worldcup.sfg.io/teams/results";
            string[] l = Split(':');

            if (l[0] == "Muško nogometno")
            {
                
                teams = APIAccessTeams.GetData(m);
                
            }
            else
            {
                teams = APIAccessTeams.GetData(z);
            }
            return teams;
        }

        internal static string[] Split(char v)
        {
            
            StreamReader sw = new StreamReader("Initial.txt");
            string f = sw.ReadLine();
            string[] l = f.Split(v);
            return l;
        }

        public static string readFile(string m)
        {
            string f;
            StreamReader sw = new StreamReader(m);
            using (sw)
            {
                f = sw.ReadLine(); 
            }
            
            return f;
        }



    }
}

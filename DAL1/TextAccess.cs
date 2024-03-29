﻿using Newtonsoft.Json;
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
        
        public static void writeToFile(string line, string file)
        {
            StreamWriter sw = new StreamWriter(file);
            using (sw)
            {


                sw.WriteLine(line);
            }

        }

        public static void writeToFaves(string[] line, string file)
        {
            StreamWriter sw = new StreamWriter(file);
            using (sw)
            {
                string s = "";
                for (int i = 0; i < line.Length; i++)
                {
                    s  += line[i] + ":";
                }

                sw.WriteLine(s);
            }

        }

        public static void writeToFile2(string[] line, string file)
        {
            StreamWriter sw = new StreamWriter(file, append: true);
            using (sw)
            {
                string s = "";
                for (int i = 0; i < line.Length; i++)
                {
                    s = s + line[i] + ":";
                }

                sw.WriteLineAsync(s);
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
            
            StreamReader sw = new StreamReader(@"..\..\..\DAL1\Files\Initial.txt");
            string f = sw.ReadLine();
            string[] l = f.Split(v);
            sw.Close();
            return l;
        }

        public static string readFile(string m)
        {
            string f;
            if (!File.Exists(m))
            {
File.Create(m);
            StreamReader sw = new StreamReader(m);
            using (sw)
            {
                    f = sw.ReadLine();
            }
            sw.Close();
            } else
            {
                StreamReader sw = new StreamReader(m);
                using (sw)
                {
                    f = sw.ReadLine();
                }
                sw.Close();
            }
            


            
            return f;
        }

        public static string readFileToEnd(string m)
        {
            string f;
            if (!File.Exists(m))
            {
                File.Create(m);
                StreamReader sw = new StreamReader(m);
                using (sw)
                {
                    f = sw.ReadToEnd();
                }
                sw.Close();
            }
            else
            {
                StreamReader sw = new StreamReader(m);
                using (sw)
                {
                    f = sw.ReadToEnd();
                }
                sw.Close();
            }




            return f;
        }

        public static IList<String> readFile2(string v)
        {
            StreamReader sr = new StreamReader(v);
            IList<String> lineslist = new List<String>();
            string s;
            s = sr.ReadLine();
                lineslist.Add(s);
            sr.Close();
            return lineslist;


        }

        
    }
}

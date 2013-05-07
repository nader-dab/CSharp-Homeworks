using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public static void Main()
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            InternetBroFilter filterDepth1 = new InternetBroFilter("http://konkurs.pcmagbg.net/task-4-season-2012-2013/");

            foreach (var item1 in filterDepth1.Children)
            {
                InternetBroFilter filterDepth2 = new InternetBroFilter(item1.RealAddress);
                foreach (var item2 in filterDepth2.Children)
                {
                    InternetBroFilter filterDepth3 = new InternetBroFilter(item2.RealAddress);
                    foreach (var item3 in filterDepth3.Children)
                    {
                        sb1.AppendLine(item1.RealAddress + " " + item2.RealAddress + " " + item3.RealAddress);
                        sb2.AppendLine(item1.DisplayAddress + " " + item2.DisplayAddress + " " + item3.DisplayAddress);
                    }                    
                }
            }

            WriteToFile.WriteTextToFile(sb1.ToString(), "realLinks.txt");
            WriteToFile.WriteTextToFile(sb1.ToString(), "displayLinks.txt");
            Process.Start(Environment.CurrentDirectory + "\\" + "realLinks.txt");
            Process.Start(Environment.CurrentDirectory + "\\" + "displayLinks.txt");
        }
    }
}

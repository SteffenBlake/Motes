using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Motes
{
    class Program
    {

        static void Main(string[] a)
        {
            string p = "";

            if (a.Count() != 1)
            {
                //Parameters
                Console.WriteLine("\nMotes v1.0.1.0\nCreated by Steffen Blake\nCheck out our github @ https://github.com/SteffenBlake/Motes \n");
                Environment.Exit(00);
            } else {
                p = a[0];

                if (File.Exists(p))
                {
                    p = new StreamReader(p).ReadToEnd();
                } else
                {
                    //Parameters
                    Console.WriteLine("\nMotes v1.0.1.0\nCreated by Steffen Blake\nCheck out our github @ https://github.com/SteffenBlake/Motes \n");
                    Environment.Exit(00);
                }
            }

            List<int> test = p.UTFList();
            Functions F = new Functions(p.UTFList());
            F.Run(0);
        }


    }
}

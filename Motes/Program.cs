using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Motes
{
    class Program
    {
        static bool testing = true;
        static bool verbose = false;
        static string testfile = "test.mot";

        static void Main(string[] a)
        {
            if (a.Count() != 1 && !testing)
            {
                Console.WriteLine("Error: Incorrect paramaters count, please provide one file!");
            } else {
                string p = testing ? testfile : a[0];

                if (File.Exists(p))
                {
                    p = new StreamReader(p).ReadToEnd();
                }
                List<int> test = p.UTFList();
                Functions F = new Functions(p.UTFList(), verbose);
                F.Run(0);
            }

            Console.WriteLine("\n\nExecution complete!\n<Press any key to finish>");
            Console.ReadKey();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

                Functions F = new Functions(p.ToCharArray().Select(c => c.ToString()).ToList(), verbose);
                F.Run(0);
            }

            Console.WriteLine("\n\nExecution complete!\n<Press any key to finish>");
            Console.ReadKey();
        }


    }
}

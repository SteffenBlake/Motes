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
            if (a.Count() != 1 && !testing) {
                Console.WriteLine("Error: Incorrect paramaters count, please provide one file!");
            } else {
                string p = testing ? testfile : a[0];

                if (File.Exists(p))
                {
                    p = new StreamReader(p).ReadToEnd();
                }

                char[] q = p.ToCharArray();

                (int n,int m,int f,int y) = (0,0,0,0);
                bool c = false;
                List<int> x = new List<int>(){0};

                Dictionary<char, Action> d = new Dictionary<char, Action>();
                List<(char, int)> j = new List<(char, int)>();

                d['+'] = () => { x[n]++; if (verbose) { Console.WriteLine("Inc@" + n.ToString()); } }; 
                d['-'] = () => { x[n]--; if (verbose) { Console.WriteLine("Dec@" + n.ToString()); } };
                d['>'] = () => {
                    if (verbose) { Console.WriteLine(">@" + n.ToString()); }
                    n++;
                    if (n == x.Count) { x.Add(0); }
                };
                d['<'] = () => {
                    if (verbose) { Console.WriteLine("<@" + n.ToString()); }
                    if (n == 0) { x.Insert(0, 0); return; };
                    n--;
                };

                d['s'] = () => { (x[n], m) = (m, x[n]); if (verbose) { Console.WriteLine("Swap"); } }; //swap
                d['w'] = () => { m = x[n]; if (verbose) { Console.WriteLine("Write"); } }; //write
                d['r'] = () => { x[n] = m; if (verbose) { Console.WriteLine("Read Mem"); } }; //read
                d['?'] = () => { x[n] = f; if (verbose) { Console.WriteLine("Read Func"); } }; //readfunction

                d['^'] = () => { Console.Write(x[n].ToString()); }; //write raw
                d['*'] = () => { Console.Write((char)(x[n])); };

                d[']'] = () => { //!0 loop
                    if (m == 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for [, found " + q[y]); }
                        y--;
                        if (q[y] == ']') { t++; }
                        if (q[y] == '[') { t--; }
                    }
                };

                d[')'] = () => { //>0 loop
                    if (m > 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for (, found " + q[y]); }
                        y--;
                        if (q[y] == ')') { t++; }
                        if (q[y] == '(') { t--; }
                    }
                };

                d['}'] = () => { //<0 loop
                    if (m < 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for {, found " + q[y]); }
                        y--;
                        if (q[y] == '}') { t++; }
                        if (q[y] == '{') { t--; }
                    }
                };

                d['☺'] = () => { //declare function
                    j.Add(('☺', y));
                    y++;
                    while (!q[y].Equals('☺')) {
                        if(verbose) { Console.WriteLine("Scanning for ☺, found " + q[y]); }
                        y++; };
                };
                d['%'] = () =>
                {
                    if (!j.Any()) { return; };
                    if (verbose) { Console.WriteLine("Jmp:" + j.Last().Item1 + "=>" + j.Last().Item2); }
                    m = q[y];
                    y = j.Last().Item2;
                    j.Remove(j.Last());
                };

                d['f'] = () => { x = x.Select(v => 0).ToList(); if (verbose) { Console.WriteLine("Flush"); } }; //flush
                d['0'] = () => { n = 0; if (verbose) { Console.WriteLine("Reset"); } }; //reset

                d['#'] = () => { c = !c; }; //Commenting
                d['\n'] = () => { c = false; }; //end comments on newline
                d['v'] = () => { Console.WriteLine(); }; //Newline
                d['!'] = () => { Console.ReadKey();}; //Breakpoint

                while (y < q.Length)
                {
                    if (d.ContainsKey(q[y])) {
                        if (!c || q[y] == '#' || q[y] == '\n')
                        {
                            d[q[y]].Invoke();
                        }
                    }
                    y++;
                }
            }

            Console.WriteLine("\n\nExecution complete!\n<Press any key to finish>");
            Console.ReadKey();
        }
    }
}

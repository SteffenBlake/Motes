using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motes
{
    class Functions
    {
        int n; int m; int f; int y;
        bool c;
        List<int> x;

        Dictionary<int, Action> d;

        List<int> q;

        public Functions(List<int> _q)
        {
            q = _q;
            c = false;
            n = 0;
            m = 0;
            f = 0;
            y = 0;
            x = new List<int>() { 0 };

            d = new Dictionary<int, Action>
            {
                [0x1F448] = () =>
                {
                    if (n == 0) { x.Insert(0, 0); return; };
                    n--;
                },
                [0x1F449] = () =>
                {
                    n++;
                    if (n == x.Count) { x.Add(0); }
                },

                [0x2714] = () =>
                { //=0 loop
                    if (m == 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        y--;
                        if (q[y] == 2714) { t++; } //todo: add testing for other loops!
                        if (q[y] == 0x1F517) { t--; }
                    }
                },

                [0x2716] = () =>
                { //!0 loop
                    if (m != 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        y--;
                        if (q[y] == 0x2716) { t++; }
                        if (q[y] == 0x1F517) { t--; }
                    }
                },

                [0x2795] = () =>
                { //>0 loop
                    if (m > 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        y--;
                        if (q[y] == 0x2795) { t++; }
                        if (q[y] == 0x1F517) { t--; }
                    }
                },

                [0x2796] = () =>
                { //<0 loop
                    if (m < 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        y--;
                        if (q[y] == 0x2796) { t++; }
                        if (q[y] == 0x1F517) { t--; }
                    }
                },

                [0x1F44D] = () => { x[n]++; }, //inc
                [0x1F44E] = () => { x[n]--; }, //dec
                [0x1F503] = () => {
                    int a = m;
                    m = x[n];
                    x[n] = a;
                    //(x[n], m) = (m, x[n]); //temporary fix until tuples are supported fully
                }, //swap
                [0x270D] = () => { m = x[n]; }, //write
                [0x1F4D6] = () => { x[n] = m; }, //read
                [0x1F300] = () => { x[n] = f; }, //readfunction
                [0x1F4AC] = () => { Console.Write((char)(x[n])); }, //write char
                [0x1F4AF] = () => { Console.Write(x[n].ToString()); }, //write raw
                [0x1F51A] = () => { n = 0; }, //reset
                [0x1F4A6] = () => { n = 0; x = new List<int>(); }, //flush
                [0x1F47B] = () => { c = !c; }, //Commenting
                [9] = () => { c = false; }, //end comments on newline
                [0x1F44C] = () => { Console.WriteLine(); }, //Newline
                [0x270B] = () => { Console.ReadKey(); }, //Breakpoint
                [0x1F3B2] = () => { x[n] = new Random().Next(0, 100); }, //random
                [0x1F4A4] = () => { System.Threading.Thread.Sleep((m / 10)); }, //sleep
                [0x1F4A9] = () => { x[n] = 0; }, //set0
                [0x267B] = () => { Console.Clear(); }, //reset screen
            };
        }

        public int Run(int a)
        {
            x[0] = a;
            Parse(ref q);
            while (y < q.Count)
            {
                if (d.ContainsKey(q[y]))
                {
                    if (!c || q[y] == 0x1F47B || q[y] == 9)
                    {
                        d[q[y]].Invoke();
                    }
                }
                y++;
            }
            y--;
            return x[n];
        }

        public void Parse(ref List<int> _q)
        {
            for (int _n = 0; _n < _q.Count; _n++)
            {
                if (_q[_n] == 0x1F4BE)
                {//save
                    int e = _q[_n + 1];
                    if (Data.MotesList.Any(m => m == e))
                    {
                        //is a emoji
                        if (d.ContainsKey(e))
                        {
                            //double declaration!
                            Console.WriteLine("Error! Attempted to define the same emoji as a function twice!");
                            Console.WriteLine("UTF: {0}", e);
                        }
                        else
                        {
                            List<int> _f = new List<int>();
                            //find the end point
                            int _t = 1;
                            int _i = _n;
                            while (_t > 0)
                            {
                                _i++;
                                if (_q[_i] == 0x1F44F)
                                {
                                    _t--;
                                }
                                else if (_q[_i] == 0x1F4BE)
                                {
                                    _t++; //encapsulate child routines
                                }
                            }
                            //cut out the function
                            _f = _q.Skip(_n+2).Take(_i - _n-1).ToList();
                            _q.RemoveRange(_n, _i - _n+1);
                            _n--;

                            //assign it
                            d[e] = () =>
                            {
                                Functions F = new Functions(_f);
                                f = F.Run(m);
                            };
                        }
                    }
                    else
                    {
                        //not an emoji!
                        Console.WriteLine("Error! Attempted to define a non-face emoji as a function!");
                        Console.WriteLine("UTF: {0}", e);
                    }
                }
            }
        }
    }
}

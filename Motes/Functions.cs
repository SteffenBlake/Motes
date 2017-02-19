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
        List<(int, int)> j;

        List<int> q;

        bool verbose;

        public Functions(List<int> _q, bool _verbose)
        {
            (q, c, n, m, f, y) = (_q, false, 0, 0, 0, 0);
            verbose = _verbose;
            x = new List<int>() { 0 };
            j = new List<(int, int)>();

            d = new Dictionary<int, Action>
            {
                ["👉".UTF()] = () =>
                {
                    if (verbose) { Console.WriteLine(">@" + n.ToString()); }
                    n++;
                    if (n == x.Count) { x.Add(0); }
                },
                ["👈".UTF()] = () =>
                {
                    if (verbose) { Console.WriteLine("<@" + n.ToString()); }
                    if (n == 0) { x.Insert(0, 0); return; };
                    n--;
                },

                ["✔".UTF()] = () =>
                { //=0 loop
                    if (m == 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "✔".UTF()) { t++; }
                        if (q[y] == "🔗".UTF()) { t--; }
                    }
                },

                ["✖".UTF()] = () =>
                { //!0 loop
                    if (m != 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "✖".UTF()) { t++; }
                        if (q[y] == "🔗".UTF()) { t--; }
                    }
                },

                ["➕".UTF()] = () =>
                { //>0 loop
                    if (m > 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "➕".UTF()) { t++; }
                        if (q[y] == "🔗".UTF()) { t--; }
                    }
                },

                ["➖".UTF()] = () =>
                { //<0 loop
                    if (m < 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "➖".UTF()) { t++; }
                        if (q[y] == "🔗".UTF()) { t--; }
                    }
                },

                ["👍".UTF()] = () => { x[n]++; if (verbose) { Console.WriteLine("Inc@" + n.ToString()); } },
                ["👎".UTF()] = () => { x[n]--; if (verbose) { Console.WriteLine("Dec@" + n.ToString()); } },
                ["🔃".UTF()] = () => { (x[n], m) = (m, x[n]); if (verbose) { Console.WriteLine("Swap"); } }, //swap
                ["✍".UTF()] = () => { m = x[n]; if (verbose) { Console.WriteLine("Write"); } }, //write
                ["📖".UTF()] = () => { x[n] = m; if (verbose) { Console.WriteLine("Read Mem"); } }, //read
                ["🌀".UTF()] = () => { x[n] = f; if (verbose) { Console.WriteLine("Read Func"); } }, //readfunction
                ["💯".UTF()] = () => { Console.Write(x[n].ToString()); }, //write raw
                ["💬".UTF()] = () => { Console.Write((char)(x[n])); },
                ["💦".UTF()] = () => { x = x.Select(v => 0).ToList(); if (verbose) { Console.WriteLine("Flush"); } }, //flush
                ["🔚".UTF()] = () => { n = 0; if (verbose) { Console.WriteLine("Reset"); } }, //reset
                ["👻".UTF()] = () => { c = !c; }, //Commenting
                [Convert.ToInt32('\n')] = () => { c = false; }, //end comments on newline
                ["👌".UTF()] = () => { Console.WriteLine(); }, //Newline
                ["✋".UTF()] = () => { Console.ReadKey(); }, //Breakpoint
                ["🎲".UTF()] = () => { x[n] = new Random().Next(0, 100); }, //random
                ["💤".UTF()] = () => { System.Threading.Thread.Sleep((m / 10)); }, //sleep
                ["💩".UTF()] = () => { x[n] = 0; }, //set0
                ["♻".UTF()] = () => { }, //reset screen
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
                    if (!c || q[y] == "#".UTF() || q[y] == Convert.ToInt32('\n'))
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
                if (_q[_n] == "💾".UTF())
                {//save
                    int e = _q[_n + 1];
                    if (Data.MotesList.Any(m => m == e))
                    {
                        //is a emoji
                        if (d.ContainsKey(e))
                        {
                            //double declaration!
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
                                if (_q[_i] == "👏".UTF())
                                {
                                    _t--;
                                }
                                else if (_q[_i] == "💾".UTF())
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
                                Functions F = new Functions(_f, verbose);
                                f = F.Run(m);
                            };
                        }
                    }
                    else
                    {
                        //tried to save not an emoji!
                    }
                }
            }
        }
    }
}

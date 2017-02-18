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

        Dictionary<string, Action> d;
        List<(string, int)> j;

        List<string> q;

        bool verbose;

        public Functions(List<string> _q, bool _verbose)
        {
            (q, c, n, m, f, y) = (_q, false, 0, 0, 0, 0);
            verbose = _verbose;
            x = new List<int>() { 0 };
            j = new List<(string, int)>();

            d = new Dictionary<string, Action>
            {
                ["👉"] = () =>
                {
                    if (verbose) { Console.WriteLine(">@" + n.ToString()); }
                    n++;
                    if (n == x.Count) { x.Add(0); }
                },
                ["👈"] = () =>
                {
                    if (verbose) { Console.WriteLine("<@" + n.ToString()); }
                    if (n == 0) { x.Insert(0, 0); return; };
                    n--;
                },

                ["✔"] = () =>
                { //=0 loop
                    if (m == 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "✔") { t++; }
                        if (q[y] == "🔗") { t--; }
                    }
                },

                ["✖"] = () =>
                { //!0 loop
                    if (m != 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "✖") { t++; }
                        if (q[y] == "🔗") { t--; }
                    }
                },

                ["➕"] = () =>
                { //>0 loop
                    if (m > 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "➕") { t++; }
                        if (q[y] == "🔗") { t--; }
                    }
                },

                ["➖"] = () =>
                { //<0 loop
                    if (m < 0) return;
                    int t = 1;
                    while (t > 0)
                    {
                        if (verbose) { Console.WriteLine("Roll Back for 🔗, found " + q[y]); }
                        y--;
                        if (q[y] == "➖") { t++; }
                        if (q[y] == "🔗") { t--; }
                    }
                },

                ["👍"] = () => { x[n]++; if (verbose) { Console.WriteLine("Inc@" + n.ToString()); } },
                ["👎"] = () => { x[n]--; if (verbose) { Console.WriteLine("Dec@" + n.ToString()); } },
                ["🔃"] = () => { (x[n], m) = (m, x[n]); if (verbose) { Console.WriteLine("Swap"); } }, //swap
                ["✍"] = () => { m = x[n]; if (verbose) { Console.WriteLine("Write"); } }, //write
                ["📖"] = () => { x[n] = m; if (verbose) { Console.WriteLine("Read Mem"); } }, //read
                ["🌀"] = () => { x[n] = f; if (verbose) { Console.WriteLine("Read Func"); } }, //readfunction
                ["💯"] = () => { Console.Write(x[n].ToString()); }, //write raw
                ["💬"] = () => { Console.Write((char)(x[n])); },
                ["💦"] = () => { x = x.Select(v => 0).ToList(); if (verbose) { Console.WriteLine("Flush"); } }, //flush
                ["🔚"] = () => { n = 0; if (verbose) { Console.WriteLine("Reset"); } }, //reset
                ["👻"] = () => { c = !c; }, //Commenting
                ['\n'.ToString()] = () => { c = false; }, //end comments on newline
                ["👌"] = () => { Console.WriteLine(); }, //Newline
                ["✋"] = () => { Console.ReadKey(); }, //Breakpoint
                ["🎲"] = () => { x[n] = new Random().Next(0, 100); }, //random
                ["💤"] = () => { System.Threading.Thread.Sleep((m / 10)); }, //sleep
                ["💩"] = () => { x[n] = 0; }, //set0
                ["♻"] = () => { }, //reset screen
            };
        }

        public int Run(int a)
        {
            x[0] = a;
            while (y < q.Count)
            {
                if (d.ContainsKey(q[y]))
                {
                    if (!c || q[y] == "#" || q[y] == '\n'.ToString())
                    {
                        d[q[y].ToString()].Invoke();
                    }
                }
                y++;
            }
            y--;
            return x[n];
        }

        public void Parse(List<string> _q)
        {
            for (int _n = 0; _n < _q.Count; _n++)
            {
                if (_q[_n] == "💾")
                {//save
                    if (Data.Motes.Contains(_q[_n + 1]))
                    {
                        //is a emoji
                        string e = _q[_n + 1];
                        if (d.ContainsKey(e))
                        {
                            //double declaration!
                        }
                        else
                        {
                            List<string> _f = new List<string>();
                            //cut out the function
                            int _t = 1;
                            int _i = _n;
                            while (_t > 0)
                            {
                                _i++;
                                if (_q[_i] == "👏")
                                {
                                    _t--;
                                }
                                else if (_q[_i] == "💾")
                                {
                                    _t++; //encapsulate child routines
                                }
                            }

                            _f = _q.Skip(_n).Take(_i - _n).ToList();
                            _f.Remove(_f.First()); // trim the 💾
                            _f.Remove(_f.Last()); //trim the 👏
                            _q.RemoveRange(_n, _i - _n);

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

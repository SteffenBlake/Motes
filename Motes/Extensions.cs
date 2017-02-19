using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motes
{
    static class Extensions
    {

        public static int UTF(char a, char b)
        {
            return a * 0x400 + b - 0x35FDC00;
        }

        public static bool IsEmoji(this char c)
        {
            return (c >= 0xD800 && c <= 0xD83F);
        }

        public static List<int> UTFList(this string s)
        {
            List<int> o = new List<int>();
            int n = 0;
            while (n < s.Length)
            {
                if (s[n].IsEmoji() )
                {
                    o.Add(UTF(s[n], s[n + 1]));
                    n++; //skip the surrogate pair
                }
                else
                {
                    o.Add(Convert.ToInt32(s[n]));
                }
                n++;
            }
            return o;
        }

        public static int UTF(this string s)
        {
                if (s[0] >= 0xD800 && s[0] <= 0xD83F)
                {
                    return UTF(s[0], s[1]);
                }
                else
                {
                    return Convert.ToInt32(s[0]);
                }
        }

        
    }
}

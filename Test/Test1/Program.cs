using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1 {
    class Program {
        static void Main(string[] args)
        {
            var s = new List<string>();
            s.Add("1");
            s.Add("1");
            s.Add("1");
            s.Add("1");

            var a = string.Join(",", s.ToArray());

            Console.WriteLine(a);
            Console.Read();

        }
    }
}

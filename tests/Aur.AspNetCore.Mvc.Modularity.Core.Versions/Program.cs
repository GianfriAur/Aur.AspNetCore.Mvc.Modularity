using System;
using Aur.AspNetCore.Mvc.Modularity.Core.Versions;
using Version = Aur.AspNetCore.Mvc.Modularity.Core.Versions.Version;

namespace TEST.Modularity.Core.Versions
{
    class test
    {
        static void Main(string[] args)
        {
            test t = new test();
            bool resut = t.Exec(true);
            if (resut)
                Console.WriteLine("\n\n TEST PASSED");
            else
                Console.WriteLine("\n\n TEST NOT PASSED!!!");
            Console.ReadLine();
        }

        public test() { }

        public bool Exec(bool display = false)
        {
            bool ret = true;
            /*
                new Version("V10.2.3");                     -> 10.2.3
                new Version("10.2.3");                      -> 10.2.3
                new Version("10.2.3a");                     -> 10.2.3 meta[2]=a
                new Version("10.2.3-prerelease");           -> 10.2.3 meta[2]=prerelease
                new Version("Version:10.2.3");              -> 10.2.3
                new Version("Version 10.2.3");              -> 10.2.3
                new Version(".10.2.3");                     -> 10.2.3
                new Version("10.2.3.2.1");                 -> 10.2.3.2.1
            */
            String[] tests = new string[] { "V10.2.3", "10.2.3", "10.2.3a", "10.2.3-prerelease", "Version:10.2.3", "Version 10.2.3", ".10.2.3", "10.2.3.2.1", "10a.2b.3c.2d.1e" };
            String[] testsr = new string[] { "10.2.3 meta: ..", "10.2.3 meta: ..", "10.2.3 meta: ..aa", "10.2.3 meta: ..-prerelease", "10.2.3 meta: ..", "10.2.3 meta: ..", "10.2.3 meta: ..", "10.2.3.2.1 meta: ....", "10.2.3.2.1 meta: a.b.c.d.e" };
            int cont = 0;
            foreach (string s in tests)
            {
                Version c = new Version(s);
                if (display)
                    Console.Write(s + " -> " + c.ToString());
                if (c.ToString() == testsr[cont])
                {
                    if (display)
                        Console.Write(" --- OK\n");
                }
                else
                {
                    if (display)
                        Console.Write(" --- ERROR\n");
                    ret = false;
                }
                cont++;
            }
            return ret;
        }
    }
}

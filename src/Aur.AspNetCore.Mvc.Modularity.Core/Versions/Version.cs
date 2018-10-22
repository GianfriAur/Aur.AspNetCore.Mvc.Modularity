using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Aur.AspNetCore.Mvc.Modularity.Core.Versions
{
    /*
        new Version("V10.2.3");                     -> 10.2.3
        new Version("10.2.3");                      -> 10.2.3
        new Version("10.2.3a");                     -> 10.2.3 meta[2]=a
        new Version("10.2.3-prerelease");           -> 10.2.3 meta[2]=prerelease
        new Version("Version:10.2.3");              -> 10.2.3
        new Version("Version 10.2.3");              -> 10.2.3
        new Version(".10.2.3");                     -> 10.2.3
        new Version("10.2.3.2.1");                  -> 10.2.3.2.1
    */
    public class Version
    {
        public List<int> Versions;
        public List<string> meta;
        public Version(String Descriptor)
        {
            while((Descriptor[0]>'9' || Descriptor[0]<'0') && Descriptor.Length>0)
                Descriptor=Descriptor.Remove(0,1);

            List<string> t = new List<string>(Descriptor.Split('.'));
            Versions = new List<int>(t.Count);
            meta = new List<string>(t.Count);
            int j;
            foreach (string s in t)
                if (int.TryParse(s, out j))
                {
                    Versions.Add(j);
                    meta.Add("");
                }
                else
                {
                    string pint = "";
                    string pstr = "";
                    for (int i = 0; i < s.Length; i++)
                        if ((s[i] <= '9' &&  s[i] >= '0'))
                            pint += s[i];
                        else
                            pstr += s[i];
                    if (int.TryParse(pint, out j))
                        Versions.Add(j);
                    else
                        Versions.Add(0);
                    if (pstr.Length>0)
                   // if (pstr[0] == '-' || pstr[0] == '&' || pstr[0] == '/')
                  //          pstr=pstr.Remove(0);
                    meta.Add(pstr);
                }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"> Compare to {Version:to}</param>
        /// <returns>-1 some error, 0 equal, 1 {Version:to} is major, 2 {Version:to} is minor ,3 not equal but not 1 or 2</returns>
        public int Compare(Version to)
        {
            int result = 0;
            try
            {
                for (int i = 0; i < Versions.Count || i < to.Versions.Count; i++)
                    if (Versions[i] > to.Versions[i]) { result = 1; i = Versions.Count + to.Versions.Count; }
                    else if (Versions[i] > to.Versions[i]) { result = 1; i = Versions.Count + to.Versions.Count; }
                    else
                    {
                        if (meta[i] != to.meta[i]) { result = 3; i = Versions.Count + to.Versions.Count; }
                    }
            }
            catch (Exception e) { result = -1; }

            return result;
        }

        override
        public string ToString()
        {
            return String.Join(".", Versions)+" meta: "+ String.Join(".", meta);
        }
    }
}

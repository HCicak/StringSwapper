using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StringSwapper
{
    static class Program
    {
        public static int broj_slova;
        public static string slova;
        public static IEnumerable<string> lista = null;
        public static string poznato;
        public static bool validate;
        public static string[] dict = System.IO.File.ReadAllLines(@"C:\Users\Hrvoje\source\repos\StringSwapper\hr_HR.dic");
        public static string[] word_list = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static IEnumerable<string> Permutate(string source, int count)
        {
            if (source.Length == 1)
            {
                yield return source;
            }
            else if (count == 1)
            {
                for (var n = 0; n < source.Length; n++)
                {
                    yield return source.Substring(n, 1);
                }
            }
            else
            {
                for (var n = 0; n < source.Length; n++)
                    foreach (var suffix in Permutate(
                        source.Substring(0, n)
                            + source.Substring(n + 1, source.Length - n - 1), count - 1))
                    {
                        yield return source.Substring(n, 1) + suffix;
                    }
            }
        }
        public static string[] PrepareWords (string[] lines, int count)
        {
            List<string> list = new List<string>();
            string tmpstr;
            int len;
            foreach (string line in lines)
            {
                len = line.IndexOf('/');
                if (len != -1)
                {
                    tmpstr = line.Substring(0, len);
                }
                else
                {
                    tmpstr = line;
                }
                if (tmpstr.Length == count)
                {
                    list.Add(tmpstr);
                }
            }
            return list.ToArray();
        }

        public static bool IsInDictionary(string s, string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.ToLower() == s.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

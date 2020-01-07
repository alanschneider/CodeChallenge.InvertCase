using System;
using System.Linq;

namespace CodeChallenge.Target
{
    class Program
    {
        private static char[] arr = new char[128];

        private static void InitializeMapping()
        {
            for (var c = '\0'; c <= 127; ++c)
            {
                if (c >= 65 && c <= 90) arr[c] = (char)(c + 32);
                else if (c >= 97 && c <= 122) arr[c] = (char)(c - 32);
                else arr[c] = c;
            }
        }

        private static string InverseCase(string line) =>
            new string(line.ToCharArray().Select(c => arr[c]).ToArray());

        static void Main(string[] args)
        {
            InitializeMapping();

            Console.Out.NewLine = "\r\n";
            string line;

            while ((line = ReadLineTee()) == "#BEGIN")
            {
                Console.WriteLine("#READY");
                while (!(line = ReadLineTee()).StartsWith("#END")) {
                    Console.WriteLine(InverseCase(line));
                }
            }
        }

        public static string ReadLineTee()
        {
            var line = Console.In.ReadLine();
            //Console.Error.WriteLine(line);
            return line;
        }
    }
}

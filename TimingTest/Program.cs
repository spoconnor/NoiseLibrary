using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var pre = System.DateTime.Now.Ticks;
            for (int x = 1; x < 255; x = x + 50)
                for (int y = 1; y < 255; y = y + 50)
                    for (int z = 1; z < 255; z = z + 50)
                        for (uint s = 1; s < 255; s = s + 50)
                        {
                            CalcHash1(x, y, z, s);
                        }
            var post1 = System.DateTime.Now.Ticks;
            for (int x = 1; x < 255; x = x + 50)
                for (int y = 1; y < 255; y = y + 50)
                    for (int z = 1; z < 255; z = z + 50)
                        for (uint s = 1; s < 255; s = s + 50)
                        {
                            CalcHash2(x, y, z, s);
                        }
            var post2 = System.DateTime.Now.Ticks;
            Console.WriteLine($"{post1 - pre}");
            Console.WriteLine($"{post2 - post1}");
        }
        public static void CalcHash1(int x, int y, int z, uint s)
        {
            uint hash = NoiseLibrary.Hashing.hash_coords_3(x, y, z, s);
        }
        public static void CalcHash2(int x, int y, int z, uint s)
        {
            byte[] data = new byte[16] { 0, 0, 0, (byte)x, 0, 0, 0, (byte)y, 0, 0, 0, (byte)z, 0, 0, 0, (byte)s };
            hash2.ComputeHash(data);
        }
        private static FastHash hash2 = new FastHash();

        public static void Run2()
        {
            int x = 1;
            int y = 2;
            int z = 3;
            uint seed = 4;
            uint hash = NoiseLibrary.Hashing.hash_coords_3(x, y, z, seed);

        }
    }
}

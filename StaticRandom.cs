using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gp
{
    public static class StaticRandom
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Next(int min, int max)
        {
            return random.Value.Next(min, max);
        }
        public static int Next(int max)
        {
            return random.Value.Next(max);
        }
        public static double NextDouble(double minValue, double maxValue)
        {
            return random.Value.NextDouble() * (maxValue - minValue) + minValue;
        }
        public static double NextDouble()
        {
            return random.Value.NextDouble();
        }
    }
}

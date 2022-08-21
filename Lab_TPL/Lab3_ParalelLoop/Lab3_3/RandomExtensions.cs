using System;

namespace Lab3_3
{
    static class RandomExtensions
    {
        public static double NextDouble(this Random val, double from, double to) => val.NextDouble() * (to - from) + from;
    }


}

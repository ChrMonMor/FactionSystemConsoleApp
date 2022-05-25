using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactionSystemConsoleApp
{
    public static class RNG
    {
        private static readonly Random _rand = new Random();

        public static int Rand(int min, int max)
        {
            return _rand.Next(min, ++max);
        }
        public static int Dice(int size)
        {
            return _rand.Next(1, ++size);
        }
    }
}
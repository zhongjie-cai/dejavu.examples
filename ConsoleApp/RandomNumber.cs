using System;

namespace ConsoleApp
{
    public interface IRandomNumber
    {
        int Next(int maximum);
    }

    public class RandomNumber : IRandomNumber
    {
        private static readonly Random _random = new();

        public int Next(int maximum)
        {
            return _random.Next(maximum);
        }
    }
}

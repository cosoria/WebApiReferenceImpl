using System;

namespace WebApiReferenceImpl.Core.Numerics
{
    public sealed class RandomNumberGenerator 
    {
        private static readonly object _lockObject = new object();
        private static Random _random;

        private RandomNumberGenerator()
        {
            _random = new Random();
        }

        public int GetRandomNumberBetween(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static RandomNumberGenerator Instance
        {
            get
            {
                // Use nested class so its instantiated only once (slight performance gain over repeated lock)
                return Nested.instance;
            }
            set
            {
                lock (_lockObject)
                {
                    Nested.instance = value;
                }
            }
        }

        private static class Nested
        {
            static Nested() { }

            internal static RandomNumberGenerator instance = new RandomNumberGenerator();
        }
    }
}
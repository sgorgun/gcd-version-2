using System;
using System.Diagnostics;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new System.ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(a)} can't be int.MinValue.");
            }

            if (b <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            int result = 0;

            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }

            if (a > b)
            {
                return a;
            }

            if (a < b)
            {
                result = -a;
            }

            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new System.ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(a)} can't be int.MinValue.");
            }

            if (b <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            if (c <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            int result = 0;

            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }

            while (c != 0)
            {
                int t = c;
                c = a % c;
                a = t;
            }

            if (a > b)
            {
                return a;
            }

            if (a < b)
            {
                result = -a;
            }

            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            if (a == 0 && b == 0 && other == null)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(a)} can't be int.MinValue.");
            }

            if (b <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            foreach (var item in other)
            {
                if (item != 0)
                {
                    break;
                }

                if (item == other[^1] && a == 0 && b == 0)
                {
                    throw new ArgumentException($"{nameof(other)}  can't be 0 at the same time.", nameof(other));
                }
            }

            int result = 0;

            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }

            for (int i = 0; i < other.Length; i++)
            {
                while (other[i] != 0)
                {
                    int t = other[i];
                    other[i] = a % other[i];
                    a = t;
                }
            }

            if (a > b)
            {
                return a;
            }

            if (a < b)
            {
                result = -a;
            }

            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
        return MyGcdByStein(a, b);
        }

        public static int MyGcdByStein(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(a)} can't be int.MinValue.");
            }

            if (b <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }

            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int shift = 0;
            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    (b, a) = (a, b);
                }

                b -= a;
            }
            while (b != 0);

            return a << shift;
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("Three numbers cannot be 0 at the same time.");
            }

            if (a <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(a)} can't be int.MinValue.");
            }

            if (b <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)} can't be int.MinValue.");
            }

            if (c <= int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(c), $"{nameof(c)} can't be int.MinValue.");
            }

            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }

            if (c < 0)
            {
                c = -c;
            }

            if (b == 0 && c == 0)
            {
                return a;
            }

            if (a == 0 && c == 0)
            {
                return b;
            }

            if (a == 0 && b == 0)
            {
                return c;
            }

            int shift = 0;
            while (((a | b | c) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
                c >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                while ((c & 1) == 0)
                {
                    c >>= 1;
                }

                if (a > b)
                {
                    (b, a) = (a, b);
                }

                if (b > c)
                {
                    (c, b) = (b, c);
                }

                if (a > b)
                {
                    (b, a) = (a, b);
                }

                b -= a;
                c -= a;
            }
            while (b != 0 && c != 0);

            if (b == 0)
            {
                return a << shift;
            }

            return b << shift;
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            foreach (var t in other)
            {
                if (t == 1)
                {
                    return 1;
                }
            }

            int gcd = MyGcdByStein(a, b);
            for (int i = 0; i < other.Length; i++)
            {
                if (a == 0 && b == 0 && other[i] == 0)
                {
                    throw new ArgumentException("All numbers cannot be 0 at the same time.");
                }

                if (other[i] < 0)
                {
                    other[i] = -other[i];
                }

                gcd = MyGcdByStein(gcd, other[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByEuclidean(a, b);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByEuclidean(a, b, c);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByEuclidean(a, b, other);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByStein(a, b);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByStein(a, b, c);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = GetGcdByStein(a, b, other);
            stopwatch.Stop();
            elapsedTicks = stopwatch.ElapsedMilliseconds;
            return result;
        }
    }
}

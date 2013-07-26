using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    public static class Consts
    {
        public const decimal epsilon = 0.00001m;


        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            int idx = 0;
            foreach (T item in enumerable)
                handler(item, idx++);
        }

    }
}

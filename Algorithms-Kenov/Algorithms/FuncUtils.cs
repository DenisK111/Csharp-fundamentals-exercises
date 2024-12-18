using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class FuncUtils
    {
        public static Func<T2> Apply<T1, T2>(this Func<T1, T2> func, T1 value) => () => func(value);
        public static Func<T2, T3> Apply<T1, T2, T3>(this Func<T1, T2, T3> func, T1 value) => (t2) => func(value, t2);
        public static Func<T2, T3, T4> Apply<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T1 value) => (t2, t3) => func(value, t2, t3);

        public static Func<T2, T3, T4, T5> Apply<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T1 value) => (t2, t3, t4) => func(value, t2, t3, t4);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edza.SequenceExtensions
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
                action(item);
        }

        public static void NestedEach<T, T2>(this IEnumerable<T> outer,
                                             IEnumerable<T2> inner,
                                             Action<T, T2> action)
        {
            foreach (T item in outer)
                foreach (T2 item2 in inner)
                    action(item, item2);
        }

        public static void NestedEachWithOuter<T, T2>(this IEnumerable<T> inner,
                                                      IEnumerable<T2> outer,
                                                      Action<T2, T> action)
        {
            foreach (T2 item in outer)
                foreach (T item2 in inner)
                    action(item, item2);
        }

        public static IEnumerable<TOut> SequenceJoin<T, T2, TOut>(this IEnumerable<T> seq1,
                                                                  IEnumerable<T2> seq2,
                                                                  Func<T, T2, TOut> action)
        {
            IEnumerator<T> rator1 = seq1.GetEnumerator();
            IEnumerator<T2> rator2 = seq2.GetEnumerator();

            while (rator1.MoveNext() && rator2.MoveNext())
            {
                yield return action(rator1.Current, rator2.Current);
            }
        }
    }
}

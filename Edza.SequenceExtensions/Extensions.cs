using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edza.SequenceExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Simple foreach
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="this">Any collection</param>
        /// <param name="action">How to process the element</param>
        public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
                action(item);
        }

        /// <summary>
        /// Nested loop
        /// </summary>
        /// <typeparam name="T">Outer loop type</typeparam>
        /// <typeparam name="T2">Inner loop type</typeparam>
        /// <param name="outer">Outer collection</param>
        /// <param name="inner">Inner collection</param>
        /// <param name="action">How to process each pair</param>
        public static void NestedEach<T, T2>(this IEnumerable<T> outer,
                                             IEnumerable<T2> inner,
                                             Action<T, T2> action)
        {
            foreach (T item in outer)
                foreach (T2 item2 in inner)
                    action(item, item2);
        }

        /// <summary>
        /// Nested loop with the given collection as the inner
        /// </summary>
        /// <typeparam name="T">Inner loop type</typeparam>
        /// <typeparam name="T2">Outer loop type</typeparam>
        /// <param name="inner">Inner collection</param>
        /// <param name="outer">Outer collection</param>
        /// <param name="action">How to process each pair</param>
        public static void NestedEachWithOuter<T, T2>(this IEnumerable<T> inner,
                                                      IEnumerable<T2> outer,
                                                      Action<T2, T> action)
        {
            foreach (T2 item in outer)
                foreach (T item2 in inner)
                    action(item, item2);
        }

        /// <summary>
        /// Joins two sequences, also see LINQ Join
        /// </summary>
        /// <typeparam name="T">Sequence one type</typeparam>
        /// <typeparam name="T2">Sequence two type</typeparam>
        /// <typeparam name="TOut">Combined pair type</typeparam>
        /// <param name="seq1">Sequence one</param>
        /// <param name="seq2">Sequence two</param>
        /// <param name="action">How to combine the pair</param>
        /// <returns>A new combined list</returns>
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

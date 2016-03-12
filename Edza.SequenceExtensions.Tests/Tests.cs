using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Edza.SequenceExtensions.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Each()
        {
            var ints = Enumerable.Range(0, 100);
            string result1 = "", result2 = "";

            ints.Each(i => result1 += i);
            ints.ToList().ForEach(i => result2 += i);

            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void NestedEach()
        {
            var ints = Enumerable.Range(0, 10);
            var ints2 = Enumerable.Range(0, 10);
            string result1 = "", result2 = "";

            ints.NestedEach(ints2, (i, j) => result1 += $"{i.ToString()} {j.ToString()}");

            foreach (var i in ints)
                foreach (var j in ints2)
                    result2 += $"{i.ToString()} {j.ToString()}";

            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void NestedEachWithOuter()
        {
            var ints = Enumerable.Range(0, 10);
            var ints2 = Enumerable.Range(0, 10);
            string result1 = "", result2 = "";

            ints2.NestedEach(ints, (i, j) => result1 += $"{i.ToString()} {j.ToString()}");

            foreach (var i in ints2)
                foreach (var j in ints)
                    result2 += $"{i.ToString()} {j.ToString()}";

            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void SequenceJoin()
        {
            var hexChars = Enumerable.Range(0, 16).Select(num => num < 10 ? (char)('0' + num) : (char)('A' + (num - 10)));
            var hexChars2 = hexChars.Reverse();
            string result1 = "", result2 = "";

            IEnumerable<string> hexes = hexChars.SequenceJoin(hexChars2, (a, b) => $"{a}{b}");
            result1 = string.Join("", hexes);

            IEnumerable<string> hexes2 = hexChars.Join(hexChars2, a => a, b => b, (a, b) => $"{a}{b}");
            result2 = string.Join("", hexes);

            Assert.AreEqual(result1, result2);
        }
    }
}

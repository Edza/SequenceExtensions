using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
    }
}

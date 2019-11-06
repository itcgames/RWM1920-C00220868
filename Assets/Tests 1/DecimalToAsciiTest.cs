using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DecimalToAsciiTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void DecimalToAsciiMostSimplePasses()
        {
            int[] input = { };
            string expected = null;
            string result = DecimalToAscii.convert(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DecimalToAsciiSingleInt()
        {
            int[] input = { 32 };
            string expected = " ";
            string result = DecimalToAscii.convert(input);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DecimalToAsciiDoubleInt()
        {
            int[] input = { 32,33 };
            string expected = " !";
            string result = DecimalToAscii.convert(input);
            Assert.AreEqual(expected, result);
        }
    }
}

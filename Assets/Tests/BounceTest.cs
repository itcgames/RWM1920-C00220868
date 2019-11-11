using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BounceTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BounceSimplePass()
        {
            GameObject gameObject = new GameObject();
            Assert.AreNotEqual(1, 1);
        }

        [Test]
        public void BounceComplexPass()
        {
            GameObject gameObject = new GameObject();
            Assert.AreNotEqual(1, 1);
        }
    }
}

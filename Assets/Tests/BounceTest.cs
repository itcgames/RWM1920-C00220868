using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BounceTest
    {
        // A UnityTest behaves like a coroutine in Play Mode.
        [UnityTest]
        public IEnumerator BounceTestWithEnumeratorPasses()
        {
            GameObject trampoline = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TrampolineWithTear"));
            GameObject testCube = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestCube"));
            trampoline.GetComponent<Bounce>().bounceAmount = 1000;
            Vector3 initialPos = testCube.transform.position;
            yield return new WaitForSeconds(1);
            Vector3 endPos = testCube.transform.position;
            Assert.Greater(endPos.y, initialPos.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class BounceTests
    {
        GameObject trampoline;
        GameObject testCube;
        [SetUp]
        public void Setup()
        {
            trampoline = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TrampolineWithTear"));
            testCube = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestCube"));
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(trampoline);
            Object.Destroy(testCube);
        }

        [UnityTest]
        public IEnumerator ObjectWillBounceHigherWhenDroppedOnTopTrampoline()
        {
            trampoline.GetComponent<Bounce>().bounceAmount = 1000;
            Vector3 initialPos = testCube.transform.position;
            yield return new WaitForSeconds(1);
            Vector3 endPos = testCube.transform.position;
            Assert.Greater(endPos.y, initialPos.y);
        }
        [UnityTest]
        public IEnumerator ThreeBouncesTearsTrampoline()
        {
            GameObject testCube2 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestCube"));
            GameObject testCube3 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestCube"));
            trampoline.GetComponent<Bounce>().bounceAmount = 1000;
            yield return new WaitForSeconds(1);
            Assert.False(trampoline.GetComponent<Bounce>().enabled);
            Object.Destroy(testCube2);
            Object.Destroy(testCube3);
        }

        [UnityTest]
        public IEnumerator BounceSoundPlaysAfterBounce()
        {
            trampoline.GetComponent<Bounce>().bounceAmount = 100;
            yield return new WaitForSeconds(1);
            Assert.True(trampoline.GetComponent<AudioSource>().isPlaying);
        }

        [UnityTest]
        public IEnumerator BounceAnimationPlaysAfterBounce()
        {
            trampoline.GetComponent<Bounce>().bounceAmount = 100;
            Vector3 initialPos = trampoline.transform.position;
            yield return new WaitForSeconds(0.8f);
            Vector3 endPos = trampoline.transform.position;
            Assert.Less(endPos.y, initialPos.y); // squished trampoline
        }
    }
}

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTests
{


    // A Test behaves as an ordinary method
    [Test]
    public void GameManagerTestsSimplePasses()
    {
        // Use the Assert class to test conditions.
        // Use `Assert.Fail` to indicate a failure.
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GameManagerTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

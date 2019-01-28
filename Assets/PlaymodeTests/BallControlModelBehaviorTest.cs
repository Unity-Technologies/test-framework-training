using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BallControlModelBehaviorTest
{
    [UnityTest]
    public IEnumerator TestBallControlUpdate() {
        var test = new MonoBehaviourTest<BallControlTestable>();
        var gameObject = GameObject.Find("MonoBehaviourTest: " + typeof(BallControlTestable).FullName);
        var ballControl = gameObject.GetComponent<BallControlTestable>();
        ballControl.SecondsForceApplied = 2.0f;
        ballControl.Force = Vector3.up;

        yield return test;

        Assert.IsTrue(gameObject.transform.position.y > 0);
    }
}

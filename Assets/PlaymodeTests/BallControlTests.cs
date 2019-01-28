using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallControlTests
{

    private BallControl ballControlUnderTest;
    
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("BallScene", LoadSceneMode.Single);
        // Skip 2 frames to let the scene load.
        yield return null;
        yield return null;
        
        var ball = GameObject.Find("Ball");
        ballControlUnderTest = ball.GetComponent<BallControl>();
        
        ballControlUnderTest.Force = Vector3.up;
        ballControlUnderTest.SecondsForceApplied = 0.3f;
    }
    
    [UnityTest]
    public IEnumerator TestBallControlAppliesForce()
    {
        var initialPosition = ballControlUnderTest.transform.position;

        yield return new WaitForSeconds(0.3f);

        var deltaPosition = ballControlUnderTest.transform.position - initialPosition;

        Assert.IsTrue(deltaPosition.y > 0f, "Ball is pushed upwards.");
    }

    [UnityTest]
    public IEnumerator TestBallControlStopsAppliesForce()
    {
        yield return new WaitForSeconds(0.3f);

        var forceStopPosition1 = ballControlUnderTest.transform.position;
        yield return new WaitForFixedUpdate();
        var forceStopPosition2 = ballControlUnderTest.transform.position;
        var forceStopDelta = forceStopPosition2 - forceStopPosition1;

        yield return new WaitForSeconds(0.2f);

        var endPosition1 = ballControlUnderTest.transform.position;
        yield return new WaitForFixedUpdate();
        var endPosition2 = ballControlUnderTest.transform.position;
        var endPositionDelta = endPosition2 - endPosition1;

        Assert.IsTrue(endPositionDelta.y < forceStopDelta.y, "Ball should no longer be pushed upwards." + endPositionDelta.y + " < " + forceStopDelta.y);
    }

    
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;

public class SceneContentTest
{
    [UnityTest]
    public IEnumerator VerifySceneContainsBall()
    {
        EditorSceneManager.OpenScene("Assets/BallScene.unity", OpenSceneMode.Single);
        yield return null;
        yield return new EnterPlayMode();

        var ball = GameObject.Find("Ball");

        Assert.IsNotNull(ball, "No ball object found in scene.");

        var ballControl = ball.GetComponent<BallControl>();

        Assert.IsNotNull(ballControl, "The ball does not have a ball control.");
    }
}

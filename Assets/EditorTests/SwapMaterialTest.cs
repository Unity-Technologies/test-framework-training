using UnityEngine;
using NUnit.Framework;
using UnityEditor.SceneManagement;

public class SwapMaterialTest
{

    [Test]
    public void BallControl_SwapMaterialTests()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gameObject.AddComponent<Rigidbody>();
        var ballControl = gameObject.AddComponent<BallControl>();
        var renderer = gameObject.GetComponent<Renderer>();

        var material1 = new Material(Shader.Find("Specular"));
        material1.color = Color.red;
        var material2 = new Material(Shader.Find("Specular"));
        material2.color = Color.blue;

        ballControl.Materials = new[] { material1, material2 };

        ballControl.SwapMaterial();
        Assert.AreEqual(material1, renderer.sharedMaterial);

        ballControl.SwapMaterial();
        Assert.AreEqual(material2, renderer.sharedMaterial);

        ballControl.SwapMaterial();
        Assert.AreEqual(material1, renderer.sharedMaterial);
    }
}

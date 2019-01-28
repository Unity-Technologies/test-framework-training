using UnityEngine;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;

public class SwapMaterialTest
{
    private BallControl m_ballControl;
    private Renderer m_renderer;

    [SetUp]
    public void Setup()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gameObject.AddComponent<Rigidbody>();
        m_ballControl = gameObject.AddComponent<BallControl>();
        m_renderer = gameObject.GetComponent<Renderer>();
    }
    
    [Test]
    public void BallControl_SwapMaterialTests()
    {
        var material1 = new Material(Shader.Find("Specular"));
        material1.color = Color.red;
        var material2 = new Material(Shader.Find("Specular"));
        material2.color = Color.blue;

        m_ballControl.Materials = new[] { material1, material2 };

        m_ballControl.SwapMaterial();
        Assert.AreEqual(material1, m_renderer.sharedMaterial);

        m_ballControl.SwapMaterial();
        Assert.AreEqual(material2, m_renderer.sharedMaterial);

        m_ballControl.SwapMaterial();
        Assert.AreEqual(material1, m_renderer.sharedMaterial);
    }

    [Test]
    public void MallControl_SwapMaterialsError()
    {
        LogAssert.Expect(LogType.Error, "No materials available for swapping.");
        m_ballControl.SwapMaterial();
    }
}

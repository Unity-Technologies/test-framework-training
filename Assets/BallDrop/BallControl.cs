using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallControl : MonoBehaviour
{
    public Vector3 Force;
    public float SecondsForceApplied;
    public Material[] Materials;

    int materialIndex = -1;
    float startTime;

    // Use this for initialization
    void Start ()
    {
        startTime = Time.fixedTime;
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.fixedTime < startTime + SecondsForceApplied)
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.AddForceAtPosition(Force * 1000 * Time.deltaTime, transform.position);
        }
    }

    public void SwapMaterial()
    {
        if (Materials == null || Materials.Length == 0)
        {
            Debug.LogError("No materials available for swapping.");
            return;
        }
        
        materialIndex++;
        if (materialIndex >= Materials.Length)
        {
            materialIndex = 0;
        }

        var renderer = GetComponent<Renderer>();
        renderer.material = Materials[materialIndex];
    }

    public void SetBallColor(Color color)
    {
        var renderer = GetComponent<Renderer>();
        renderer.sharedMaterial.color = color;
    }

    public Color GetBallColor()
    {
        var renderer = GetComponent<Renderer>();
        return renderer.sharedMaterial.color;
    }
}

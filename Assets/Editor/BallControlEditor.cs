using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BallControl))]
public class BallControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var control = (BallControl)target;
        if (GUILayout.Button("Swap Material"))
        {
            control.SwapMaterial();
        }
    }
}
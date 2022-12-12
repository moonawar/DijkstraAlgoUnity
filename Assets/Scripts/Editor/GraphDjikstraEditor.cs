using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GraphManager))]
public class GraphDjikstraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GraphManager gm = (GraphManager)target;

        if (GUILayout.Button("Run Djikstra"))
        {
            gm.RunDjikstra();
        }
    }
}

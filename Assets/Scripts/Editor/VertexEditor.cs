using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Vertex))]
public class VertexEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Vertex vertex = (Vertex)target;

        vertex.ID = EditorGUILayout.IntField("Vertex ID", vertex.ID);
        vertex.transform.name = "Vertex " + vertex.ID;
        vertex.IDText.text = vertex.ID.ToString();
    }
}

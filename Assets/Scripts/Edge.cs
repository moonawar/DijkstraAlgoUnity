using UnityEngine;
using QuikGraph;

public class Edge : MonoBehaviour, IEdge<Vertex>
{
    public Vertex Source { get; set; }
    public Vertex Target { get; set; }
    public float Weight { get; set; }

    [SerializeField]
    private Vertex src;
    [SerializeField]
    private Vertex tgt;
    [SerializeField]
    private float weight;

    private void Awake() {
        Source = src;
        Target = tgt;
        Weight = weight;
    }

}
using System.Collections.Generic;
using UnityEngine;
using QuikGraph;
using QuikGraph.Algorithms;
using TMPro;

public class GraphManager : MonoBehaviour
{
    [SerializeField] private GameObject vertexParent;
    [SerializeField] private GameObject edgeParent;
    public string startingVertex;
    public string endingVertex;
    public List<Vertex> vertices = new List<Vertex>();
    public List<Edge> edges = new List<Edge>();
    // public AdjacencyGraph<Vertex, Edge> graph = new AdjacencyGraph<Vertex, Edge>(true);
    public UndirectedGraph<Vertex, Edge> graph = new UndirectedGraph<Vertex, Edge>();
    [SerializeField] private Color defaultEdgeColor;
    // public EdgeListGraph<Vertex, Edge> graph2 = new EdgeListGraph<Vertex, Edge>(false, true);

    private void Awake() {
        foreach (Transform child in vertexParent.transform) {
            vertices.Add(child.GetComponent<Vertex>());
            TextMeshProUGUI text = child.GetComponentInChildren<TextMeshProUGUI>();
            text.text = child.GetComponent<Vertex>().ID.ToString();
        }
        foreach (Transform child in edgeParent.transform) {
            if (child.GetComponent<Edge>() != null){
                edges.Add(child.GetComponent<Edge>());
            }
        }
    }

    private void Start() {
        foreach (Vertex vertex in vertices) {
            graph.AddVertex(vertex);
        }
        foreach (Edge edge in edges) {
            graph.AddEdge(edge);
        }
    }

    public void RunDjikstra(){
        ResetColor();
        var tryGetPath = graph.ShortestPathsDijkstra(e => e.Weight, vertices.Find(x => x.ID.ToString() == startingVertex));
        IEnumerable<Edge> path;
        if (tryGetPath(vertices.Find(x => x.ID.ToString() == endingVertex), out path)) {
            Debug.Log("Path found: " + path);
            foreach (Edge edge in path) {
                foreach (Transform child in edge.transform) {
                    child.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
        else {
            Debug.Log("No path found");
        }
    }
    private void ResetColor(){
        foreach (Edge edge in edges) {
            foreach (Transform child in edge.gameObject.transform) {
                child.GetComponent<SpriteRenderer>().color = defaultEdgeColor;
            }
        }
    }
}

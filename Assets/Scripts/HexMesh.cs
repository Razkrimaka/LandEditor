using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    private Mesh mesh;
    private List<Vector3> vertices;
    private List<int> triangles;
    private MeshCollider meshCollider;

    public void Triangulate(HexCell[] cells)
    {
        mesh.Clear();
        vertices.Clear();
        triangles.Clear();

        for (int i = 0; i<cells.Length; i++)
        {
            Triangulate(cells[i]);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

    public void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.position;
        for (int i = 0; i < 6; i++)
        {
            AddTriangle(center, center + HexMetrics.corners[i], center + HexMetrics.corners[i + 1]);
        }
    }

    private void AddTriangle (Vector3 p1, Vector3 p2, Vector3 p3)
    {
        int index = vertices.Count;
        vertices.Add(p1);
        vertices.Add(p2);
        vertices.Add(p3);

        triangles.Add(index);
        triangles.Add(index + 1);
        triangles.Add(index + 2);
    }

    private void Awake()
    {
        meshCollider = gameObject.AddComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "HexMesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    private Mesh mesh;
    private List<Vector3> vertices;
    private List<int> triangles;
    private List<Color> colors;
    private MeshCollider meshCollider;

    public void Triangulate(HexCell[] cells)
    {
        mesh.Clear();
        vertices.Clear();
        triangles.Clear();
        colors.Clear();

        for (int i = 0; i<cells.Length; i++)
        {
            Triangulate(cells[i]);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.colors = colors.ToArray();
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
    }

    public void Triangulate(HexCell cell)
    {        
        for (HexDirection currDir = 0; (int)currDir < 6; currDir++)
        {
            Triangulate(currDir, cell);            
        }         
    }

    public void Triangulate (HexDirection dir, HexCell cell)
    {
        AddTriangle(cell.Center, cell.Center + HexMetrics.corners[(int)dir], cell.Center + HexMetrics.corners[(int)dir + 1]);
        if (cell.GetNeighbor(dir) != null)
        {
            var neigborColor = cell.GetNeighbor(dir).GetColor();
            AddPointsColor(neigborColor, cell.GetColor());
        }
        else
        {
            AddPointsColor(cell.GetColor(), cell.GetColor());
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

    private void AddPointsColor (Color color, Color cellColor)
    {
        colors.Add(cellColor);
        colors.Add(color);
        colors.Add(color);
    }

    private void Awake()
    {
        meshCollider = gameObject.AddComponent<MeshCollider>();
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "HexMesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
        colors = new List<Color>();
    }

    
}

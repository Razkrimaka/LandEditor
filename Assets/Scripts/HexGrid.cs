using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField]
    private HexCell CellPrefab;

    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    private HexCell[] cells;
    private HexMesh hexMesh;

    private void Awake()
    {
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[width * height];

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[x + z * height] = CreateCell(x, z);
            }
        } 
    }

    private void Start()
    {
        hexMesh.Triangulate(cells);
    }

    private HexCell CreateCell(int x, int z)
    {
        HexCell newCell = Instantiate(CellPrefab, this.transform);
        newCell.translateCoords = HexCoordinates.FromOffsetCoordinates(x, z);
        newCell.name = $"Cell {x}/{z}";
        newCell.SetMarkText($"{newCell.translateCoords.ToString()}");

        Vector3 position;
        position.x = 10.5f * (x + z * 0.5f - z / 2);
        position.y = 0;
        position.z = 10.5f * z;

        newCell.transform.position = position;

        return newCell;
    }
}

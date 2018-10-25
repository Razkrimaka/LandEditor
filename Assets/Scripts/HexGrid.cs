using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField]
    private HexCell _cellPrefab;

    [SerializeField]
    private Toucher _toucher;

    [SerializeField]
    private int _width;

    [SerializeField]
    private int _height;

    private HexCell[] _cells;
    private HexMesh _hexMesh;

    [SerializeField]
    Color _brown;

    [SerializeField]
    Color _green;

    [SerializeField]
    Color _blue;


    private void Awake()
    {
        _hexMesh = GetComponentInChildren<HexMesh>();
        _toucher = Instantiate(_toucher);
        _toucher.TouchedCell += OnCellTouched;


        _cells = new HexCell[_width * _height];
        for (int z = 0; z < _height; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                _cells[x + z * _height] = CreateCell(x, z);
                SetNeigbor(x, z);
            }
        }
        for (int z = 0; z < _height; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                var cell = _cells[x + z * _height];
                cell.SetMarkText(cell.GetRealNeigborCount().ToString());
            }
        }

    }

    private void SetNeigbor (int x, int z)
    {
        int index = x + z * _height;
        if (x > 0)
        {
            _cells[index].SetNeighbor(_cells[index - 1], HexDirection.H9);
        }
        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                _cells[index].SetNeighbor(_cells[index - _height], HexDirection.H5);
                if (x > 0)
                {
                    _cells[index].SetNeighbor(_cells[index - _height - 1], HexDirection.H7);
                }
            }
            else
            {
                _cells[index].SetNeighbor(_cells[index - _height], HexDirection.H7);
                if (x < _height)
                {
                    _cells[index].SetNeighbor(_cells[index - _height + 1], HexDirection.H5);
                }
            }
        }
    }

    private void Start()
    {
        _hexMesh.Triangulate(_cells);
    }

    private HexCell CreateCell(int x, int z)
    {
        HexCell newCell = Instantiate(_cellPrefab, this.transform);
        newCell.translateCoords = HexCoordinates.FromOffsetCoordinates(x, z);
        newCell._color = _brown;
        newCell.name = $"Cell {newCell.translateCoords.X}/{newCell.translateCoords.Z}";
        newCell.SetMarkText($"{newCell.translateCoords.ToStringWithNewLine()}");

        Vector3 position;
        position.x = HexMetrics.innerRadius*2 * (x + z * 0.5f - z / 2);
        position.y = 0;
        position.z = HexMetrics.outerRadius * 1.5f * z;

        newCell.transform.position = position;

        return newCell;
    }


    public void OnCellTouched (object sender, HCEventArgs e )
    {
        int index = e.Coords.X + e.Coords.Z * _width + e.Coords.Z / 2;
        _cells[index].SetColor(e.TouchColor);
        Debug.Log(e.Coords);
        _hexMesh.Triangulate(_cells);

    }
}

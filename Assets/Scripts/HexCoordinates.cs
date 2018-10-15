
[System.Serializable]
public struct HexCoordinates
{
    public float X { get { return _x; } }
    public float Z { get { return _z; } }

    private float _x;
    private float _z;

    public HexCoordinates(int x, int z)
    {
        _x = x;
        _z = z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public override string ToString()
    {
        return $"{_x}/{_z}";
    }





}

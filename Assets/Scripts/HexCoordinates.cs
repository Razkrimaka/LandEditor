using UnityEngine;
[System.Serializable]
public struct HexCoordinates
{
    public int X { get { return _x; } }
    public int Y { get { return -X - Z; } }
    public int Z { get { return _z; } }

    [SerializeField]
    private int _x;
    [SerializeField]
    private int _z;

    public HexCoordinates(int x, int z)
    {
        _x = x;
        _z = z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public static HexCoordinates FromLocalPosition (Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x - y);

        if (iX + iY + iZ != 0)
        {
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x-y - iZ);

            if (dX > dY && dX > dZ)
            {
                iX = -iZ - iY;
            }
            else
            {
                if (dZ > dY)
                {

                    iZ = -iX - iY;
                }
            }
        }

        return  new HexCoordinates(iX, iZ);
    } 

    public override string ToString()
    {
        return $"x:{X}/y:{Y}/z:{Z}";
    }

    public string ToStringWithNewLine ()
    {
        return $"x:{X}\ny:{Y}\nz:{Z}";
    }





}

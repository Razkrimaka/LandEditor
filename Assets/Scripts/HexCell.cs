using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    TextMesh mark;

    [SerializeField]
    HexCell[] _neighbor;

    public Color _color;

    public HexCoordinates translateCoords;

    public void SetMarkText(string text)
    {
        mark.text = text;
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public Color GetColor ()
    {
        return _color;
    } 

    public HexCell GetNeighbor (HexDirection direction)
    {
        return _neighbor[(int)direction];
    }

    public int GetRealNeigborCount ()
    {
        int result = 0;
        for (int i=0; i<6;i++)
        {
            if (_neighbor[i]!=null)
            {
                result++;
            }
        }
        return result;
    }

    public void SetNeighbor (HexCell cell, HexDirection direction)
    {
        _neighbor[(int)direction] = cell;
        cell._neighbor[(int)direction.Reverse()] = this;
    }

    public Vector3 Center
    {
        get
        {
            return transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HexDirection
{
    H1, H3, H5, H7, H9, H11
}

public static class HexDirectionExtentions
{
    public static HexDirection Reverse (this HexDirection dir)
    {
        HexDirection result;
        switch (dir)
        {
            case HexDirection.H1:
                result = HexDirection.H7;
                break;
            case HexDirection.H3:
                result = HexDirection.H9;
                break;
            case HexDirection.H5:
                result = HexDirection.H11;
                break;
            case HexDirection.H7:
                result = HexDirection.H1;
                break;
            case HexDirection.H9:
                result = HexDirection.H3;
                break;
            case HexDirection.H11:
                result = HexDirection.H5;
                break;
            default:
                result = HexDirection.H1;
                break;
        }
        return result;
    }
}

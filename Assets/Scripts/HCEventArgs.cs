using System;
using UnityEngine;

public class HCEventArgs : EventArgs
{
    public HexCoordinates Coords { get; private set; }
    public Color TouchColor { get; private set; }

    public HCEventArgs (HexCoordinates hexCoordinates, Color touchColor)
    {
        Coords = hexCoordinates;
        TouchColor = touchColor;
    } 

}

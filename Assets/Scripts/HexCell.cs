using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    [SerializeField]
    TextMesh mark;

    public HexCoordinates translateCoords;

    public void SetMarkText  (string text)
    {
        mark.text = text;
    }


}

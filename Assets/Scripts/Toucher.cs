using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Toucher : MonoBehaviour
{
    public event EventHandler<HCEventArgs> TouchedCell;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }

    private void MouseClick ()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
        }
    }

    private void TouchCell (Vector3 position)
    {
        var coords = HexCoordinates.FromLocalPosition(position);
        TouchedCell.Invoke(this, new HCEventArgs(coords, Color.blue));
    }
}

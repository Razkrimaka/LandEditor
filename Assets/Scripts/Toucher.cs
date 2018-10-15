using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
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
        position = transform.InverseTransformPoint(position);
        Debug.Log($"Touched: {position}");
    }
}

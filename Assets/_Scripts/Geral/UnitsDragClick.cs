using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitsDragClick : MonoBehaviour
{

    Camera myCam;

    [SerializeField] RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;


    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawBox();
    }

    // Update is called once per frame
    void Update()
    {

        // When fire click
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }

        // When holding click
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawBox();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawBox();
        }

    }

    void SelectUnits()
    {
        // loop thru all the units
        foreach (GameObject unit in UnitsSelection.Instance.unitsList)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitsSelection.Instance.DragSelect(unit);
            }
        }
    }

    void DrawSelection()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        if (mouseX < startPosition.x)
        {
            //Dragging left
            selectionBox.xMin = mouseX;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            //Dragging right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = mouseX;
        }

        if (Input.mousePosition.y < startPosition.y)
        {
            // Dragging down
            selectionBox.yMin = mouseY;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            // Dragging Up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = mouseY;
        }
    }
    void DrawBox()
    {
        Vector2 boxCenter = (endPosition + startPosition) / 2;
        Vector2 boxSize = new Vector2(Mathf.Abs(endPosition.x - startPosition.x), Mathf.Abs(endPosition.y - startPosition.y));

        boxVisual.position = boxCenter;
        boxVisual.sizeDelta = boxSize;
    }
}

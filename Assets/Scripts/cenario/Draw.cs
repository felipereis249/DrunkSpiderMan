using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw: MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;

    void Start()
    {
        GameObject drawing = Instantiate(drawingPrefab);
        lineRenderer = drawing.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            FreeDraw();
        }

        if (Input.GetMouseButtonUp(1))
        {
            GameObject drawing = Instantiate(drawingPrefab);
            lineRenderer = drawing.GetComponent<LineRenderer>();
        }

    }

    void FreeDraw()
    {
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(mousePos));
    }
}
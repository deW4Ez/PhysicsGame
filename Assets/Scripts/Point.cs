using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool IsPlus;
    public MyElement PhysElement;
    public Point connectedPoint;

    private LineRenderer line;

    void Start()
    {
        PhysElement = transform.parent.gameObject.GetComponent<MyElement>();
    }

    public void DrawLine(Point second)
    {
        if (second.connectedPoint != null)
            return;

        if (line != null)
        {
            Destroy(line.gameObject);
            connectedPoint.connectedPoint = null;
            connectedPoint = null;
        }

        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.transform.SetParent(transform);
        line.SetWidth(0.2f, 0.2f);
        line.sortingOrder = 1;
        Vector3[] points = new Vector3[2];
        points[0] = new Vector3(transform.position.x, transform.position.y, -1);
        points[1] = new Vector3(second.transform.position.x, second.transform.position.y, -1);
        line.SetPositions(points);

        connectedPoint = second;
        second.connectedPoint = this;
    }

    public void ChangeColor(bool visiable)
    {
        if (visiable)
            GetComponent<SpriteRenderer>().color = new Color32(0, 22, 255, 150);
        else
            GetComponent<SpriteRenderer>().color = new Color32(0, 22, 255, 0);
    }
}

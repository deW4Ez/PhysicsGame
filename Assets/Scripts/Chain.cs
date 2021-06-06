using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    private List<Point> points = new List<Point>();
    private Queue<Point> touchedPoints = new Queue<Point>();

    private List<MyElement> instruments = new List<MyElement>();

    void Start()
    {
        foreach (var e in GameObject.FindObjectsOfType<MyElement>())
            instruments.Add(e);

        foreach (var e in GameObject.FindObjectsOfType<Point>())
            points.Add(e);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            var touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                GameObject touchedObject = hitInformation.transform.gameObject;
                Debug.Log("Touched " + touchedObject.transform.name);
                HandleTouch(touchedObject.GetComponent<Point>());
            }
            else
            {
                foreach (var e in touchedPoints)
                    e.ChangeColor(false);
                touchedPoints.Clear();
            }
        }
    }

    private void HandleTouch(Point point)
    {
        touchedPoints.Enqueue(point);
        point.ChangeColor(true);
        if (touchedPoints.Count == 2)
        {
            foreach (var e in touchedPoints)
                e.ChangeColor(false);
            touchedPoints.Dequeue().DrawLine(touchedPoints.Dequeue());
        }
    }

    public void CheckButton()
    {
        if (Check())
            Debug.Log("true");
        else
            Debug.Log("false");
    }

    private bool Check()
    {
        foreach (var e in instruments)
        {
            if (!e.Check())
                return false;
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour
{
    private Collider2D collider;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wp.z = 0;
        var touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit != null && hit.CompareTag("Tool"))
        {
            hit.transform.position = wp;
        }
    }

    private void CheckAndMove()
    {

    }
}
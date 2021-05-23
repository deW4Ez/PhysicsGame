using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{
    public Action<bool> OnToolOnRope;

    public GameObject Ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tool"))
            OnToolOnRope?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tool"))
            OnToolOnRope?.Invoke(false);
    }

    public void Cut()
    {
        this.gameObject.SetActive(false);
        Ball.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}

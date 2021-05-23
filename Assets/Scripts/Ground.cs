using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Action OnGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGrounded?.Invoke();
    }
}

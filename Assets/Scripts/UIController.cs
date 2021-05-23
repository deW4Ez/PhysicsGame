using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button ButtonCut;
    public Text TextSeconds;

    private Rope rope;
    private Ground ground;
    private bool ballIsFalling = false;
    private float startTime;

    private void Start()
    {
        ButtonCut.interactable = false;
        rope = GameObject.FindObjectOfType<Rope>();
        rope.OnToolOnRope += ChangeInteractible;
        ground = GameObject.FindObjectOfType<Ground>();
        ground.OnGrounded += StopTimer;
    }

    private void ChangeInteractible(bool isInterctible)
    {
        ButtonCut.interactable = isInterctible;
    }

    private void StopTimer()
    {
        ballIsFalling = false;
    }

    private void Update()
    {
        if (ballIsFalling)
            TextSeconds.text = Math.Round(Time.time - startTime, 2).ToString();
    }

    public void Cut()
    {
        rope.Cut();
        ballIsFalling = true;
        startTime = Time.time;
    }
}

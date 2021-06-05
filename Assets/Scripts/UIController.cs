using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button ButtonCut;
    public Text TextSeconds;
    public Text TextSpeed;
    public Button ButtonSend;
    public Text InputHeight;
    public Win Win;

    private Rope rope;
    private Ground ground;
    private bool ballIsFalling = false;
    private float startTime;
    private bool isReady;

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
        isReady = true;
    }

    private void Update()
    {
        if (ballIsFalling)
        {
            var time = Math.Round(Time.time - startTime, 1);

            TextSeconds.text = "Время: " + Math.Round(time, 0).ToString();
            TextSpeed.text = "Скорость: " + Math.Round((time * 9.8f), 1).ToString();
        }
    }

    public void Cut()
    {
        rope.Cut();
        ballIsFalling = true;
        startTime = Time.time;
    }

    public void Send()
    {
        var textInput = Double.Parse(InputHeight.text);
        var isWin = Math.Abs(textInput - 6) < 0.2f;
        if (isReady)
            Win.Check(isWin);
    }
}

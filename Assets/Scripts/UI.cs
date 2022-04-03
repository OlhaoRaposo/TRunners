using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreTxt;
    public Text fpsText;
    public Text coinsText;
    public float deltaTime;
    public int score;

    void Start()
    {
        InvokeRepeating("Points",0,.095f);

    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString ();
        coinsText.text = "COINS: " + GameManager.instance.coin;

    } 
    void Points()
    {
        GameManager.instance.score = score;
        score = score + 1;
        scoreTxt.text = "Score: " + score;
    }
}

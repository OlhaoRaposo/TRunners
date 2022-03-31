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
    public float deltaTime;
    public int score;
<<<<<<< HEAD
    public int scoreStr;

    void Start()
    {
        InvokeRepeating("Points",0,.25f);
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.01f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString ();
        Mathf.Lerp(scoreStr, score, 20 * Time.deltaTime);
        scoreTxt.text = "Score: " + score;
    }
    void Points()
    {
        score = score + 1;
=======

    void Start()
    {
        InvokeRepeating("Points",0,1);

    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString ();
    } 
    void Points()
    {
        scoreTxt.text = "Score: " + score;
>>>>>>> ObstacleGen
    }
}

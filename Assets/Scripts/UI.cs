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

    void Start()
    {
        StartCoroutine(Points());

    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString ();
    }
    IEnumerator Points()
    {
        score = score + 360;
        yield return new WaitForSeconds(1);
        scoreTxt.text = "Score: " + score;
    }
}

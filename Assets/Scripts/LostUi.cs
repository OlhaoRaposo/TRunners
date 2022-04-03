using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    
public class LostUi : MonoBehaviour
{
    public Text scoreTxt;
    public Text bestScoreTxt;
    void Start()
    {
        scoreTxt.text = "Score:" + GameManager.instance.score;
        if (GameManager.instance.bestScore < GameManager.instance.score)
        {
            bestScoreTxt.text = "New Record: " + GameManager.instance.score;
        }
        else
        {
            bestScoreTxt.text = "";
        }
    }
}

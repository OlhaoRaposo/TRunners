using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPositon;
    private bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    
    
    public float jumpForce;
    public Rigidbody player;
    void Start()
    {
        
    }
    void Update()
    {
        //InputsPC
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x == -0.5f)
            {
                return;
            }else
                transform.Translate(-0.5f,0,0);
        }else if(Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x == 0.5f)
            {
                return;
            }else
                transform.Translate(0.5f,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            player.AddForce(0,jumpForce,0);
        }
        //InputsMobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;
            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    //Move Left
                    stopTouch = true;
                    Console.WriteLine("Left");
                    if (transform.position.x == -0.5f)
                    {
                        return;
                    }else
                        transform.Translate(-0.5f,0,0);
                    
                }
                else if (Distance.x > swipeRange)
                {
                    //Move Right
                    stopTouch = true;
                    Console.WriteLine("Right");
                    if (transform.position.x == 0.5f)
                    {
                        return;
                    }else
                        transform.Translate(0.5f,0,0);
                }else if (Distance.y > swipeRange)
                {
                    //Jump
                    stopTouch = true;
                    Console.WriteLine("Jump");
                    player.AddForce(0,jumpForce,0);
                }else if (Distance.y > -swipeRange)
                {
                    //Slide
                    stopTouch = true;
                    Console.WriteLine("Slide");
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPositon = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPositon - startTouchPosition;
            
        }
    }
}

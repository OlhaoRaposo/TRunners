using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    //Variaveis Input Pc
    PlayerPos currentPos;
     public enum PlayerPos {Left, Right, Middle};
    //Variaveis Input Mobile
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPositon;
    private bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    //Stats
    public UI ui;
    private Vector3 jump;
    private Rigidbody rb;
    public float jumpForce;
    public bool firstHit;
    void Start()
    {
        //Starta Variaveis Stats/Posiçao Inicial
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        currentPos = PlayerPos.Middle;
    }
    //Check Bool isGround
    public bool isGrounded()
    {
        if (transform.position.y <= 0.01f)
            return true;
        else
            return false;
    }
    void Update()
    {
        //Chama Inputs PC
        InputsPc();
        
        //InputsMobile
        //Revisar Mobile*
        MobileInput();
        
        //Pulo &&check Ground
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                {
                    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                }
    }
    //Colisão
    private void OnCollisionEnter(Collision col)
    {
        //Var Posiçao apos HIT
        float hitPos = 0;
        if (col.gameObject.CompareTag("Obstacle"))
        {
            //TestaCondiçao Derrota
            if (firstHit == true)
            {
                //Chamar condiçao Derrota
                Debug.Log("Derrota");
            }
            //Seta Condiçoes 'First Hit'
            firstHit = true;
            hitPos = -.7f;
            //Executa FirstHit
            if (currentPos == PlayerPos.Left)
            {
                this.transform.position = new Vector3(0, transform.position.y, hitPos);
                currentPos = PlayerPos.Middle;
            }else if (currentPos == PlayerPos.Right)
            {
                this.transform.position = new Vector3(0, transform.position.y, hitPos);
                currentPos = PlayerPos.Middle;
            }else if (currentPos == PlayerPos.Middle)
            {
                int i;
                i = Random.Range(1, 3);
                if (i == 1)
                {
                    this.transform.position = new Vector3(-.5f, transform.position.y, hitPos);
                    currentPos = PlayerPos.Left;
                }else if (i == 2)
                {
                    this.transform.position = new Vector3(.5f, transform.position.y,hitPos);
                    currentPos = PlayerPos.Right;
                }
            }
        }
    }
    //InputsPC
    private void InputsPc()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentPos != PlayerPos.Left)
        {
            if (currentPos == PlayerPos.Right)
            {
                this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                currentPos = PlayerPos.Middle;
            }
            else
            {
                this.transform.position = new Vector3(-.5f, transform.position.y, transform.position.z);
                currentPos = PlayerPos.Left;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && currentPos != PlayerPos.Right)
        {
            if (currentPos == PlayerPos.Left)
            {
                this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                currentPos = PlayerPos.Middle;
            }
            else
            {
                this.transform.position = new Vector3(.5f, transform.position.y, transform.position.z);
                currentPos = PlayerPos.Right;
            }
        }
    }

    //Revisar Mobile*
    private void MobileInput()
    {
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
                    }
                    else
                        transform.Translate(-0.5f, 0, 0);
                }
                else if (Distance.x > swipeRange)
                {
                    //Move Right
                    stopTouch = true;
                    Console.WriteLine("Right");
                    if (transform.position.x == 0.5f)
                    {
                        return;
                    }
                    else
                        transform.Translate(0.5f, 0, 0);
                }
                else if (Distance.y > swipeRange)
                {
                    //Jump
                    stopTouch = true;
                    Console.WriteLine("Jump");
                    rb.AddForce(0, jumpForce, 0);
                }
                else if (Distance.y > -swipeRange)
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

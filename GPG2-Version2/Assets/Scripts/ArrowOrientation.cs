﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOrientation : MonoBehaviour
{
    public GameObject Orientateur;
    public float rotationSpeed = 10f;
    public float forceDash = 10f;
    public GameObject ball;
    bool Tir = true;
    public int Nbdash = 3;
    public int NbMonoImpuler = 3;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.RotateAround(ball.transform.position, Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);

        }

        if (Input.GetKeyDown(KeyCode.Space) && (Nbdash > 0 || Tir))
        {
            if (!Tir)
            {
                Nbdash--;
            }
            Tir = false;
            for (int i = 0; i < NbMonoImpuler; i++)
            {
                ball.GetComponent<Rigidbody>().AddForce((Orientateur.transform.position - ball.transform.position) * forceDash, ForceMode.Impulse);

            }
            Debug.Log(Nbdash);

        }

        gameObject.transform.position = ball.transform.position;
        Tir = ball.GetComponent<Ball>().IsGrounded();


    }
}

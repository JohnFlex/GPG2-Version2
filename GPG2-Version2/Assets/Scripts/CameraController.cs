using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BehindArrow;
    private Vector3 offset;
    public GameObject Positionner;
    // Start is called before the first frame update
    void Start()
    {
        
        Positionner.transform.position = BehindArrow.transform.position;
        offset = Positionner.transform.position - Ball.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Positionner.transform.position = BehindArrow.transform.position;
            offset = Positionner.transform.position - Ball.transform.position;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            Positionner.transform.RotateAround(Ball.transform.position, Vector3.up, Input.GetAxis("Mouse X")*10);
            offset = Positionner.transform.position - Ball.transform.position;
        }

        Positionner.transform.position = Ball.transform.position + offset;
        transform.position = Positionner.transform.position;
        transform.LookAt(Ball.transform);
    }
}

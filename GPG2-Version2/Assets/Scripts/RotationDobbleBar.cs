using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationDobbleBar : MonoBehaviour
{
    Transform img1;
    Transform img2;
    private bool canRun = true;
    public float speed = 5f;
    public GameObject nbDashText;
    int _NumberOfDash;
    public int NumberOfDash
    {
        get
        {
            return _NumberOfDash;
        }
        set
        {
            if (value == 2332) _NumberOfDash = 999999999;
            else if (value > 3 || value < 0) Debug.Log("Error : Number of dash out of range");
            else _NumberOfDash = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting Childs
        img1 = transform.GetChild(0);
        img2 = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        //Stopping the loop on player press A/Enter
        if (Input.GetButton("Submit"))
        {
            canRun = false;
            //Getting actual number of dashes
            NumberOfDash = Number_Of_Dash(Vector3.Distance(img1.GetChild(0).transform.position, img2.position));
            nbDashText.GetComponent<Text>().text = "You got " + NumberOfDash + " dash(es)";
        }

        //Continuig rotation while the player don't shoot
        if (canRun) DoubleRotate();

    }

    void DoubleRotate()
    //AIM: Rotate the circle and the pointer
    //Input: N/A
    //Output: N/A
    {
        img1.Rotate((Vector3.forward) * speed);
        img2.RotateAround(img1.position, Vector3.back, speed + (speed / 2));
    }

    int Number_Of_Dash(float distance)
    //AIM: Getting Number of dashes in relation to shoot
    //Input: Distance between circle's green point and the pointer
    //Output: The number of dashes
    {
        if (distance < 15)
        {
            return 3;
        }
        else if (distance > 15 && distance < 30)
        {
            return 2;
        }
        else if (distance > 30 && distance < 50)
        {
            return 1;
        }
        else return 0;
    }


}
    

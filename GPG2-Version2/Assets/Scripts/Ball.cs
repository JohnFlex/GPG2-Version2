using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool Grounded = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
            GetComponent<Rigidbody>().drag = 10;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
            GetComponent<Rigidbody>().drag = 0;
        }
    }

    public bool IsGrounded()
    {
        return Grounded;
    }
}

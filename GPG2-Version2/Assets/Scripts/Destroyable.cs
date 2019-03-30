using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Objet entrant : " + collision.gameObject.GetComponent<MeshRenderer>().material.name);
        Debug.Log("Objet entrant : " + this.gameObject.GetComponent<MeshRenderer>().material.name);
        if (collision.gameObject.CompareTag("Player") && (collision.gameObject.GetComponent<MeshRenderer>().material.name == this.gameObject.GetComponent<MeshRenderer>().material.name))
        {
            Destroy(this.gameObject);
        }
    }
}

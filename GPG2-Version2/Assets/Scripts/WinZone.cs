using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private int NbPlayers = 0;

    private void Update()
    {
        if(NbPlayers == 1)
        {
            NbPlayers = 0;
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("Victoère");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            NbPlayers++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            NbPlayers++;
        }
    }
}

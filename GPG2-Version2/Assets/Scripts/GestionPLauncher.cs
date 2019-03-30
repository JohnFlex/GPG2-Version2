using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPLauncher : MonoBehaviour
{
    public ParticleSystem ParticleLauncher;
    public GameObject Arrow;
     
    void Update()
    {
        if (!this.GetComponent<Ball>().IsGrounded())
        {
            LaunchSplit();
        }
    }

    void LaunchSplit()
    {
        ParticleLauncher.transform.position = transform.localPosition + (Vector3.down);
        ParticleLauncher.transform.LookAt(transform.localPosition + (Vector3.down *2));
        ParticleLauncher.Emit(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    public int MaxLaunchedBalls;
    public int TailleSphereRandom;
    public GameObject CibleSplitter;
    public Material TempColorChange;
    

    private int launchedBalls;
    private bool alreadyLaunched;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Etered");
        if (other.gameObject.CompareTag("Player"))
        {
            launchedBalls = 0;
            StartCoroutine(SumSplit(other.gameObject.GetComponent<GestionPLauncher>().ParticleLauncher));
            Debug.Log("Started");
            
        }
    }


    IEnumerator SumSplit(ParticleSystem particleSystem)
    {
        particleSystem.transform.position = CibleSplitter.transform.position + (Random.insideUnitSphere * 5);
        particleSystem.GetComponent<ParticleSystemRenderer>().material = TempColorChange;
        particleSystem.Emit(1);
        launchedBalls++;
        if (launchedBalls == MaxLaunchedBalls) StopCoroutine(SumSplit(null));
        yield return null;
    }
}

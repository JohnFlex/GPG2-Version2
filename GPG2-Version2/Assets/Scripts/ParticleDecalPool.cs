using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour
{
    private ParticleSystem.Particle[] particles;
    private ParticleSystem decalParticleSystem;
    private ParticleDecalData[] particleData;
    private int ParticleDecalDataIndex;

    public int MaxDecals = 100;
    public float DecalSizeMin = 0.5f;
    public float DecalSizeMax = 1.5f;
    



    // Start is called before the first frame update
    void Start()
    {
        decalParticleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[MaxDecals];
        particleData = new ParticleDecalData[MaxDecals];
        for (int i = 0; i < MaxDecals; i++)
        {
            particleData[i] = new ParticleDecalData();

        }
    }

    public void ParticleHit(ParticleCollisionEvent particleCollisionEvent)
    {
        SetParticlesData(particleCollisionEvent);
        DisplayArticles();
    }

    void SetParticlesData(ParticleCollisionEvent particleCollisionEvent)
    {
        if(ParticleDecalDataIndex >= MaxDecals)
        {
            ParticleDecalDataIndex = 0;
        }

        particleData[ParticleDecalDataIndex].position = particleCollisionEvent.intersection;
        Vector3 particleRotationEuler = Quaternion.LookRotation(-particleCollisionEvent.normal).eulerAngles;
        particleRotationEuler.z = Random.Range(0, 360);
        particleData[ParticleDecalDataIndex].rotation = particleRotationEuler;
        particleData[ParticleDecalDataIndex].size = Random.Range(DecalSizeMin, DecalSizeMax);

        ParticleDecalDataIndex++;
    }

    void DisplayArticles()
    {
        for (int i = 0; i < particleData.Length; i++)
        {
            particles[i].position = particleData[i].position;
            particles[i].rotation3D = particleData[i].rotation;
            particles[i].startSize = particleData[i].size;
        }
        decalParticleSystem.SetParticles(particles, particles.Length);
    }
}

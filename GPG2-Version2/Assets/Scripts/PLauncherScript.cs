using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLauncherScript : MonoBehaviour
{
    public ParticleSystem PLauncher;
    public ParticleSystem PSplatter;
    List<ParticleCollisionEvent> collisionEvents;
    public ParticleDecalPool splatDecalPool;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            PLauncher.Emit(1);
        }
    }

    private void OnParticleCollision(GameObject other)
    {

        ParticlePhysicsExtensions.GetCollisionEvents(PLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {

            splatDecalPool.ParticleHit(collisionEvents[i]);
            EmitAtLocation(collisionEvents[i]);
        }
        
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        PSplatter.transform.position = particleCollisionEvent.intersection;
        PSplatter.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);

        PSplatter.Emit(1);
    }
}
